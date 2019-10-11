CREATE TABLE [dbo].[Areas]
(
[IdArea] [tinyint] NOT NULL IDENTITY(1, 1),
[Area] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__Areas__Area__59FA5E80] DEFAULT (''),
[IdEstaActivo] [bit] NOT NULL CONSTRAINT [DF__Areas__IdEstaAct__5AEE82B9] DEFAULT ((1)),
[IdAdminCreacion] [tinyint] NOT NULL CONSTRAINT [DF__Areas__IdAdminCr__5BE2A6F2] DEFAULT ((1)),
[FechaCreacion] [datetime] NOT NULL CONSTRAINT [DF__Areas__FechaCrea__5CD6CB2B] DEFAULT (getdate()),
[IdAdminActualizacion] [tinyint] NOT NULL CONSTRAINT [DF__Areas__IdAdminAc__5DCAEF64] DEFAULT ((1)),
[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF__Areas__FechaActu__5EBF139D] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Areas] ADD CONSTRAINT [PK__Areas__2FC141AA5EE1FFA5] PRIMARY KEY CLUSTERED  ([IdArea])
GO
