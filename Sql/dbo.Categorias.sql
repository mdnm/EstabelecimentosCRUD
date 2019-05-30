CREATE TABLE [dbo].[categorias] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED ([Id] ASC)
);