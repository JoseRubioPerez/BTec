CREATE TABLE [dbo].[ADMINISTRADORES]
(
[IdAdministrador] [tinyint] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__ADMINISTR__IdGui__160F4887] DEFAULT (newid()),
[NumeroControl] [varchar] (9) NOT NULL,
[Contrasenia] [varbinary] (8000) NOT NULL,
[Nombres] [varchar] (100) NOT NULL,
[Paterno] [varchar] (50) NOT NULL,
[Materno] [varchar] (50) NOT NULL CONSTRAINT [DF__ADMINISTR__Mater__17036CC0] DEFAULT (''),
[UrlFoto] [varchar] (200) NOT NULL CONSTRAINT [DF__ADMINISTR__UrlFo__17F790F9] DEFAULT (''),
[IdGenero] [tinyint] NOT NULL CONSTRAINT [DF__ADMINISTR__IdGen__18EBB532] DEFAULT ((1)),
[IdEditable] [bit] NOT NULL CONSTRAINT [DF__ADMINISTR__IdEdi__19DFD96B] DEFAULT ((1)),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__ADMINISTR__IdEst__1AD3FDA4] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__ADMINISTR__Fecha__1BC821DD] DEFAULT (getdate()),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__ADMINISTR__Fecha__1CBC4616] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[ADMINISTRADORES] ADD CONSTRAINT [PK__ADMINIST__2B3E34A82D8170AC] PRIMARY KEY CLUSTERED  ([IdAdministrador])
GO
