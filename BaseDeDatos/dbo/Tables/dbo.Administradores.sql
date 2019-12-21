CREATE TABLE [dbo].[ADMINISTRADORES]
(
[IdAdministrador] [tinyint] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__ADMINISTR__IdGui__40058253] DEFAULT (newid()),
[NumeroControl] [varchar] (9) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Contrasenia] [varbinary] (8000) NOT NULL,
[Nombres] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Paterno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Materno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__ADMINISTR__Mater__40F9A68C] DEFAULT (''),
[UrlFoto] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__ADMINISTR__UrlFo__41EDCAC5] DEFAULT (''),
[IdGenero] [tinyint] NOT NULL CONSTRAINT [DF__ADMINISTR__IdGen__42E1EEFE] DEFAULT ((1)),
[IdEditable] [bit] NOT NULL CONSTRAINT [DF__ADMINISTR__IdEdi__43D61337] DEFAULT ((1)),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__ADMINISTR__IdEst__44CA3770] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__ADMINISTR__IdAdm__45BE5BA9] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__ADMINISTR__Fecha__46B27FE2] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__ADMINISTR__IdAdm__47A6A41B] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__ADMINISTR__Fecha__489AC854] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[ADMINISTRADORES] ADD CONSTRAINT [PK__ADMINIST__2B3E34A8504624BC] PRIMARY KEY CLUSTERED  ([IdAdministrador])
GO
