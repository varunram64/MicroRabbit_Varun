CREATE TABLE [dbo].[Accounts] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [AccountType]    NVARCHAR (MAX)  NOT NULL,
    [AccountBalance] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

