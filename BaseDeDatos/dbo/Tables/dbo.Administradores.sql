CREATE TABLE [dbo].[Administradores]
(
[IdAdministrador] [tinyint] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Administr__IdGui__46E78A0C] DEFAULT (newid()),
[NumeroControl] [varchar] (9) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PrimerNombre] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SegundoNombre] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Administr__Segun__47DBAE45] DEFAULT (''),
[Paterno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Materno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Administr__Mater__48CFD27E] DEFAULT (''),
[Contrasenia] [varbinary] (8000) NOT NULL,
[UrlFoto] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Administr__UrlFo__49C3F6B7] DEFAULT (''),
[IdGenero] [tinyint] NOT NULL CONSTRAINT [DF__Administr__IdGen__4AB81AF0] DEFAULT ((1)),
[IdEditable] [bit] NOT NULL CONSTRAINT [DF__Administr__IdEdi__4BAC3F29] DEFAULT ((1)),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__Administr__IdEst__4CA06362] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__Administr__Fecha__4D94879B] DEFAULT (getdate()),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__Administr__Fecha__4E88ABD4] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Administradores] ADD CONSTRAINT [PK__Administ__2B3E34A821464237] PRIMARY KEY CLUSTERED  ([IdAdministrador])
GO
