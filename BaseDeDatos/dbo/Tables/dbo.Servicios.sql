CREATE TABLE [dbo].[Servicios]
(
[IdServicio] [tinyint] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Servicios__IdGui__5165187F] DEFAULT (newid()),
[Servicio] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__Servicios__Servi__52593CB8] DEFAULT (''),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__Servicios__IdEst__534D60F1] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__Servicios__IdAdm__5441852A] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__Servicios__Fecha__5535A963] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__Servicios__IdAdm__5629CD9C] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__Servicios__Fecha__571DF1D5] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Servicios] ADD CONSTRAINT [PK__Servicio__2DCCF9A20E3AA56C] PRIMARY KEY CLUSTERED  ([IdServicio])
GO
