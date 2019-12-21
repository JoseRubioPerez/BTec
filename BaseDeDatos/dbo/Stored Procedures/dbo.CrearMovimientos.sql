SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[CrearMovimientos] @IdMovimiento AS INT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER OUTPUT
, @IdUsuario AS INT = 0
, @IdServicio AS TINYINT = 0
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @NumeroControlCreacion AS VARCHAR(9) = ''
, @FechaCreacion AS DATETIME = NULL
, @IdAdminActualizacion AS TINYINT = 0
, @NumeroControlActualizacion AS VARCHAR(9) = ''
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @IdUsuario <> 0
    AND @IdServicio <> 0
	AND @IdAdminCreacion <> 0
    AND @IdAdminActualizacion <> 0
    AND @FechaCreacion <> NULL
    AND @FechaActualizacion <> NULL
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
      VALUES (@IdUsuario, @IdGuid, @IdServicio, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminActualizacion, @FechaActualizacion);

    SET @IdMovimiento = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdMovimiento = 0;
    SET @IdGuid = NULL;
  END
END
GO
