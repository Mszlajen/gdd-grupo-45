USE GD1C2019
GO

CREATE SCHEMA MLJ
GO

/*--------------------------------*/
--Creacion de tablas
--Sentencia crea tabla Usuarios
CREATE TABLE MLJ.Usuarios (
	cod_usuario INTEGER IDENTITY(1,1) PRIMARY KEY,
	usuario varchar(50) UNIQUE NOT NULL,
	hash_contrasenia char(256) NOT NULL,
	habilitado bit NOT NULL DEFAULT(1),
	ingresos_restantes tinyint NOT NULL DEFAULT(3)
);

--Sentencia crea tabla UsuariosXRoles
CREATE TABLE MLJ.UsuariosXRoles (
	cod_usuario INTEGER NOT NULL,
	cod_rol INTEGER NOT NULL
);

--Sentencia crea tabla Roles
CREATE TABLE MLJ.Roles (
	cod_rol INTEGER IDENTITY(1,1) PRIMARY KEY,
	descripcion varchar(255) NOT NULL,
	habilitado bit NOT NULL DEFAULT(1),
	registrable bit NOT NULL DEFAULT(1)		
);

--Sentencia crea tabla RolesXFuncionalidades
CREATE TABLE MLJ.RolesXFuncionalidades (
	cod_rol INTEGER NOT NULL,
	cod_funcionalidad INTEGER NOT NULL		
);

--Sentencia crea tabla Funcionalidades
CREATE TABLE MLJ.Funcionalidades (
	cod_funcionalidad INTEGER IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion varchar(255) NOT NULL	
);

--Sentencia crea tabla Viajes
CREATE TABLE MLJ.Viajes (
	cod_viaje INTEGER IDENTITY(1,1) PRIMARY KEY,
	fecha_inicio datetime NOT NULL,
	fecha_fin_estimada datetime,
	fecha_fin datetime NOT NULL,
	cod_recorrido INTEGER NOT NULL,
	cod_crucero INTEGER NOT NULL,
	retorna bit NOT NULL,
	razon_de_cancelacion varchar(255)
);

--Sentencia crea tabla Recorridos
CREATE TABLE MLJ.Recorridos (
	cod_recorrido INTEGER IDENTITY(1,1) PRIMARY KEY,
	habilitado bit NOT NULL DEFAULT(1),
	cod_viejo DECIMAL(18,0)
);

--Sentencia crea tabla Tramos
CREATE TABLE MLJ.Tramos (
	cod_recorrido INTEGER NOT NULL,
	nro_tramo TINYINT NOT NULL,
	cod_puerto_salida INTEGER NOT NULL,
	cod_puerto_llegada INTEGER NOT NULL,
	costo numeric(18,2) NOT NULL,
	primary key(cod_recorrido,nro_tramo)
);


--Sentencia crea tabla Puertos
CREATE TABLE MLJ.Puertos (
	cod_puerto INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL,
	habilitado bit NOT NULL DEFAULT(1)	
);

