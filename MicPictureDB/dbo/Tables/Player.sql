CREATE TABLE [dbo].[Player] (
    [PlayerID]    INT          IDENTITY (1, 1) NOT NULL,
    [PlayerAlias] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([PlayerID] ASC)
);



