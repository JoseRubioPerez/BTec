SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[LeerAreas] @Consulta AS TINYINT = 1
	,@IdArea AS TINYINT OUTPUT
	,@Area AS VARCHAR(50) OUTPUT
	,@IdGuid AS UNIQUEIDENTIFIER OUTPUT
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
		,@NoEstaActivo AS BIT = 0
		,@EstaActivo AS BIT = 1
		,@BuscarTodo AS TINYINT = 0
		,@RespuestaSi AS BIT = 1;

	SET @IdArea = ISNULL(@IdArea, 0);
	SET @IdEstaActivo = ISNULL(@IdEstaActivo, 1);

	DECLARE @IdAreaInicio AS TINYINT = IIF(@IdArea = @BuscarTodo, 0, @IdArea)
		,@IdAreaFin AS TINYINT = IIF(@IdArea = @BuscarTodo, 255, @IdArea);

	SET @FechaInicio = ISNULL(@FechaInicio, CAST('1900-01-01' AS DATETIME));
	SET @FechaFin = ISNULL(@FechaFin, CAST('2100-01-01' AS DATETIME));

	IF @Consulta = @BusquedaMasiva
	BEGIN
		SELECT a.IdArea
			,a.IdGuid
			,a.Area
			,a.IdEstaActivo
			,IIF(a.IdEstaActivo = @EstaActivo, 'ACTIVO', 'INACTIVO') AS EstaActivo
			,a.IdAdminCreacion
			,uc.NumeroControl AS NumeroControlCreacion
			,a.FechaCreacion
			,a.IdAdminActualizacion
			,ua.NumeroControl AS NumeroControlActualizacion
			,a.FechaActualizacion
		FROM dbo.AREAS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdEstaActivo BETWEEN IIF(@BuscarTodosLosEstados = @RespuestaSi, @NoEstaActivo, @IdEstaActivo)
				AND IIF(@BuscarTodosLosEstados = @RespuestaSi, @EstaActivo, @IdEstaActivo)
			AND a.IdArea BETWEEN @IdAreaInicio
				AND @IdAreaFin
			AND a.FechaCreacion BETWEEN @FechaInicio
				AND @FechaFin
		ORDER BY a.IdArea;
	END
	ELSE IF @Consulta = @BusquedaIndividual
	BEGIN
		SELECT TOP (1) @IdGuid = a.IdGuid
			,@IdArea = a.IdArea
			,@Area = a.Area
			,@IdEstaActivo = a.IdEstaActivo
			,@IdAdminCreacion = a.IdAdminCreacion
			,@NumeroControlActualizacion = uc.NumeroControl
			,@FechaCreacion = a.FechaCreacion
			,@IdAdminActualizacion = a.IdAdminActualizacion
			,@NumeroControlActualizacion = ua.NumeroControl
			,@FechaActualizacion = a.FechaActualizacion
		FROM dbo.AREAS AS a
		INNER JOIN dbo.ADMINISTRADORES AS uc ON uc.IdAdministrador = a.IdAdminCreacion
		INNER JOIN dbo.ADMINISTRADORES AS ua ON ua.IdAdministrador = a.IdAdminActualizacion
		WHERE a.IdArea = @IdArea
		ORDER BY a.IdArea;
	END
END
GO
