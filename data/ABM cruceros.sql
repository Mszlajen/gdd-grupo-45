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
	BEGIN TRANSACTION
	EXEC MLJ.bajaCrucero @fechaBaja, @codCruceroBajado

	UPDATE MLJ.Viajes
	SET cod_crucero = @codCruceroReemplazante
	WHERE cod_crucero = @codCruceroBajado AND @fechaBaja <= fecha_inicio

	--Aca va el reemplazo de cabinas compradas
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

	-- Aca puede darse que el viaje inicie antes del periodo de baja
	-- y termine durante o despues de éste, lo voy a considerar como
	-- responsabilidad del administrador.
	UPDATE MLJ.Viajes
	SET fecha_inicio = DATEADD(day, @corrimiento, fecha_inicio),
		fecha_fin = DATEADD(day, @corrimiento, fecha_fin)
	WHERE cod_crucero = @codCrucero AND @fechaBaja <= fecha_inicio
END
GO

CREATE PROCEDURE MLJ.buscarPosibleReemplazos(@codCrucero INT)
AS BEGIN
	DECLARE @codMarca INT, @codFabricante INT, @codModelo INT, @codServicio INT

	SELECT @codMarca = cod_marca, @codFabricante = cod_fabricante, @codModelo = cod_modelo, @codServicio = cod_servicio
	FROM MLJ.Cruceros

	SELECT cod_tipo, COUNT(*) cantidad
	INTO #cantidadCabinas
	FROM MLJ.Cabinas
	WHERE cod_crucero = @codCrucero
	GROUP BY cod_tipo

	-- Crucero reemplazante debe tener mismos datos de tipo (Hecho), cantidad y tipos de cabinas (Hecho creo), y disponibilidad de fecha
	SELECT DISTINCT crus.cod_crucero
	FROM MLJ.Cruceros crus JOIN MLJ.Cabinas cabs ON crus.cod_crucero = cabs.cod_crucero
	WHERE crus.cod_crucero != @codCrucero AND cod_marca = @codMarca AND 
		  cod_fabricante = @codFabricante AND cod_modelo = @codModelo 
		  AND cod_servicio = @codServicio
	GROUP BY crus.cod_crucero, cabs.cod_tipo
	HAVING COUNT(cod_tipo) >= (SELECT cantidad FROM #cantidadCabinas WHERE cod_tipo = cabs.cod_tipo)

END