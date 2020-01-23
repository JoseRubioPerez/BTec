CREATE PROCEDURE [dbo].[CrearMovimientos] @IdMovimiento AS INT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER OUTPUT
, @IdUsuario AS INT = 0
, @IdServicio AS TINYINT = 0
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @FechaCreacion AS DATETIME = NULL
AS
BEGIN
  IF @IdUsuario <> 0
    AND @IdServicio <> 0
	AND @IdAdminCreacion <> 0
  BEGIN

    SET @IdGuid = NEWID();

    INSERT INTO dbo.MOVIMIENTOS (IdUsuario,
    IdGuid,
    IdServicio,
    IdEstaActivo,
    IdAdminCreacion,
    FechaCreacion,
    IdAdminActualizacion,
    FechaActualizacion)
      VALUES (@IdUsuario, @IdGuid, @IdServicio, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminCreacion, @FechaCreacion);

    SET @IdMovimiento = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdMovimiento = 0;
    SET @IdGuid = NULL;
  END
END
GO
