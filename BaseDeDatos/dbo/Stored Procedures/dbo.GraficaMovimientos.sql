CREATE PROCEDURE [dbo].[GraficaMovimientos]
AS
BEGIN
  DECLARE @IdServicio AS TINYINT = 0,
          @Servicio AS VARCHAR(50);

  DECLARE @Tabla AS TABLE (
    IdServicio TINYINT,
    Servicio VARCHAR(50),
    Total INT
  );

  DECLARE @TablaServicios AS TABLE (
    IdServicio TINYINT,
    Servicio VARCHAR(50)
  );

  INSERT INTO @TablaServicios (IdServicio,
  Servicio)
    SELECT
      a.IdServicio,
      a.Servicio
    FROM dbo.SERVICIOS AS a

  DECLARE CursorServicios CURSOR FOR
  SELECT
    a.IdServicio,
    a.Servicio
  FROM @TablaServicios AS a

  OPEN CursorServicios

  FETCH NEXT
  FROM CursorServicios
  INTO @IdServicio
  ,@Servicio

  WHILE @@FETCH_STATUS = 0
  BEGIN

    DECLARE @Suma AS INT = (SELECT
      COUNT(a.IdMovimiento)
    FROM dbo.MOVIMIENTOS AS a
    WHERE a.IdServicio = @IdServicio);

    INSERT INTO @Tabla (IdServicio,
    Servicio,
    Total)
      VALUES (@IdServicio,@Servicio,@Suma);

    FETCH NEXT
    FROM CursorServicios
    INTO @IdServicio
    ,@Servicio
  END
  CLOSE CursorServicios

  DEALLOCATE CursorServicios

  SELECT
    a.IdServicio,
    a.Servicio,
    a.Total
  FROM @Tabla AS a
END
GO
