DROP TABLE #temp

CREATE TABLE #temp (
 cod INT,
 tipo INT,
 value INT)

 INSERT INTO #temp
 (cod, tipo, value)
 VALUES (1, 1, 3), (1, 2, 2)

 SELECT DISTINCT cod
 FROM #temp
 WHERE tipo != 1
 GROUP BY cod
 HAVING SUM(value) < 3