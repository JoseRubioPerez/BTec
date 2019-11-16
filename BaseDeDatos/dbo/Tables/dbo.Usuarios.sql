CREATE TABLE [dbo].[USUARIOS]
(
[IdUsuario] [int] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__USUARIOS__IdGuid__0A9D95DB] DEFAULT (newid()),
[NumeroControl] [varchar] (9) NOT NULL,
[Nombres] [varchar] (100) NOT NULL,
[Paterno] [varchar] (50) NOT NULL,
[Materno] [varchar] (50) NOT NULL CONSTRAINT [DF__USUARIOS__Matern__0B91BA14] DEFAULT (''),
[IdArea] [tinyint] NOT NULL CONSTRAINT [DF__USUARIOS__IdArea__0C85DE4D] DEFAULT ((1)),
[UrlFoto] [varchar] (200) NOT NULL CONSTRAINT [DF__USUARIOS__UrlFot__0D7A0286] DEFAULT (''),
[IdGenero] [tinyint] NOT NULL CONSTRAINT [DF__USUARIOS__IdGene__0E6E26BF] DEFAULT ((1)),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__USUARIOS__IdEsta__0F624AF8] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__USUARIOS__IdAdmi__10566F31] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__USUARIOS__FechaC__114A936A] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__USUARIOS__IdAdmi__123EB7A3] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__USUARIOS__FechaA__1332DBDC] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[USUARIOS] ADD CONSTRAINT [PK__USUARIOS__5B65BF97DB20A131] PRIMARY KEY CLUSTERED  ([IdUsuario])
GO
