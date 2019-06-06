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