--Sentencia crea tabla Marcas
CREATE TABLE MLJ.Marcas (
	cod_marca INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Servicios
CREATE TABLE MLJ.Servicios (
	cod_servicio INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Fabricantes
CREATE TABLE MLJ.Fabricantes (
	cod_fabricante INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Modelos
CREATE TABLE MLJ.Modelos (
	cod_modelo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Cruceros
CREATE TABLE MLJ.Cruceros (
	cod_crucero INTEGER IDENTITY(1,1) PRIMARY KEY,
	identificador varchar(50) NOT NULL,
	fecha_alta datetime,
	cod_marca INTEGER,	
	cod_servicio INTEGER,
	cod_fabricante INTEGER NOT NULL,
	cod_modelo INTEGER NOT NULL
);

--Sentencia crea tabla Bajas_de_servicio
CREATE TABLE MLJ.Bajas_de_servicio (
	cod_baja INTEGER IDENTITY(1,1) PRIMARY KEY,
	cod_crucero INTEGER NOT NULL,
	permanente bit NOT NULL DEFAULT(0),
	fecha_baja datetime NOT NULL,
	fecha_alta datetime,
	CHECK(NOT permanente = 1 OR fecha_alta IS NULL)
);

--Sentencia crea tabla Cabinas
CREATE TABLE MLJ.Cabinas (
	cod_cabina INTEGER IDENTITY(1,1),
	cod_crucero INTEGER NOT NULL,
	nro decimal(18,0) NOT NULL,
	cod_tipo INTEGER NOT NULL,
	piso decimal(18,0) NOT NULL,
	habilitado BIT NOT NULL DEFAULT(1),
	primary key(cod_cabina)
);

--Sentencia crea tabla Tipo_Cabinas
CREATE TABLE MLJ.Tipo_Cabinas (
	cod_tipo INTEGER IDENTITY(1,1) PRIMARY KEY,
	valor numeric(4,2) NOT NULL,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Reservas
CREATE TABLE MLJ.Reservas (
	cod_reserva INTEGER IDENTITY(1,1) PRIMARY KEY,
	fecha_reserva datetime NOT NULL,
	cod_pasaje INTEGER NOT NULL,
	cod_viejo decimal(18,0)
);

--Sentencia crea tabla Pasajes
CREATE TABLE MLJ.Pasajes (
	cod_pasaje INTEGER IDENTITY(1,1) PRIMARY KEY,
	cod_cliente INTEGER NOT NULL,
	cod_viaje INTEGER NOT NULL,
	cantidad numeric(18,2) NOT NULL,
	cod_viejo DECIMAL(18,0)
);

--Sentencia crea tabla Cabinas_reservadas
CREATE TABLE MLJ.Cabinas_reservadas (
	cod_pasaje INTEGER NOT NULL,
	cod_cabina INTEGER NOT NULL,
	primary key(cod_pasaje, cod_cabina)
);

--Sentencia crea tabla Pagos
CREATE TABLE MLJ.Pagos (
	cod_pago INTEGER IDENTITY(1,1) PRIMARY KEY,
	cod_pasaje INTEGER NOT NULL,
	fecha datetime NOT NULL,
	cod_medio INTEGER,
	hash_nro_tarjeta char(255),
	ultimos_digitos char(4),
	cod_seguridad char(4)
);

--Sentencia crea tabla Medios_de_Pago
CREATE TABLE MLJ.Medios_de_Pago (
	cod_medio INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL
);

--Sentencia crea tabla Clientes
CREATE TABLE MLJ.Clientes (
	cod_cliente INTEGER IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	dni decimal(18,0) NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono INTEGER NOT NULL,
	mail varchar(255),
	nacimiento datetime NOT NULL
	
);

/*----Aca creamos foreign keys------*/
ALTER TABLE MLJ.UsuariosXRoles ADD
CONSTRAINT fk_usuariorol_usuario FOREIGN KEY (cod_usuario) REFERENCES MLJ.Usuarios(cod_usuario)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_usuariorol_rol FOREIGN KEY (cod_rol) REFERENCES MLJ.Roles(cod_rol)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.RolesXFuncionalidades ADD
CONSTRAINT fk_rolfuncionalidad_rol FOREIGN KEY (cod_rol) REFERENCES MLJ.Roles(cod_rol)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_rolfuncionalidad_func FOREIGN KEY (cod_funcionalidad) REFERENCES MLJ.Funcionalidades(cod_funcionalidad)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.Viajes ADD
CONSTRAINT fk_viajes_recorrido FOREIGN KEY (cod_recorrido) REFERENCES MLJ.Recorridos(cod_recorrido)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_viajes_crucero FOREIGN KEY (cod_crucero) REFERENCES MLJ.Cruceros(cod_crucero)
ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE MLJ.Tramos ADD
CONSTRAINT fk_tramos_recorrido FOREIGN KEY (cod_recorrido) REFERENCES MLJ.Recorridos(cod_recorrido)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_tramos_puerto_salida FOREIGN KEY (cod_puerto_salida) REFERENCES MLJ.Puertos(cod_puerto)
ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_tramos_puerto_llegada FOREIGN KEY (cod_puerto_llegada) REFERENCES MLJ.Puertos(cod_puerto)
ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE MLJ.Cruceros ADD
CONSTRAINT fk_cruceros_marca FOREIGN KEY (cod_marca) REFERENCES MLJ.Marcas(cod_marca)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_cruceros_servicio FOREIGN KEY (cod_servicio) REFERENCES MLJ.Servicios(cod_servicio)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_cruceros_fabricante FOREIGN KEY (cod_fabricante) REFERENCES MLJ.Fabricantes(cod_fabricante)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_cruceros_modelo FOREIGN KEY (cod_modelo) REFERENCES MLJ.Modelos(cod_modelo)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.Bajas_de_servicio ADD
CONSTRAINT fk_bajas_crucero FOREIGN KEY (cod_crucero) REFERENCES MLJ.Cruceros(cod_crucero)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.Cabinas ADD
CONSTRAINT fk_cabinas_crucero FOREIGN KEY (cod_crucero) REFERENCES MLJ.Cruceros(cod_crucero)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_cabinas_tipo FOREIGN KEY (cod_tipo) REFERENCES MLJ.Tipo_Cabinas(cod_tipo)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.Reservas ADD
CONSTRAINT fk_reservas_pasaje FOREIGN KEY (cod_pasaje) REFERENCES MLJ.Pasajes(cod_pasaje)
ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE MLJ.Pasajes ADD
CONSTRAINT fk_pasajes_cliente FOREIGN KEY (cod_cliente) REFERENCES MLJ.Clientes(cod_cliente)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_pasajes_viaje FOREIGN KEY (cod_viaje) REFERENCES MLJ.Viajes(cod_viaje)
ON DELETE NO ACTION ON UPDATE CASCADE

ALTER TABLE MLJ.Cabinas_reservadas ADD
CONSTRAINT fk_cabinas_reservadas_cliente FOREIGN KEY (cod_pasaje) REFERENCES MLJ.Pasajes(cod_pasaje)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_cabinas_reservadas_cabina FOREIGN KEY (cod_cabina) REFERENCES MLJ.Cabinas(cod_cabina)
ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE MLJ.Pagos ADD
CONSTRAINT fk_pagos_medio FOREIGN KEY (cod_medio) REFERENCES MLJ.Medios_de_Pago(cod_medio)
ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_pago_pasaje FOREIGN KEY (cod_pasaje) REFERENCES MLJ.Pasajes(cod_pasaje)
ON DELETE NO ACTION ON UPDATE CASCADE;

/*--------------------------------*/
--Creacion de indices

--Creo el indice para buscar los clientes por su DNI 
CREATE INDEX DNI ON MLJ.Clientes(dni)

--Creo el indice para buscar usuarios
CREATE INDEX USUARIO ON MLJ.Usuarios(usuario)

/*--------------------------------*/
--Creacion de datos nuevos

INSERT INTO MLJ.Servicios
(nombre)
VALUES
('No definido'), 
('All Inclusive'), 
('Day travel')

INSERT INTO MLJ.Marcas
(nombre)
VALUES
('No definido'),
('Costa Cruceros'),
('MSC Cruceros'),
('Pullmantur')

INSERT INTO MLJ.Medios_de_Pago
(nombre)
VALUES
('MasterCard'), 
('VISA')

INSERT INTO MLJ.Funcionalidades 
(descripcion) 
VALUES 
('Compra y/o Reserva de Viaje'), 
('Pago Reserva'),
('ABM Puertos'),
('ABM Rol'),
('ABM Usuarios'),
('ABM Recorridos'),
('ABM Cruceros'),
('Generar Viaje'),
('ListadosTOP')

INSERT INTO MLJ.Roles 
(descripcion, habilitado, registrable) 
VALUES 
('Administrador', 1, 0),
('Cliente', 1, 1)

INSERT INTO MLJ.RolesXFuncionalidades 
(cod_rol, cod_funcionalidad) 
VALUES 
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(2, 1),
(2, 2)

INSERT MLJ.Usuarios 
(usuario, hash_contrasenia) 
VALUES 
('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
('admin2','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
('admin3','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7')
INSERT MLJ.UsuariosXRoles 
(cod_usuario, cod_rol) 
VALUES 
(1, 1),
(2, 1),
(3, 1)
	
/*--------------------------------*/
--Migracion de datos

--Migro los datos de "tipo", para las migraciones posteriores pueden recuperarse con el nombre
INSERT INTO MLJ.Tipo_Cabinas
(valor, nombre)
SELECT DISTINCT CABINA_TIPO_PORC_RECARGO, CABINA_TIPO 
FROM gd_esquema.Maestra

INSERT INTO MLJ.Modelos
(nombre)
SELECT DISTINCT CRUCERO_MODELO
FROM gd_esquema.Maestra

INSERT INTO MLJ.Fabricantes
(nombre)
SELECT DISTINCT CRU_FABRICANTE
FROM gd_esquema.Maestra

-- Coloco en una tabla temporal todos los puertos que aparecen (de salida y de llegada)
SELECT DISTINCT PUERTO_DESDE puerto
INTO #PuertosConRepeticiones
FROM gd_esquema.Maestra

INSERT INTO #PuertosConRepeticiones
SELECT DISTINCT PUERTO_HASTA
FROM gd_esquema.Maestra

-- Migro los puertos ignorando las repeticiones
INSERT INTO MLJ.Puertos
(nombre, habilitado)
SELECT DISTINCT puerto, 1
FROM #PuertosConRepeticiones

--Me deshago de la tabla temporal usada para migrar los puertos
DROP TABLE #PuertosConRepeticiones	

-- Migro la información de los clientes, para recuperar a uno hay que usar el DNI + Apellido + Nombre
-- Hay un par de clientes que tienen mismo DNI y Apellido por eso es necesario tambien el nombre.
INSERT INTO MLJ.Clientes
(nombre, apellido, dni, direccion, telefono, mail, nacimiento)
SELECT DISTINCT CLI_NOMBRE, CLI_APELLIDO, CLI_DNI, CLI_DIRECCION, CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC
FROM gd_esquema.Maestra

--Migro los cruceros
INSERT INTO MLJ.Cruceros
(identificador, cod_fabricante, cod_modelo, cod_servicio, cod_marca)
SELECT DISTINCT CRUCERO_IDENTIFICADOR, 
	(SELECT F.cod_fabricante FROM MLJ.Fabricantes F WHERE M.CRU_FABRICANTE = F.nombre),
	(SELECT Mo.cod_modelo FROM MLJ.Modelos Mo WHERE M.CRUCERO_MODELO = Mo.nombre),
	1, 1
FROM gd_esquema.Maestra M

--Migro las cabinas
INSERT INTO MLJ.Cabinas
(cod_crucero, nro, cod_tipo, piso)
SELECT DISTINCT (SELECT cod_crucero FROM MLJ.Cruceros C WHERE M.CRUCERO_IDENTIFICADOR = c.identificador) crucero,
				M.CABINA_NRO,
				(SELECT cod_tipo FROM MLJ.Tipo_Cabinas TC WHERE M.CABINA_TIPO = TC.nombre),
				M.CABINA_PISO
FROM gd_esquema.Maestra M


-- Creo una tabla temporal que normaliza los datos ya migrados y tiene columnas para los que no fueron migrados todavia	
SELECT DISTINCT (SELECT cod_cliente FROM MLJ.Clientes C WHERE C.dni = M.CLI_DNI AND C.apellido = M.CLI_APELLIDO AND C.nombre = M.CLI_NOMBRE) CLI_CODIGO,
				PASAJE_CODIGO, 
				PASAJE_FECHA_COMPRA, 
				PASAJE_PRECIO, 
				FECHA_SALIDA, 
				FECHA_LLEGADA, 
				FECHA_LLEGADA_ESTIMADA, 
				RECORRIDO_CODIGO, 
				RECORRIDO_PRECIO_BASE, 
				(SELECT cod_puerto FROM MLJ.Puertos P WHERE P.nombre = M.PUERTO_DESDE) PUERTO_DESDE_COD,
				(SELECT cod_puerto FROM MLJ.Puertos P WHERE P.nombre = M.PUERTO_HASTA) PUERTO_HASTA_COD,
				CABINA_NRO, 
				(SELECT cod_crucero FROM MLJ.Cruceros C WHERE C.identificador = M.CRUCERO_IDENTIFICADOR) CRU_CODIGO, 
				CABINA_PISO,
				RESERVA_CODIGO, 
				RESERVA_FECHA,
				NULL CABINA_CODIGO,
				NULL RECORRIDO_CODIGO_NUEVO,
				NULL VIAJE_CODIGO,
				NULL PASAJE_CODIGO_NUEVO
INTO #temp
FROM GD1C2019.gd_esquema.Maestra M

-- Coloco el codigo de cabina normalizado
-- No puedo hacer al crear la tabla porque necesito el codigo de crucero
UPDATE t
SET CABINA_CODIGO = (SELECT c.cod_cabina FROM MLJ.Cabinas C WHERE t.CRU_CODIGO = c.cod_crucero AND t.CABINA_NRO = c.nro AND t.CABINA_PISO = c.piso)
FROM #temp t

-- Creo una segunda tabla temporal que agrega el numero de fila usando el orden cod_recorrido, puerto_desde, y puerto_hasta
SELECT ROW_NUMBER() OVER(ORDER BY cod_recorrido_viejo, PUERTO_DESDE_COD, PUERTO_HASTA_COD) cod_recorrido_nuevo, 
	cod_recorrido_viejo, PUERTO_DESDE_COD, PUERTO_HASTA_COD, RECORRIDO_PRECIO_BASE
INTO #recorridos
FROM (SELECT DISTINCT RECORRIDO_CODIGO cod_recorrido_viejo, PUERTO_DESDE_COD, PUERTO_HASTA_COD, RECORRIDO_PRECIO_BASE
	  FROM #temp) recorridos

-- Migro los recorridos respetando el orden en que se asigno el numero de fila de manera que se coincida con la clave primaria
INSERT INTO MLJ.Recorridos
(cod_viejo)
SELECT cod_recorrido_viejo
FROM #recorridos
ORDER BY cod_recorrido_viejo, PUERTO_DESDE_COD, PUERTO_HASTA_COD

-- Migro los tramos usando el numero de fila como referencia a recorridos
INSERT INTO MLJ.Tramos
(cod_recorrido, cod_puerto_salida, cod_puerto_llegada, costo, nro_tramo)
SELECT cod_recorrido_nuevo, PUERTO_DESDE_COD, PUERTO_HASTA_COD, RECORRIDO_PRECIO_BASE, 0
FROM #recorridos

-- Actualizo en la tabla temporal normalizada el valor de los cod de recorrido
UPDATE t
SET RECORRIDO_CODIGO_NUEVO = (SELECT cod_recorrido_nuevo FROM #recorridos r WHERE r.cod_recorrido_viejo = t.RECORRIDO_CODIGO AND r.PUERTO_DESDE_COD = t.PUERTO_DESDE_COD AND R.PUERTO_HASTA_COD = t.PUERTO_HASTA_COD)
FROM #temp t

-- Elimino la tabla temporal de recorridos
DROP TABLE #recorridos

-- Migro la informacion de los viajes
INSERT INTO MLJ.Viajes
(cod_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada, retorna, cod_recorrido)
SELECT DISTINCT CRU_CODIGO, FECHA_SALIDA, FECHA_LLEGADA, FECHA_LLEGADA_ESTIMADA, 0,
		RECORRIDO_CODIGO_NUEVO
FROM #temp t

-- Actualizo el cod de viaje en la tabla temporal normalizada
UPDATE t
SET VIAJE_CODIGO = (SELECT cod_viaje FROM MLJ.Viajes v WHERE v.cod_recorrido = t.RECORRIDO_CODIGO_NUEVO AND v.cod_crucero = t.CRU_CODIGO AND v.fecha_inicio = t.FECHA_SALIDA)
FROM #temp t

-- Migro los pasajes
INSERT INTO MLJ.Pasajes
(cantidad, cod_cliente, cod_viaje, cod_viejo)
SELECT DISTINCT PASAJE_PRECIO, CLI_CODIGO, VIAJE_CODIGO, PASAJE_CODIGO
FROM #temp 
WHERE PASAJE_CODIGO IS NOT NULL

-- Actualizo el codigo de pasaje en la tabla temporal normalizada
-- Como la tabla tiene una fila para el pasaje/compra y otra para la reserva, las segundas el campo queda en NULL
UPDATE t
SET PASAJE_CODIGO_NUEVO = (SELECT cod_pasaje FROM MLJ.Pasajes p WHERE t.CLI_CODIGO = p.cod_cliente AND t.VIAJE_CODIGO = p.cod_viaje AND t.PASAJE_CODIGO = p.cod_viejo)
FROM #temp t

-- Migro las cabinas que ya están reservadas
INSERT INTO MLJ.Cabinas_reservadas
(cod_pasaje, cod_cabina)
SELECT DISTINCT PASAJE_CODIGO_NUEVO, CABINA_CODIGO
FROM #temp t
WHERE PASAJE_CODIGO_NUEVO IS NOT NULL

-- Migro la informacion del pago 
-- Al haber usado el codigo de pasaje como forma de ordenamiento al insertar los pago 
-- y de que solo hay un pago por pasaje los codigo se coinciden
INSERT INTO MLJ.Pagos
(fecha, cod_pasaje)
SELECT PASAJE_FECHA_COMPRA, PASAJE_CODIGO_NUEVO
FROM #temp
WHERE PASAJE_CODIGO_NUEVO IS NOT NULL
ORDER BY PASAJE_CODIGO_NUEVO

-- Migro la informacion de las reservas
INSERT INTO MLJ.Reservas
(cod_pasaje, cod_viejo, fecha_reserva)
SELECT DISTINCT (SELECT cod_pasaje FROM MLJ.Pasajes p WHERE p.cod_cliente = t.CLI_CODIGO AND p.cod_viaje = t.VIAJE_CODIGO), 
		RESERVA_CODIGO, RESERVA_FECHA
FROM #temp t
WHERE t.PASAJE_CODIGO_NUEVO IS NULL

-- Elimino la tabla temporal normalizada
DROP TABLE #temp
GO
/*--------------------------------*/
--Creacion de logica para aplicación

CREATE PROCEDURE MLJ.verificar_viaje @codigo_recorrido int, @cod_crucero int, @fechaSalida datetime, @fechaLlegada datetime, @fechaActual datetime, @retorno bit, @resultado int output
AS
BEGIN
	IF (@fechaActual >= @fechaSalida)
		BEGIN
		SET @resultado = -1
		END
	ELSE IF NOT EXISTS(SELECT cod_crucero FROM MLJ.Cruceros WHERE cod_crucero NOT IN (select cod_crucero FROM MLJ.Bajas_de_servicio WHERE (permanente = 1 OR fecha_alta >= @fechaSalida)) AND cod_crucero NOT IN (SELECT viajes.cod_crucero FROM MLJ.Viajes viajes WHERE (viajes.fecha_inicio BETWEEN @fechaSalida AND @fechaLlegada) OR (viajes.fecha_fin BETWEEN @fechaSalida AND @fechaLlegada)))
		BEGIN
		SET @resultado = -2
		END
	ELSE IF EXISTS(SELECT * FROM MLJ.Bajas_de_servicio WHERE (permanente = 1 OR fecha_alta >= @fechaSalida) AND (cod_crucero = @cod_crucero))
		BEGIN
		SET @resultado = -3
		END
	ELSE IF @cod_crucero NOT IN (SELECT cod_crucero FROM MLJ.Cruceros WHERE cod_crucero NOT IN (select cod_crucero FROM MLJ.Bajas_de_servicio WHERE (permanente = 1 OR fecha_alta >= @fechaSalida)) AND cod_crucero NOT IN (SELECT viajes.cod_crucero FROM MLJ.Viajes viajes WHERE (viajes.fecha_inicio BETWEEN @fechaSalida AND @fechaLlegada) OR (viajes.fecha_fin BETWEEN @fechaSalida AND @fechaLlegada)))
		BEGIN
		SET @resultado = -4
		END
	ELSE IF EXISTS(SELECT * FROM MLJ.Recorridos WHERE cod_recorrido = @codigo_recorrido AND habilitado = 0)
		BEGIN
		SET @resultado = -5
		END
	ELSE 
		BEGIN
		INSERT INTO MLJ.Viajes(fecha_inicio, fecha_fin, cod_recorrido, cod_crucero,retorna)
			VALUES (@fechaSalida, @fechaLlegada, @codigo_recorrido,@cod_crucero, @retorno)
		SET @resultado = 1
		END
END
GO
--Inicio de sesion
--Este procedure se encarga de comprobar la password, el estado del usuario y devuelve el resultado
CREATE PROCEDURE MLJ.login @usuario varchar(50), @password varchar(256), @resultado int OUTPUT
AS
BEGIN
	
	/*
	0 -> Usuario Deshabilitado
	1 -> Password ok
	2 -> Password no ok
	3 -> User not found
	*/

	SET @resultado = ISNULL((SELECT 
								CASE 
								WHEN ingresos_restantes = 0 THEN 0
								WHEN (CONVERT(CHAR(256),HASHBYTES('SHA2_256',@password),2) = hash_contrasenia) THEN 1
								ELSE 2
								END
							FROM MLJ.Usuarios
							WHERE usuario = @usuario),3)
	/*Si la passwrod no es correcta resto la cantidad de intentos*/
	IF(@resultado = 2) 
	BEGIN
		UPDATE MLJ.Usuarios SET ingresos_restantes = ingresos_restantes - 1 WHERE usuario=@usuario; 
	END
	/*Si la loguea bien reinicio la cant de intentos, si esta deshabilitado no loguea ni reinicio cant de intentos*/
	IF (@resultado = 1)
	BEGIN
		UPDATE MLJ.Usuarios SET ingresos_restantes = 3 WHERE usuario = @usuario;
	END
END
GO 

--ABM de rol
CREATE TRIGGER MLJ.BajaLogicaROL 
ON MLJ.Roles INSTEAD OF UPDATE
AS
BEGIN
	BEGIN TRANSACTION
		MERGE INTO MLJ.Roles r
		USING inserted i
		ON r.cod_rol = i.cod_rol
		WHEN MATCHED THEN
		UPDATE SET
		r.descripcion = i.descripcion,
		r.habilitado = i.habilitado,
		r.registrable = i.registrable;

		DELETE FROM MLJ.UsuariosXRoles WHERE cod_rol IN (SELECT i.cod_rol FROM inserted i WHERE i.habilitado = 0);
	COMMIT TRANSACTION
END
GO

--Compra/reserva de pasaje
CREATE FUNCTION MLJ.cruceroDeshabilitado(@fecha DATE, @cod_crucero INT)
RETURNS INT
AS 
BEGIN
	DECLARE @codBaja INT

	SELECT @codBaja = bs.cod_baja 
	FROM MLJ.Cruceros c JOIN MLJ.Bajas_de_servicio bs ON c.cod_crucero = bs.cod_crucero 
	WHERE c.cod_crucero = @cod_crucero AND CONVERT(DATE, bs.fecha_baja) <= @fecha 
		  AND (bs.permanente = 1 OR @fecha < CONVERT(DATE, bs.fecha_alta))

	RETURN @codBaja
END
GO

CREATE PROCEDURE MLJ.buscarViajes(@fecha DATE, @cod_origen INT, @cod_destino INT)
AS BEGIN
	IF(@cod_origen IS NULL AND @cod_destino IS NULL)
	BEGIN
		SELECT v.cod_viaje, v.fecha_inicio, v.fecha_fin, v.cod_recorrido, v.cod_crucero, v.retorna, v.razon_de_cancelacion
			FROM MLJ.Viajes v
			WHERE @fecha = CONVERT(DATE, v.fecha_inicio) AND razon_de_cancelacion IS NULL 
				  AND MLJ.cruceroDeshabilitado(@fecha, v.cod_crucero) IS NULL
	END
	ELSE
	BEGIN
		SELECT v.cod_viaje, v.fecha_inicio, v.fecha_fin, v.cod_recorrido, v.cod_crucero, v.retorna, v.razon_de_cancelacion
		FROM MLJ.Viajes v
		WHERE @fecha = CONVERT(DATE, v.fecha_inicio) AND razon_de_cancelacion IS NULL 
			  AND MLJ.cruceroDeshabilitado(@fecha, v.cod_crucero) IS NULL
			  AND v.cod_recorrido IN (SELECT r.cod_recorrido 
									  FROM MLJ.Recorridos r JOIN MLJ.Tramos t ON r.cod_recorrido = t.cod_recorrido
									  WHERE	(@cod_origen IS NULL OR (t.cod_puerto_salida = @cod_origen AND t.nro_tramo = 0)) AND 
											(@cod_destino IS NULL OR t.cod_puerto_llegada = @cod_destino))
	END
END
GO

CREATE PROCEDURE MLJ.buscarCabinasDisponibles(@codViaje INT)
AS
BEGIN
	SELECT cod_cabina, cod_crucero, nro, cod_tipo, piso
	FROM MLJ.Cabinas
	WHERE cod_crucero = (SELECT cod_crucero FROM MLJ.Viajes WHERE cod_viaje = @codViaje)
		AND habilitado = 1
		AND NOT cod_cabina IN (SELECT cod_cabina FROM Cabinas_reservadas 
							   WHERE cod_pasaje IN (SELECT cod_pasaje FROM MLJ.Pasajes 
													WHERE cod_viaje = @codViaje))
END
GO

CREATE PROCEDURE MLJ.clienteViajaDurante(@inicio DATE, @fin DATE, @cod_cliente INT)
AS BEGIN
	SELECT cod_pasaje
	FROM MLJ.Pasajes p JOIN MLJ.Viajes v ON p.cod_viaje = v.cod_viaje
	WHERE p.cod_cliente = @cod_cliente 
		  AND (v.fecha_inicio BETWEEN @inicio AND @fin 
			   OR v.fecha_fin BETWEEN @inicio AND @fin)
END
GO

CREATE PROCEDURE MLJ.CrearCliente(@nombre VARCHAR(255), @apellido VARCHAR(255), @direccion VARCHAR(255), @telefono INT, @dni DECIMAL, @mail VARCHAR(255), @fechaNacimiento DATE)
AS BEGIN
	INSERT INTO MLJ.Clientes
	(nombre, apellido, dni, direccion, telefono, mail, nacimiento)
	VALUES
	(@nombre, @apellido, @dni, @direccion, @telefono, @mail, @fechaNacimiento)

	RETURN SCOPE_IDENTITY()
END
GO

-- Función auxiliar para poder pasar multiples codigos como un varchar a los procedimientos y funciones
CREATE FUNCTION MLJ.SplitList (@list VARCHAR(MAX), @separator VARCHAR(MAX) = ';')
RETURNS @table TABLE (Value VARCHAR(MAX))
AS BEGIN
  DECLARE @position INT, @previous INT
  SET @list = @list + @separator
  SET @previous = 1
  SET @position = CHARINDEX(@separator, @list)
  WHILE @position > 0 
  BEGIN
    IF @position - @previous > 0
      INSERT INTO @table VALUES (SUBSTRING(@list, @previous, @position - @previous))
    IF @position >= LEN(@list) BREAK
      SET @previous = @position + 1
      SET @position = CHARINDEX(@separator, @list, @previous)
  END
  RETURN
END
GO

CREATE FUNCTION MLJ.calcularCosto(@cod_viaje INT, @cabinas VARCHAR(max))
RETURNS DECIMAL(18,2)
AS BEGIN
	DECLARE @costoRecorrido DECIMAL(18,2), @costoTotal DECIMAL(18,2)

	SELECT @costoRecorrido = SUM(t.costo) 
	FROM MLJ.Tramos t
	WHERE cod_recorrido = (SELECT cod_recorrido FROM MLJ.Viajes WHERE cod_viaje = @cod_viaje)

	SELECT @costoTotal = SUM(@costoRecorrido * tc.valor) 
	FROM MLJ.Cabinas c JOIN MLJ.Tipo_Cabinas tc ON c.cod_tipo = tc.cod_tipo
	WHERE c.cod_cabina IN (SELECT * FROM MLJ.SplitList(@cabinas, ' '))

	RETURN @costoTotal
END
GO

CREATE PROCEDURE MLJ.crearPasaje(@cod_cliente INT, @cod_viaje INT, @cabinas VARCHAR(max))
AS BEGIN
	DECLARE @cod_pasaje INT
	BEGIN TRANSACTION
		INSERT INTO MLJ.Pasajes
		(cod_cliente, cod_viaje, cantidad)
		VALUES
		(@cod_cliente, @cod_viaje, MLJ.calcularCosto(@cod_viaje, @cabinas))

		SET @cod_pasaje = SCOPE_IDENTITY()

		INSERT INTO MLJ.Cabinas_reservadas
		(cod_pasaje, cod_cabina)
		SELECT @cod_pasaje, value
		FROM MLJ.SplitList(@cabinas, ' ')

	COMMIT TRANSACTION

	RETURN @cod_pasaje
END
GO

CREATE PROCEDURE MLJ.crearReserva(@cod_pasaje INT, @fecha DATE)
AS BEGIN
	INSERT INTO MLJ.Reservas
	(cod_pasaje, fecha_reserva)
	VALUES
	(@cod_pasaje, @fecha)

	RETURN SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE MLJ.crearPago(@cod_pasaje INT, @numTarjeta CHAR(16), @pin CHAR(4), @cod_medio INT, @fecha DATE)
AS BEGIN
	INSERT INTO MLJ.Pagos
	(fecha, cod_medio, cod_pasaje, cod_seguridad, hash_nro_tarjeta, ultimos_digitos)
	VALUES
	(@fecha, @cod_medio, @cod_pasaje, @pin, CONVERT(CHAR(256),HASHBYTES('SHA2_256',@numTarjeta),2), RIGHT(@numTarjeta, 4))

	RETURN SCOPE_IDENTITY()
END
GO

--Pago de reservas

CREATE PROCEDURE MLJ.pagarReserva(@cod_reserva INT, @numTarjeta CHAR(16), @pin CHAR(4), @cod_medio INT, @fecha DATE)
AS BEGIN
	INSERT INTO MLJ.Pagos
	(cod_pasaje, fecha, cod_medio, cod_seguridad, hash_nro_tarjeta, ultimos_digitos)
	SELECT cod_pasaje, @fecha, @cod_medio, @pin, CONVERT(CHAR(256),HASHBYTES('SHA2_256',@numTarjeta),2), RIGHT(@numTarjeta, 4)
	FROM MLJ.Reservas
	WHERE cod_reserva = @cod_reserva

	RETURN SCOPE_IDENTITY()	
END	
GO

CREATE PROCEDURE MLJ.buscarCabinasDePasaje(@cod_pasaje INT)
AS BEGIN
	SELECT c.cod_cabina, c.cod_crucero, c.cod_tipo, c.nro, c.piso
	FROM MLJ.Cabinas_reservadas cr 
		JOIN MLJ.Cabinas c ON cr.cod_cabina = c.cod_cabina 
	WHERE cr.cod_pasaje = @cod_pasaje
END
GO

CREATE VIEW MLJ.Reservas_pendientes
AS
SELECT cod_pasaje, cod_reserva, fecha_reserva
FROM MLJ.Reservas
WHERE cod_pasaje NOT IN (SELECT cod_pasaje FROM MLJ.Pagos)
WITH CHECK OPTION
GO

CREATE PROCEDURE MLJ.eliminarReservasVencidas(@hoy DATE)
AS BEGIN
	SELECT cod_pasaje
	INTO #borrar
	FROM MLJ.Reservas_pendientes
	WHERE DATEADD(DAY, 3, fecha_reserva) <= @hoy

	BEGIN TRANSACTION
		DELETE FROM MLJ.Cabinas_reservadas
		WHERE cod_pasaje IN (SELECT cod_pasaje FROM #borrar)

		DELETE FROM MLJ.Reservas
		WHERE cod_pasaje IN (SELECT cod_pasaje FROM #borrar)

		DELETE FROM MLJ.Pasajes
		WHERE cod_pasaje IN (SELECT cod_pasaje FROM #borrar)
	COMMIT TRANSACTION
END
GO

--Listado estadistico

CREATE FUNCTION MLJ.DiasDeshabilitado(@anio int,@fecha_comienzo_semestre datetime,@fecha_fin_semestre datetime, @cod_crucero INT)
RETURNS INT
AS 
BEGIN

	DECLARE @DiasFueraDeServicio INT

	SELECT @DiasFueraDeServicio = coalesce(SUM(tabla.DiasFueraDeServicio),0) FROM(
					SELECT 
					CASE WHEN fecha_baja < @fecha_comienzo_semestre AND YEAR(fecha_alta) = @anio 
					AND fecha_alta <= @fecha_fin_semestre AND fecha_alta >= @fecha_comienzo_semestre THEN DATEDIFF(DAY, @fecha_comienzo_semestre, fecha_alta)
					WHEN fecha_baja >= @fecha_comienzo_semestre AND fecha_alta <= @fecha_fin_semestre THEN DATEDIFF(DAY, fecha_baja, fecha_alta)
					WHEN YEAR(fecha_baja) = @anio  AND (fecha_baja >= @fecha_comienzo_semestre)
						AND fecha_alta >= @fecha_fin_semestre THEN DATEDIFF(DAY, fecha_baja, @fecha_fin_semestre)
					END AS DiasFueraDeServicio
	FROM MLJ.Bajas_de_servicio
	WHERE cod_crucero = @cod_crucero AND permanente = 0) AS tabla

	RETURN @DiasFueraDeServicio
END
GO

CREATE PROCEDURE MLJ.top5_cruceros @anio int, @semestre int
AS
BEGIN	
	
DECLARE @mes_comienzo_semestre int
DECLARE @mes_fin_semestre int
DECLARE @fecha_comienzo_semestre datetime
DECLARE @fecha_fin_semestre datetime
	
	IF @semestre = 1	
	BEGIN	
	SET @mes_comienzo_semestre = 1	
	SET @mes_fin_semestre = 6
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 30, 0, 0, 0, 0)		
	END
	
	IF @semestre = 2	
	BEGIN	
	SET @mes_comienzo_semestre = 7	
	SET @mes_fin_semestre = 12	
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 31, 0, 0, 0, 0)
	END

SELECT TOP 5 cruceros.cod_crucero,cruceros.identificador,fabricantes.nombre fabricante,modelos.nombre modelo, MLJ.DiasDeshabilitado(@anio,@fecha_comienzo_semestre,@fecha_fin_semestre,cruceros.cod_crucero) dias_fuera_servicio
FROM MLJ.Cruceros cruceros JOIN MLJ.Fabricantes fabricantes ON (fabricantes.cod_fabricante = cruceros.cod_fabricante)
JOIN MLJ.Modelos modelos ON (modelos.cod_modelo = cruceros.cod_modelo)
ORDER BY dias_fuera_servicio DESC
END
GO

CREATE FUNCTION MLJ.PasajesVendidosRecorrido(@anio int,@fecha_comienzo_semestre datetime,@fecha_fin_semestre datetime, @cod_recorrido INT)
RETURNS INT
AS 
BEGIN

	DECLARE @PasajesVendidos INT

	SELECT @PasajesVendidos = coalesce(COUNT(cod_pasaje),0)
					FROM MLJ.Pasajes
					WHERE cod_viaje IN (SELECT viajes.cod_viaje
							   FROM MLJ.Viajes viajes
							   WHERE (viajes.cod_recorrido = @cod_recorrido) AND YEAR(viajes.fecha_inicio) = @anio
							   AND (viajes.fecha_inicio >= @fecha_comienzo_semestre) AND (viajes.fecha_inicio <= @fecha_fin_semestre))
	
	RETURN @PasajesVendidos
END
GO

CREATE PROCEDURE MLJ.top5_recorridos @anio int, @semestre int
AS
BEGIN	
	
DECLARE @mes_comienzo_semestre int
DECLARE @mes_fin_semestre int
DECLARE @fecha_comienzo_semestre datetime
DECLARE @fecha_fin_semestre datetime
	
	IF @semestre = 1	
	BEGIN	
	SET @mes_comienzo_semestre = 1	
	SET @mes_fin_semestre = 6
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 30, 0, 0, 0, 0)		
	END
	
	IF @semestre = 2	
	BEGIN	
	SET @mes_comienzo_semestre = 7	
	SET @mes_fin_semestre = 12	
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 31, 0, 0, 0, 0)
	END

SELECT TOP 5 cod_recorrido, habilitado, MLJ.PasajesVendidosRecorrido(@anio,@fecha_comienzo_semestre,@fecha_fin_semestre,cod_recorrido) pasajes_vendidos
FROM MLJ.recorridos
ORDER BY pasajes_vendidos DESC
END
GO

CREATE FUNCTION MLJ.CabinasLibresRecorrido(@anio int,@fecha_comienzo_semestre datetime,@fecha_fin_semestre datetime, @cod_recorrido INT)
RETURNS INT
AS 
BEGIN

	DECLARE @CabinasLibres INT

	SELECT @CabinasLibres = coalesce(MAX(tabla.CabinasLibres),0) FROM(
	SELECT ((SELECT COUNT(cabinas.cod_cabina)
    				FROM MLJ.Cabinas cabinas WHERE cabinas.cod_crucero = (SELECT cod_crucero FROM MLJ.Viajes WHERE cod_viaje = pasajes.cod_viaje)) - COUNT(cabinas_reservadas.cod_cabina)) AS CabinasLibres
	FROM MLJ.Pasajes pasajes JOIN MLJ.Cabinas_reservadas cabinas_reservadas ON (pasajes.cod_pasaje = cabinas_reservadas.cod_pasaje)
	WHERE pasajes.cod_viaje IN (SELECT viajes.cod_viaje
							   FROM MLJ.Viajes viajes
							   WHERE (viajes.cod_recorrido = @cod_recorrido) AND YEAR(viajes.fecha_inicio) = @anio
							   AND (viajes.fecha_inicio >= @fecha_comienzo_semestre) AND (viajes.fecha_inicio <= @fecha_fin_semestre))
	GROUP BY pasajes.cod_viaje) AS tabla

	RETURN @CabinasLibres
END
GO

CREATE PROCEDURE MLJ.top5_recorridosLibres @anio int, @semestre int
AS
BEGIN	
	
DECLARE @mes_comienzo_semestre int
DECLARE @mes_fin_semestre int
DECLARE @fecha_comienzo_semestre datetime
DECLARE @fecha_fin_semestre datetime
	
	IF @semestre = 1	
	BEGIN	
	SET @mes_comienzo_semestre = 1	
	SET @mes_fin_semestre = 6
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 30, 0, 0, 0, 0)		
	END
	
	IF @semestre = 2	
	BEGIN	
	SET @mes_comienzo_semestre = 7	
	SET @mes_fin_semestre = 12	
	SET @fecha_comienzo_semestre = DATETIMEFROMPARTS(@anio, @mes_comienzo_semestre, 1, 0, 0, 0, 0)
	SET @fecha_fin_semestre = DATETIMEFROMPARTS(@anio, @mes_fin_semestre, 31, 0, 0, 0, 0)
	END

SELECT TOP 5 cod_recorrido, habilitado, MLJ.CabinasLibresRecorrido(@anio,@fecha_comienzo_semestre,@fecha_fin_semestre,cod_recorrido) pasajes_vendidos
FROM MLJ.recorridos
ORDER BY pasajes_vendidos DESC
END
GO


--ABM de Cruceros

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
	IF EXISTS (SELECT * FROM MLJ.Bajas_de_servicio WHERE cod_crucero = @codCrucero)
	BEGIN
		UPDATE MLJ.Bajas_de_servicio
		SET fecha_baja = @fechaBaja
		WHERE cod_crucero = @codCrucero AND permanente = 1
	END
	ELSE
	BEGIN
		INSERT INTO MLJ.Bajas_de_servicio
		(permanente, cod_crucero, fecha_baja)
		VALUES
		(1, @codCrucero, @fechaBaja)
	END
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

	SELECT cr.cod_pasaje, c.cod_cabina, c.cod_tipo, v.cod_viaje
	INTO #cabinasAReemplazar
	FROM MLJ.Viajes v JOIN MLJ.Pasajes p ON v.cod_viaje = p.cod_viaje 
						JOIN MLJ.Cabinas_reservadas cr ON p.cod_pasaje = cr.cod_pasaje
						JOIN MLJ.Cabinas c ON c.cod_cabina = cr.cod_cabina
	WHERE v.cod_crucero = @codCruceroBajado AND (@fechaBaja <= fecha_inicio OR @fechaBaja < fecha_fin)

	UPDATE MLJ.Viajes
	SET cod_crucero = @codCruceroReemplazante
	WHERE cod_viaje IN (SELECT DISTINCT cod_viaje FROM #cabinasAReemplazar)
	
	DECLARE cur CURSOR FOR SELECT cod_pasaje, cod_cabina, cod_tipo, cod_viaje FROM #cabinasAReemplazar

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
	WHERE cod_crucero = @codCrucero AND (@fechaBaja <= fecha_inicio OR fecha_inicio <= @fechaAlta)
	
	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.cancelacionPorBajaTemporal(@fechaBaja DATE, @fechaAlta DATE, @codCrucero INT, @razon VARCHAR(255))
AS BEGIN
	
	BEGIN TRANSACTION

	INSERT INTO MLJ.Bajas_de_servicio
	(permanente, cod_crucero, fecha_baja, fecha_alta)
	VALUES
	(0, @codCrucero, @fechaBaja, @fechaAlta)

	UPDATE MLJ.Viajes
	SET razon_de_cancelacion = @razon
	WHERE cod_crucero = @codCrucero AND (@fechaBaja <= fecha_inicio OR fecha_inicio <= @fechaAlta)
	
	COMMIT TRANSACTION
END
GO

CREATE PROCEDURE MLJ.buscarPosibleReemplazos(@codCrucero INT, @fechaBaja DATE)
AS BEGIN
	DECLARE @codModelo INT, @codServicio INT

	SELECT @codModelo = cod_modelo, @codServicio = cod_servicio
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

	-- Crucero reemplazante debe tener mismos datos de tipo (Hecho), cantidad y tipos de cabinas (Hecho), y disponibilidad de fecha (Hecho)
	SELECT c.cod_crucero, c.cod_fabricante, c.cod_marca, c.cod_modelo, c.cod_servicio, c.identificador, c.fecha_alta, cod_tipo, COUNT(cod_tipo) cantidad_tipo
	INTO #crucerosDisponiblesDeMismoTipo
	FROM MLJ.Cruceros c JOIN MLJ.Cabinas cabs ON cabs.cod_crucero = c.cod_crucero
	WHERE c.cod_crucero != @codCrucero AND cod_modelo = @codModelo 
		  AND cod_servicio = @codServicio AND 
		  NOT EXISTS (SELECT TOP 1 *
					  FROM MLJ.Viajes v 
					  WHERE v.cod_crucero = c.cod_crucero AND
							EXISTS (SELECT TOP 1 * 
									FROM #fechaNecesario f 
									WHERE f.fecha_inicio BETWEEN v.fecha_inicio AND v.fecha_fin 
										  OR v.fecha_inicio BETWEEN f.fecha_inicio AND f.fecha_fin)) 
	GROUP BY c.cod_crucero, c.cod_fabricante, c.cod_marca, c.cod_modelo, c.cod_servicio, c.identificador, c.fecha_alta, cod_tipo
	

	SELECT DISTINCT cod_crucero, cod_fabricante, cod_marca, cod_modelo, cod_servicio, identificador, fecha_alta
	FROM #crucerosDisponiblesDeMismoTipo cd JOIN #cantidadCabinas cc ON cd.cod_tipo = cc.cod_tipo
	WHERE cd.cantidad_tipo >= cc.cantidad
	GROUP BY cod_crucero, cod_fabricante, cod_marca, cod_modelo, cod_servicio, identificador, fecha_alta
	HAVING COUNT(*) = (SELECT COUNT(*) FROM #cantidadCabinas)
END