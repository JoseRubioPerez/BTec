CREATE PROCEDURE [dbo].[IniciarSesion]
    @NumeroControl AS VARCHAR(9) = '',
    @Contrasenia AS VARCHAR(200) = '',
    @Resultado AS BIT OUTPUT
AS
BEGIN
    DECLARE @EstaActivo AS BIT = 1,
            @IdAdministrador AS TINYINT = 0;

    SET @Resultado = 0;

    SELECT @IdAdministrador = a.IdAdministrador
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
