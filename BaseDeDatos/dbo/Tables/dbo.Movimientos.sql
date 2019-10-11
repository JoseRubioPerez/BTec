CREATE TABLE [dbo].[Movimientos]
(
[IdMovimiento] [int] NOT NULL IDENTITY(1, 1),
[IdUsuario] [int] NOT NULL CONSTRAINT [DF__Movimient__IdUsu__6EF57B66] DEFAULT ((1)),
[IdServicio] [tinyint] NOT NULL CONSTRAINT [DF__Movimient__IdSer__6FE99F9F] DEFAULT ((1)),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__Movimient__IdEst__70DDC3D8] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__Movimient__IdAdm__71D1E811] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__Movimient__Fecha__72C60C4A] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__Movimient__IdAdm__73BA3083] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__Movimient__Fecha__74AE54BC] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Movimientos] ADD CONSTRAINT [PK__Movimien__881A6AE0E1BC6974] PRIMARY KEY CLUSTERED  ([IdMovimiento])
GO
