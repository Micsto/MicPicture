CREATE TABLE [dbo].[Score] (
    [ScoreID]   INT IDENTITY (1, 1) NOT NULL,
    [UserScore] INT NOT NULL,
    CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([ScoreID] ASC)
);





