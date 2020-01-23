CREATE PROCEDURE [dbo].[CrearServicios] @IdServicio AS TINYINT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER OUTPUT
, @Servicio AS VARCHAR(50) = ''
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @FechaCreacion AS DATETIME = NULL
AS
BEGIN
  IF @IdAdminCreacion <> 0
  BEGIN

    SET @IdGuid = NEWID();

    INSERT INTO dbo.SERVICIOS (IdGuid,
    Servicio,
    IdEstaActivo,
    IdAdminCreacion,
    FechaCreacion,
    IdAdminActualizacion,
    FechaActualizacion)
      VALUES (@IdGuid, @Servicio, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminCreacion, @FechaCreacion);

    SET @IdServicio = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdServicio = 0;
    SET @IdGuid = NULL;
  END
END
GO
