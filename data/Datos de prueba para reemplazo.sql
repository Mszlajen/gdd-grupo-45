INSERT INTO MLJ.Cruceros
(identificador, cod_marca, cod_modelo, cod_fabricante, cod_servicio)
VALUES 
('inicial', 1, 1, 1, 1),
('fallo por fecha superpuesta', 1, 1, 1, 1),
('solo viajes antes', 1, 1, 1, 1),
('viajes antes y despues sin superposicion', 1, 1, 1, 1),
('Menos cabinas', 1, 1, 1, 1),
('Igual cabinas', 1, 1, 1, 1),
('Mas cabinas', 1, 1, 1, 1)

SELECT TOP 7 * FROM MLJ.Cruceros ORDER BY cod_crucero DESC

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
VALUES
(41, 1, 1, 1),
(41, 2, 1, 2),
(41, 3, 1, 2),
(41, 4, 1, 3),
(41, 5, 1, 3),
(41, 6, 1, 3),
(41, 7, 1, 4)

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
SELECT 42, nro, piso, cod_tipo
FROM MLJ.Cabinas
WHERE cod_crucero = 41

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
SELECT 43, nro, piso, cod_tipo
FROM MLJ.Cabinas
WHERE cod_crucero = 41

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
SELECT 44, nro, piso, cod_tipo
FROM MLJ.Cabinas
WHERE cod_crucero = 41

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
VALUES
(45, 1, 1, 1),
(45, 3, 1, 2),
(45, 4, 1, 3),
(45, 6, 1, 3),
(45, 7, 1, 4)

INSERT INTO MLJ.Cabinas
(cod_crucero, nro, piso, cod_tipo)
VALUES
(47, 1, 1, 1),
(47, 2, 1, 2),
(47, 3, 1, 2),
(47, 4, 1, 3),
(47, 5, 1, 3),
(47, 6, 1, 3),
(47, 7, 1, 4),
(47, 8, 1, 4),
(47, 9, 1, 4),
(47, 10, 1, 4),
(47, 11, 1, 5)

INSERT INTO MLJ.Viajes
(cod_crucero, cod_recorrido, retorna, fecha_inicio, fecha_fin)
VALUES
(41, 1, 0, '20190610', '20190612'),
(41, 1, 0, '20190620', '20190623'),
(41, 1, 0, '20190606', '20190608'),
(42, 1, 0, '20190621', '20190624'),
(43, 1, 0, '20190501', '20190503'),
(44, 1, 0, '20190501', '20190503'),
(44, 1, 0, '20190801', '20190812')

SELECT TOP 7 * FROM MLJ.Viajes ORDER BY cod_viaje DESC

INSERT INTO MLJ.Pasajes
(cod_viaje, cod_cliente, cantidad)
VALUES
(4972, 1, 1),
(4974, 1, 1)

SELECT TOP 2 * FROM MLJ.Pasajes ORDER BY cod_pasaje DESC
SELECT * FROM MLJ.Cabinas WHERE cod_crucero = 41

INSERT INTO MLJ.Cabinas_reservadas
(cod_pasaje, cod_cabina)
SELECT 245711, cod_cabina
FROM MLJ.Cabinas
WHERE cod_crucero = 41

INSERT INTO MLJ.Cabinas_reservadas
(cod_pasaje, cod_cabina)
SELECT 245710, cod_cabina
FROM MLJ.Cabinas
WHERE cod_crucero = 41