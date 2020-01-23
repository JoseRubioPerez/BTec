CREATE PROCEDURE [dbo].[ActualizarAreas] @IdArea AS TINYINT
, @IdGuid AS UNIQUEIDENTIFIER
, @Area AS VARCHAR(100) = ''
, @IdEstaActivo AS BIT = 0
, @IdAdminActualizacion AS TINYINT = 0
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @IdArea <> 0
    AND @Area <> ''
    AND @IdAdminActualizacion <> 0
    AND @FechaActualizacion <> NULL
  BEGIN

    UPDATE dbo.AREAS
    SET IdGuid = @IdGuid,
        Area = @Area,
        IdEstaActivo = @IdEstaActivo,
        IdAdminActualizacion = @IdAdminActualizacion,
        FechaActualizacion = @FechaActualizacion
    WHERE IdArea = @IdArea;
  END
END
GO
