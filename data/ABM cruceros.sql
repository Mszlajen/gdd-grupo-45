USE GD1C2019
GO

CREATE PROCEDURE MLJ.crearCrucero(@identificador VARCHAR(50), @codServicio INT, @codMarca INT, @codFabricante INT, @codModelo INT, @fechaAlta DATE)
AS BEGIN
	INSERT INTO MLJ.Cruceros
	(identificador, cod_fabricante, cod_marca, cod_modelo, cod_servicio, fecha_alta)
	VALUES
	(@identificador, @codFabricante, @codMarca, @codModelo, @codServicio, @fechaAlta)

	RETURN SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE MLJ.crearCabina(@codCrucero INT, @numero DECIMAL(18,0), @piso DECIMAL(18,0), @codTipo INT)
AS BEGIN
	INSERT INTO MLJ.Cabinas
	(cod_crucero, cod_tipo, piso, nro)
	VALUES
	(@codCrucero, @codTipo, @piso, @numero)

	RETURN SCOPE_IDENTITY()
END
GO

CREATE TRIGGER MLJ.BorradoCabinas ON MLJ.Cabinas
INSTEAD OF DELETE
AS BEGIN
	BEGIN TRANSACTION
	DELETE FROM MLJ.Cabinas
	WHERE cod_cabina IN (SELECT cod_cabina FROM deleted) AND cod_cabina NOT IN (SELECT cod_cabina FROM MLJ.Cabinas_reservadas)

	UPDATE MLJ.Cabinas
	SET habilitado = 0
	WHERE cod_cabina IN (SELECT cod_cabina FROM deleted)

	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.bajaCrucero(@fechaBaja DATE, @codCrucero INT)
AS BEGIN
	INSERT INTO MLJ.Bajas_de_servicio
	(permanente, cod_crucero, fecha_baja)
	VALUES
	(1, @codCrucero, @fechaBaja)
END
GO

CREATE PROCEDURE MLJ.bajaCruceroYCancela(@fechaBaja DATE, @codCrucero INT, @razon VARCHAR(255))
AS BEGIN
	BEGIN TRANSACTION
	EXEC MLJ.bajaCrucero @fechaBaja, @codCrucero

	UPDATE MLJ.Viajes 
	SET razon_de_cancelacion = @razon
	WHERE cod_crucero = @codCrucero AND @fechaBaja <= fecha_inicio 
	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.bajaCruceroYReemplaza(@fechaBaja DATE, @codCruceroBajado INT, @codCruceroReemplazante INT)
AS BEGIN
	DECLARE @codPasaje INT, @codCabinaVieja INT, @codTipo INT, @codViaje INT

	BEGIN TRANSACTION
	EXEC MLJ.bajaCrucero @fechaBaja, @codCruceroBajado

	UPDATE MLJ.Viajes
	SET cod_crucero = @codCruceroReemplazante
	WHERE cod_crucero = @codCruceroBajado AND (@fechaBaja <= fecha_inicio OR @fechaBaja < fecha_fin)

	--Aca va el reemplazo de cabinas compradas
	DECLARE cur CURSOR FOR SELECT cr.cod_pasaje, c.cod_cabina, c.cod_tipo, v.cod_viaje
						   FROM MLJ.Viajes v JOIN MLJ.Pasajes p ON v.cod_viaje = p.cod_viaje 
											 JOIN MLJ.Cabinas_reservadas cr ON p.cod_pasaje = cr.cod_pasaje
											 JOIN MLJ.Cabinas c ON c.cod_cabina = cr.cod_cabina
						   WHERE v.cod_crucero = @codCruceroReemplazante 

	OPEN cur

	FETCH NEXT FROM cur INTO @codPasaje, @codCabinaVieja, @codTipo, @codViaje

	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE MLJ.Cabinas_reservadas
		SET cod_cabina = (SELECT TOP 1 cod_cabina
						  FROM MLJ.Cabinas 
						  WHERE cod_crucero = @codCruceroReemplazante AND 
								cod_tipo = @codTipo AND 
								cod_cabina NOT IN (SELECT cod_cabina 
												   FROM MLJ.Cabinas_reservadas cr JOIN MLJ.Pasajes p ON cr.cod_pasaje = p.cod_pasaje
												   WHERE p.cod_viaje = @codViaje))
		WHERE cod_pasaje = @codPasaje AND cod_cabina = @codCabinaVieja

		FETCH NEXT FROM cur INTO @codPasaje, @codCabinaVieja, @codTipo, @codViaje
	END

	CLOSE cur
	DEALLOCATE cur

	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.bajaTemporalCrucero(@fechaBaja DATE, @fechaAlta DATE, @codCrucero INT, @corrimiento INT)
