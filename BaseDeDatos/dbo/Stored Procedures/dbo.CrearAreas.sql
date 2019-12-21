SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[CrearAreas] @IdArea AS TINYINT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER OUTPUT
, @Area AS VARCHAR(100) = ''
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @NumeroControlCreacion AS VARCHAR(9) = ''
, @FechaCreacion AS DATETIME = NULL
, @IdAdminActualizacion AS TINYINT = 0
, @NumeroControlActualizacion AS VARCHAR(9) = ''
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @IdArea <> 0
	AND @Area <> ''
	AND @IdAdminCreacion <> 0
    AND @IdAdminActualizacion <> 0
    AND @FechaCreacion <> NULL
    AND @FechaActualizacion <> NULL
  BEGIN

    SET @IdGuid = NEWID();

    INSERT INTO dbo.AREAS (IdGuid,
    Area,
    IdEstaActivo,
    IdAdminCreacion,
    FechaCreacion,
    IdAdminActualizacion,
    FechaActualizacion)
      VALUES (@IdGuid, @Area, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminActualizacion, @FechaActualizacion);

    SET @IdArea = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdArea = 0;
    SET @IdGuid = NULL;
  END
END
GO
