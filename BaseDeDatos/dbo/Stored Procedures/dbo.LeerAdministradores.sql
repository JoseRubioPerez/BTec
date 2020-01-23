CREATE PROCEDURE [dbo].[LeerAdministradores] @Consulta AS TINYINT = 1
, @IdAdministrador TINYINT OUTPUT
, @IdGuid UNIQUEIDENTIFIER OUTPUT
, @NumeroControl VARCHAR(9) OUTPUT
, @Contrasenia VARBINARY(8000)
, @Nombres VARCHAR(100) OUTPUT
, @Paterno VARCHAR(50) OUTPUT
, @Materno VARCHAR(50) OUTPUT
, @UrlFoto VARCHAR(200) OUTPUT
, @IdGenero TINYINT OUTPUT
, @IdEditable BIT OUTPUT
, @IdEstaActivo BIT OUTPUT

, @IdAdminCreacion AS INT OUTPUT
, @NumeroControlCreacion AS VARCHAR(50) OUTPUT
, @FechaCreacion AS DATETIME OUTPUT

, @IdAdminActualizacion AS INT OUTPUT
, @NumeroControlActualizacion AS VARCHAR(50) OUTPUT
, @FechaActualizacion AS DATETIME OUTPUT

, @FechaInicio AS DATETIME = NULL
, @FechaFin AS DATETIME = NULL
, @BuscarTodosLosEstados AS BIT = 0
AS
BEGIN
  DECLARE @BusquedaMasiva AS TINYINT = 1
		,@BusquedaIndividual AS TINYINT = 2
		,@NoEstaActivo AS BIT = 0
		,@EstaActivo AS BIT = 1
		,@BuscarTodo AS TINYINT = 0
		,@RespuestaSi AS BIT = 1;

	SET @IdAdministrador = ISNULL(@IdAdministrador, 0);
	SET @IdEstaActivo = ISNULL(@IdEstaActivo, 1);

	DECLARE @IdAdministradorInicio AS TINYINT = IIF(@IdAdministrador = @BuscarTodo, 0, @IdAdministrador)
		,@IdAdministradorFin AS TINYINT = IIF(@IdAdministrador = @BuscarTodo, 255, @IdAdministrador);

	SET @FechaInicio = ISNULL(@FechaInicio, CAST('1900-01-01' AS DATETIME));
	SET @FechaFin = ISNULL(@FechaFin, CAST('2100-01-01' AS DATETIME));

	IF @Consulta = @BusquedaMasiva
	BEGIN
		SELECT a.IdAdministrador
			,a.IdGuid
			,a.NumeroControl
			,a.Nombres
			,a.Paterno
			,a.Materno
			,a.UrlFoto
			,a.IdGenero
			,a.IdEditable
			,a.IdEstaActivo
			,IIF(a.IdEstaActivo = @EstaActivo, 'ACTIVO', 'INACTIVO') AS EstaActivo
			,a.IdAdminCreacion
			,uc.NumeroControl AS NumeroControlCreacion
			,a.FechaCreacion
			,a.IdAdminActualizacion
			,ua.NumeroControl AS NumeroControlActualizacion
			,a.FechaActualizacion
		FROM dbo.ADMINISTRADORES AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdEstaActivo BETWEEN IIF(@BuscarTodosLosEstados = @RespuestaSi, @NoEstaActivo, @IdEstaActivo)
				AND IIF(@BuscarTodosLosEstados = @RespuestaSi, @EstaActivo, @IdEstaActivo)
			AND a.IdAdministrador BETWEEN @IdAdministradorInicio
				AND @IdAdministradorFin
			AND a.FechaCreacion BETWEEN @FechaInicio
				AND @FechaFin
		ORDER BY a.IdAdministrador;
	END
	ELSE IF @Consulta = @BusquedaIndividual
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@NumeroControl = a.NumeroControl
			,@Nombres = a.Nombres
			,@Paterno = a.Paterno
			,@Materno = a.Materno
			,@UrlFoto = a.UrlFoto
			,@IdGenero = a.IdGenero
			,@IdEditable = a.IdEditable
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@NumeroControlCreacion = uc.NumeroControl
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@NumeroControlActualizacion = ua.NumeroControl
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.ADMINISTRADORES AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdAdministrador = @IdAdministrador
		ORDER BY a.IdAdministrador;
	END
END
GO
