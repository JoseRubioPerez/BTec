CREATE PROCEDURE [dbo].[IniciarSesion] @IdAdministrador TINYINT OUTPUT
, @IdGuid UNIQUEIDENTIFIER OUTPUT
, @NumeroControl AS VARCHAR(9) = ''
, @Contrasenia AS VARCHAR(200) = ''
, @Nombres VARCHAR(100) OUTPUT
, @Paterno VARCHAR(50) OUTPUT
, @Materno VARCHAR(50) OUTPUT
, @UrlFoto VARCHAR(200) OUTPUT
, @IdGenero TINYINT OUTPUT
, @IdEditable BIT OUTPUT
, @IdEstaActivo BIT OUTPUT

, @IdAdminCreacion AS INT OUTPUT
, @FechaCreacion AS DATETIME OUTPUT

, @IdAdminActualizacion AS INT OUTPUT
, @FechaActualizacion AS DATETIME OUTPUT

, @Resultado AS BIT OUTPUT
AS
BEGIN
  DECLARE @EstaActivo AS BIT = 1;

  SET @Resultado = 0;

  SELECT
    @IdAdministrador = a.IdAdministrador,
    @IdGuid = a.IdGuid,
    @Nombres = a.Nombres,
    @Paterno = a.Paterno,
    @Materno = a.Materno,
    @UrlFoto = a.UrlFoto,
    @IdGenero = a.IdGenero,
    @IdEditable = a.IdEditable,
    @IdEstaActivo = a.IdEstaActivo,
    @IdAdminCreacion = a.IdAdminCreacion,
    @FechaCreacion = a.FechaCreacion,
    @IdAdminActualizacion = a.IdAdminActualizacion,
    @FechaActualizacion = a.FechaActualizacion
  FROM dbo.ADMINISTRADORES AS a
  WHERE a.NumeroControl = @NumeroControl
  AND a.Contrasenia = CONVERT(VARBINARY(8000), '0x' + @Contrasenia, 1)
  AND a.IdEstaActivo = @EstaActivo;

  IF @IdAdministrador > 0
  BEGIN
    SET @Resultado = 1;
  END;
END;
GO
