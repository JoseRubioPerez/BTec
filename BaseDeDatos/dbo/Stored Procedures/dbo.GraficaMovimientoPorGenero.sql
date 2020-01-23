
CREATE PROCEDURE [dbo].[GraficaMovimientoPorGenero]
AS
BEGIN
  SELECT
    COUNT(a.IdMovimiento) AS Conteo,
    b.IdGenero,
    a.IdServicio,
    c.Servicio
  FROM dbo.MOVIMIENTOS AS a
  INNER JOIN dbo.USUARIOS AS b
    ON b.IdUsuario = a.IdUsuario
  INNER JOIN dbo.SERVICIOS AS c
    ON c.IdServicio = a.IdServicio
  WHERE a.IdEstaActivo = 1
  GROUP BY b.IdGenero,
           a.IdServicio,
           c.Servicio
  ORDER BY b.IdGenero, a.IdServicio
END
GO
