CREATE PROCEDURE [dbo].[LeerUsuarios] @Consulta AS TINYINT = 1
	,@IdUsuario AS INT OUTPUT
	,@IdGuid AS UNIQUEIDENTIFIER OUTPUT
	,@NumeroControl AS VARCHAR(9) OUTPUT
	,@Nombres AS VARCHAR(100) OUTPUT
	,@Paterno AS VARCHAR(50) OUTPUT
	,@Materno AS VARCHAR(50) OUTPUT
	,@IdArea AS TINYINT OUTPUT
	,@UrlFoto AS VARCHAR(200) OUTPUT
	,@IdGenero AS TINYINT OUTPUT
	,@IdEstaActivo AS BIT OUTPUT

	,@IdAdminCreacion AS INT OUTPUT
	,@NumeroControlCreacion AS VARCHAR(50) OUTPUT
	,@FechaCreacion AS DATETIME OUTPUT

	,@IdAdminActualizacion AS INT OUTPUT
	,@NumeroControlActualizacion AS VARCHAR(50) OUTPUT
	,@FechaActualizacion AS DATETIME OUTPUT

	,@FechaInicio AS DATETIME = NULL
	,@FechaFin AS DATETIME = NULL
	,@BuscarTodosLosEstados AS BIT = 0
AS
BEGIN

	DECLARE @BusquedaMasiva AS TINYINT = 1
		,@BusquedaIndividual AS TINYINT = 2
		,@BusquedaIndividualPorParametro AS TINYINT = 3
		,@NoEstaActivo AS BIT = 0
		,@EstaActivo AS BIT = 1
		,@BuscarTodo AS INT = 0
		,@RespuestaSi AS BIT = 1
		,@Masculino AS TINYINT = 1;

	SET @IdUsuario = ISNULL(@IdUsuario, 0);
	SET @IdEstaActivo = ISNULL(@IdEstaActivo, 1);

	DECLARE @IdUsuarioInicio AS INT = IIF(@IdUsuario = @BuscarTodo, 0, @IdUsuario)
		,@IdUsuarioFin AS INT = IIF(@IdUsuario = @BuscarTodo, 1000000, @IdUsuario);

	SET @FechaInicio = ISNULL(@FechaInicio, CAST('1900-01-01' AS DATETIME));
	SET @FechaFin = ISNULL(@FechaFin, CAST('2100-01-01' AS DATETIME));

	IF @Consulta = @BusquedaMasiva
	BEGIN
		SELECT a.IdUsuario
			,a.IdGuid
			,a.NumeroControl
			,a.Nombres
			,a.Paterno
			,a.Materno
			,a.IdArea
			,b.Area
			,a.UrlFoto
			,a.IdGenero
			,IIF(a.IdGenero = @Masculino, 'HOMBRE', 'MUJER') AS Genero
			,a.IdEstaActivo
			,IIF(a.IdEstaActivo = @EstaActivo, 'ACTIVO', 'INACTIVO') AS EstaActivo
			,a.IdAdminCreacion
			,uc.NumeroControl AS NumeroControlCreacion
			,a.FechaCreacion
			,a.IdAdminActualizacion
			,ua.NumeroControl AS NumeroControlActualizacion
			,a.FechaActualizacion
		FROM dbo.USUARIOS AS a
		INNER JOIN dbo.AREAS AS b ON b.IdArea = a.IdArea
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdEstaActivo BETWEEN IIF(@BuscarTodosLosEstados = @RespuestaSi, @NoEstaActivo, @IdEstaActivo)
				AND IIF(@BuscarTodosLosEstados = @RespuestaSi, @EstaActivo, @IdEstaActivo)
			AND a.IdUsuario BETWEEN @IdUsuarioInicio
				AND @IdUsuarioFin
			AND a.FechaCreacion BETWEEN @FechaInicio
				AND @FechaFin
		ORDER BY a.IdUsuario;
	END
	ELSE IF @Consulta = @BusquedaIndividual
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@NumeroControl = a.NumeroControl
			,@Nombres = a.Nombres
			,@Paterno = a.Paterno
			,@Materno = a.Materno
			,@IdArea = a.IdArea
			,@UrlFoto = a.UrlFoto
			,@IdGenero = a.IdGenero
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.USUARIOS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdUsuario = @IdUsuario
		ORDER BY a.IdUsuario;
	END
	ELSE IF @Consulta = @BusquedaIndividualPorParametro
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@NumeroControl = a.NumeroControl
			,@Nombres = a.Nombres
			,@Paterno = a.Paterno
			,@Materno = a.Materno
			,@IdArea = a.IdArea
			,@UrlFoto = a.UrlFoto
			,@IdGenero = a.IdGenero
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@NumeroControlActualizacion = uc.NumeroControl
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@NumeroControlActualizacion = ua.NumeroControl
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.USUARIOS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.NumeroControl = @NumeroControl
		ORDER BY a.IdUsuario;
	END
END
GO
