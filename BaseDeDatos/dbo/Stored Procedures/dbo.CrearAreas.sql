CREATE PROCEDURE [dbo].[CrearAreas] @IdArea AS TINYINT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER OUTPUT
, @Area AS VARCHAR(100) = ''
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @FechaCreacion AS DATETIME = NULL
AS
BEGIN
  IF @Area <> ''
	AND @IdAdminCreacion <> 0
  BEGIN

    SET @IdGuid = NEWID();

    INSERT INTO dbo.AREAS (IdGuid,
    Area,
    IdEstaActivo,
    IdAdminCreacion,
    FechaCreacion,
    IdAdminActualizacion,
    FechaActualizacion)
      VALUES (@IdGuid, @Area, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminCreacion, @FechaCreacion);

    SET @IdArea = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdArea = 0;
    SET @IdGuid = NULL;
  END
END
GO
