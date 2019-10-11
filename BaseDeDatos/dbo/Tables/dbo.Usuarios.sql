CREATE TABLE [dbo].[Usuarios]
(
[IdUsuario] [int] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Usuarios__IdGuid__619B8048] DEFAULT (newid()),
[NumeroControl] [varchar] (9) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PrimerNombre] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SegundoNombre] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Usuarios__Segund__628FA481] DEFAULT (''),
[Paterno] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Materno] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Usuarios__Matern__6383C8BA] DEFAULT (''),
[IdArea] [tinyint] NOT NULL CONSTRAINT [DF__Usuarios__IdArea__656C112C] DEFAULT ((1)),
[UrlFoto] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__Usuarios__UrlFot__66603565] DEFAULT (''),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__Usuarios__IdEsta__6754599E] DEFAULT ((1)),
[IdGenero] [tinyint] NOT NULL CONSTRAINT [DF__Usuarios__IdGene__68487DD7] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__Usuarios__IdAdmi__693CA210] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__Usuarios__FechaC__6A30C649] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__Usuarios__IdAdmi__6B24EA82] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__Usuarios__FechaA__6C190EBB] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Usuarios] ADD CONSTRAINT [PK__Usuarios__5B65BF97EE251F61] PRIMARY KEY CLUSTERED  ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuarios] ADD CONSTRAINT [FK__Usuarios__IdArea__6477ECF3] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Areas] ([IdArea])
GO
