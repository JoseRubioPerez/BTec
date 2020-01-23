CREATE PROCEDURE [dbo].[GraficaMovimientos]
AS
BEGIN
  SELECT
    a.IdServicio,
    b.Servicio,
    COUNT(a.IdMovimiento) AS Total
  FROM dbo.MOVIMIENTOS AS a
  INNER JOIN dbo.SERVICIOS AS b
    ON b.IdServicio = a.IdServicio
  GROUP BY a.IdServicio,
           b.Servicio
  ORDER BY a.IdServicio
END
GO
