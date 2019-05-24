USE GD1C2019

--Migro los datos de "tipo", para las migraciones posteriores pueden recuperarse con el nombre
INSERT INTO MLJ.tipo_cabinas
(valor, nombre)
SELECT DISTINCT CABINA_TIPO_PORC_RECARGO, CABINA_TIPO 
FROM gd_esquema.Maestra

INSERT INTO MLJ.modelos
(nombre)
SELECT DISTINCT CRUCERO_MODELO
FROM gd_esquema.Maestra

INSERT INTO MLJ.fabricantes
(nombre)
SELECT DISTINCT CRU_FABRICANTE
FROM gd_esquema.Maestra

-- Migro la información de los clientes, para recuperar a uno hay que usar el DNI + Apellido
INSERT INTO MLJ.clientes
(nombre, apellido, dni, direccion, telefono, mail, nacimiento)
SELECT DISTINCT CLI_NOMBRE, CLI_APELLIDO, CLI_DNI, CLI_DIRECCION, CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC
FROM gd_esquema.Maestra