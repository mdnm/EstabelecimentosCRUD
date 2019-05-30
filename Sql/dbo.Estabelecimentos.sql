CREATE TABLE [dbo].[estabelecimentos] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [RazaoSocial]    NVARCHAR (MAX) NOT NULL,
    [NomeFantasia]   NVARCHAR (MAX) NULL,
    [CNPJ]           NVARCHAR (MAX) NOT NULL,
    [Email]          NVARCHAR (MAX) NULL,
    [Endereco]       NVARCHAR (MAX) NULL,
    [Cidade]         NVARCHAR (MAX) NULL,
    [Estado]         NVARCHAR (MAX) NULL,
    [Telefone]       NVARCHAR (MAX) NULL,
    [DataDeCadastro] DATETIME2 (7)  NOT NULL,
    [CategoriaId]    INT            NULL,
    [Status]         NVARCHAR (MAX) NULL,
    [Agencia]        NVARCHAR (MAX) NULL,
    [Conta]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_estabelecimentos] PRIMARY KEY CLUSTERED ([Id] ASC)
);