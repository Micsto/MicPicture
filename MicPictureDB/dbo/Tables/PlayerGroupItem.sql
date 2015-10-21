CREATE TABLE [dbo].[PlayerGroupItem] (
    [PlayerGroupItemID] INT IDENTITY (1, 1) NOT NULL,
    [PlayerID]          INT NOT NULL,
    [ScoreID]           INT NOT NULL,
    CONSTRAINT [PK_UserGroupItem] PRIMARY KEY CLUSTERED ([PlayerGroupItemID] ASC),
    CONSTRAINT [FK_UserGroupItem_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([PlayerID]),
    CONSTRAINT [FK_UserGroupItem_Score] FOREIGN KEY ([ScoreID]) REFERENCES [dbo].[Score] ([ScoreID])
);



