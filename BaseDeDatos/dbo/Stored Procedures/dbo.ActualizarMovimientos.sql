CREATE PROCEDURE [dbo].[ActualizarMovimientos] @IdMovimiento AS INT
, @IdGuid AS UNIQUEIDENTIFIER
, @IdUsuario AS INT = 0
, @IdServicio AS TINYINT = 0
, @IdEstaActivo AS BIT = 0
, @IdAdminActualizacion AS TINYINT = 0
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @IdUsuario <> 0
    AND @IdServicio <> 0
    AND @IdAdminActualizacion <> 0
    AND @FechaActualizacion <> NULL
  BEGIN

    UPDATE dbo.MOVIMIENTOS
    SET IdGuid = @IdGuid,
		IdUsuario = @IdUsuario,
        IdServicio = @IdServicio,
        IdEstaActivo = @IdEstaActivo,
        IdAdminActualizacion = @IdAdminActualizacion,
        FechaActualizacion = @FechaActualizacion
    WHERE IdMovimiento = @IdMovimiento;
  END
END
GO
