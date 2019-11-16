CREATE TABLE [dbo].[AREAS]
(
[IdArea] [tinyint] NOT NULL IDENTITY(1, 1),
[IdGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF__AREAS__IdGuid__6A30C649] DEFAULT (newid()),
[Area] [varchar] (100) NOT NULL CONSTRAINT [DF__AREAS__Area__6B24EA82] DEFAULT (''),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__AREAS__IdEstaAct__6C190EBB] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__AREAS__IdAdminCr__6D0D32F4] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__AREAS__FechaCrea__6E01572D] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__AREAS__IdAdminAc__6EF57B66] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__AREAS__FechaActu__6FE99F9F] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[AREAS] ADD CONSTRAINT [PK__AREAS__2FC141AA602B2BF3] PRIMARY KEY CLUSTERED  ([IdArea])
GO
