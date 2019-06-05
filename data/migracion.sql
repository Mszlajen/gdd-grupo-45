USE GD1C2019

--Creo el indice para buscar los clientes por su DNI 
CREATE INDEX DNI ON MLJ.Clientes(dni)

--Creo el indice para buscar usuarios
CREATE INDEX USUARIO ON MLJ.Usuarios(usuario)

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

INSERT INTO MLJ.Servicios
(nombre)
VALUES
('No definido')

INSERT INTO MLJ.Marcas
(nombre)
VALUES
('No definido')

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
(identificador, cod_fabricante, cod_modelo, cod_modelo, cod_marca)
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

--Agrego medios de pago
INSERT INTO MLJ.Medios_de_Pago
(nombre)
VALUES
('MasterCard'), 
('VISA')