AS BEGIN
	
	BEGIN TRANSACTION

	INSERT INTO MLJ.Bajas_de_servicio
	(permanente, cod_crucero, fecha_baja, fecha_alta)
	VALUES
	(0, @codCrucero, @fechaBaja, @fechaAlta)

	UPDATE MLJ.Viajes
	SET fecha_inicio = DATEADD(day, @corrimiento, fecha_inicio),
		fecha_fin = DATEADD(day, @corrimiento, fecha_fin)
	WHERE cod_crucero = @codCrucero AND (@fechaBaja <= fecha_inicio OR @fechaBaja < fecha_fin)

	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.buscarPosibleReemplazos(@codCrucero INT, @fechaBaja DATE)
AS BEGIN
	DECLARE @codMarca INT, @codFabricante INT, @codModelo INT, @codServicio INT

	SELECT @codMarca = cod_marca, @codFabricante = cod_fabricante, @codModelo = cod_modelo, @codServicio = cod_servicio
	FROM MLJ.Cruceros

	SELECT cod_tipo, COUNT(*) cantidad
	INTO #cantidadCabinas
	FROM MLJ.Cabinas
	WHERE cod_crucero = @codCrucero
	GROUP BY cod_tipo

	SELECT fecha_inicio, fecha_fin
	INTO #fechaNecesario
	FROM MLJ.Viajes
	WHERE cod_crucero = @codCrucero AND fecha_inicio >= @fechaBaja

	-- Crucero reemplazante debe tener mismos datos de tipo (Hecho), cantidad y tipos de cabinas, y disponibilidad de fecha (Hecho)
	SELECT c.cod_crucero, cod_tipo, COUNT(cod_tipo) cantidad_tipo
	INTO #crucerosDisponiblesDeMismoTipo
	FROM MLJ.Cruceros c JOIN MLJ.Cabinas cabs ON cabs.cod_crucero = c.cod_crucero
	WHERE c.cod_crucero != @codCrucero AND cod_marca = @codMarca AND 
		  cod_fabricante = @codFabricante AND cod_modelo = @codModelo 
		  AND cod_servicio = @codServicio AND 
		  NOT EXISTS (SELECT TOP 1 *
					  FROM MLJ.Viajes v 
					  WHERE v.cod_crucero = c.cod_crucero AND
							EXISTS (SELECT TOP 1 * 
									FROM #fechaNecesario f 
									WHERE f.fecha_inicio BETWEEN v.fecha_inicio AND v.fecha_fin 
										  OR v.fecha_inicio BETWEEN f.fecha_inicio AND f.fecha_fin)) 
	GROUP BY c.cod_crucero, cod_tipo
	

	SELECT DISTINCT cod_crucero
	FROM #crucerosDisponiblesDeMismoTipo cd JOIN #cantidadCabinas cc ON cd.cod_tipo = cc.cod_tipo
	WHERE cd.cantidad_tipo >= cc.cantidad
	GROUP BY cod_crucero
	HAVING COUNT(*) = (SELECT COUNT(*) FROM #cantidadCabinas)
END