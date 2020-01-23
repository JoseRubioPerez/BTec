CREATE PROCEDURE [dbo].[CrearUsuarios] @IdUsuario AS INT OUTPUT
, @IdGuid AS UNIQUEIDENTIFIER
, @NumeroControl AS VARCHAR(9) = ''
, @Nombres AS VARCHAR(100) = ''
, @Paterno AS VARCHAR(50) = ''
, @Materno AS VARCHAR(50) = ''
, @IdArea AS TINYINT = 0
, @UrlFoto AS VARCHAR(200) = ''
, @IdGenero AS TINYINT = 0
, @IdEstaActivo AS BIT = 0
, @IdAdminCreacion AS TINYINT = 0
, @FechaCreacion AS DATETIME = NULL
AS
BEGIN
  IF @NumeroControl <> ''
    AND @Nombres <> ''
    AND @Paterno <> ''
    AND @IdGenero <> 0
    AND @IdAdminCreacion <> 0
  BEGIN

    SET @IdGuid = NEWID();

    INSERT INTO dbo.USUARIOS (IdGuid,
    NumeroControl,
    Nombres,
    Paterno,
    Materno,
    IdArea,
    UrlFoto,
    IdGenero,
    IdEstaActivo,
    IdAdminCreacion,
    FechaCreacion,
    IdAdminActualizacion,
    FechaActualizacion)
      VALUES (@IdGuid, @NumeroControl, @Nombres, @Paterno, @Materno, @IdArea, @UrlFoto, @IdGenero, @IdEstaActivo, @IdAdminCreacion, @FechaCreacion, @IdAdminCreacion, @FechaCreacion);

    SET @IdUsuario = @@IDENTITY;
  END
  ELSE
  BEGIN
    SET @IdUsuario = 0;
    SET @IdGuid = NULL;
  END
END
GO
