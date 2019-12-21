SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[LeerMovimientos] @Consulta AS TINYINT = 1
	,@IdMovimiento AS INT OUTPUT
	,@IdGuid AS UNIQUEIDENTIFIER OUTPUT
	,@IdUsuario AS INT OUTPUT
	,@IdServicio AS TINYINT OUTPUT
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

	SET @IdMovimiento = ISNULL(@IdMovimiento, 0);
	SET @IdEstaActivo = ISNULL(@IdEstaActivo, 1);

	DECLARE @IdMovimientoInicio AS INT = IIF(@IdMovimiento = @BuscarTodo, 0, @IdMovimiento)
		,@IdMovimientoFin AS INT = IIF(@IdMovimiento = @BuscarTodo, 1000000, @IdMovimiento);

	SET @FechaInicio = ISNULL(@FechaInicio, CAST('1900-01-01' AS DATETIME));
	SET @FechaFin = ISNULL(@FechaFin, CAST('2100-01-01' AS DATETIME));

	IF @Consulta = @BusquedaMasiva
	BEGIN
		SELECT a.IdMovimiento
			,a.IdGuid
			,b.IdUsuario
			,b.NumeroControl
			,b.Nombres
			,b.Paterno
			,b.Materno
			,b.IdGenero
			,IIF(b.IdGenero = @Masculino, 'HOMBRE', 'MUJER') AS Genero
			,c.IdArea
			,c.Area
			,d.IdServicio
			,d.Servicio
			,a.IdEstaActivo
			,IIF(a.IdEstaActivo = @EstaActivo, 'ACTIVO', 'INACTIVO') AS EstaActivo
			,a.IdAdminCreacion
			,uc.NumeroControl AS NumeroControlCreacion
			,a.FechaCreacion
			,a.IdAdminActualizacion
			,ua.NumeroControl AS NumeroControlActualizacion
			,a.FechaActualizacion
		FROM dbo.MOVIMIENTOS AS a
		INNER JOIN dbo.USUARIOS AS b ON b.IdUsuario = a.IdUsuario
		INNER JOIN dbo.AREAS AS c ON c.IdArea = b.IdArea
		INNER JOIN dbo.SERVICIOS AS d ON d.IdServicio = a.IdServicio
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdEstaActivo BETWEEN IIF(@BuscarTodosLosEstados = @RespuestaSi, @NoEstaActivo, @IdEstaActivo)
				AND IIF(@BuscarTodosLosEstados = @RespuestaSi, @EstaActivo, @IdEstaActivo)
			AND a.IdMovimiento BETWEEN @IdMovimientoInicio
				AND @IdMovimientoFin
			AND a.FechaCreacion BETWEEN @FechaInicio
				AND @FechaFin
		ORDER BY a.IdMovimiento;
	END
	ELSE IF @Consulta = @BusquedaIndividual
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@IdUsuario = a.IdUsuario
			,@IdServicio = a.IdServicio
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@NumeroControlCreacion = uc.NumeroControl
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@NumeroControlActualizacion = ua.NumeroControl
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.MOVIMIENTOS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdMovimiento = @IdMovimiento
		ORDER BY a.IdMovimiento;
	END
	ELSE IF @Consulta = @BusquedaIndividualPorParametro
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@IdMovimiento = a.IdMovimiento
			,@IdServicio = a.IdServicio
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@NumeroControlCreacion = uc.NumeroControl
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@NumeroControlActualizacion = ua.NumeroControl
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.MOVIMIENTOS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdUsuario = @IdUsuario
		ORDER BY a.IdMovimiento;
	END
END
GO
