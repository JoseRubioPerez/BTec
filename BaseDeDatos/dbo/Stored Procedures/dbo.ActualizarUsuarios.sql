CREATE PROCEDURE [dbo].[ActualizarUsuarios] @IdUsuario AS INT
, @IdGuid AS UNIQUEIDENTIFIER
, @NumeroControl AS VARCHAR(9) = ''
, @Nombres AS VARCHAR(100) = ''
, @Paterno AS VARCHAR(50) = ''
, @Materno AS VARCHAR(50) = ''
, @IdArea AS TINYINT = 0
, @UrlFoto AS VARCHAR(200) = ''
, @IdGenero AS TINYINT = 0
, @IdEstaActivo AS BIT = 0
, @IdAdminActualizacion AS TINYINT = 0
, @FechaActualizacion AS DATETIME = NULL
AS
BEGIN
  IF @NumeroControl <> ''
    AND @Nombres <> ''
    AND @Paterno <> ''
    AND @IdGenero <> 0
    AND @IdAdminActualizacion <> 0
    AND @FechaActualizacion <> NULL
  BEGIN

    UPDATE dbo.USUARIOS
    SET IdGuid = @IdGuid,
		NumeroControl = @NumeroControl,
        Nombres = @Nombres,
        Paterno = @Paterno,
        Materno = @Materno,
        IdArea = @IdArea,
        UrlFoto = @UrlFoto,
        IdGenero = @IdGenero,
        IdEstaActivo = @IdEstaActivo,
        IdAdminActualizacion = @IdAdminActualizacion,
        FechaActualizacion = @FechaActualizacion
    WHERE IdUsuario = @IdUsuario;
  END
END
GO
