CREATE PROCEDURE [dbo].[ActualizarServicios] @IdServicio AS TINYINT
, @IdGuid AS UNIQUEIDENTIFIER
, @Servicio AS VARCHAR(50) = ''
, @IdEstaActivo AS BIT = 0
, @IdAdminActualizacion AS TINYINT = 0
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @IdServicio <> 0
    AND @IdAdminActualizacion <> 0
    AND @FechaActualizacion <> NULL
  BEGIN

    UPDATE dbo.SERVICIOS
    SET IdGuid = @IdGuid,
		Servicio = @Servicio,
        IdEstaActivo = @IdEstaActivo,
        IdAdminActualizacion = @IdAdminActualizacion,
        FechaActualizacion = @FechaActualizacion
    WHERE IdServicio = @IdServicio;
  END
END
GO
