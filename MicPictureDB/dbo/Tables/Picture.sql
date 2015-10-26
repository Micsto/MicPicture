CREATE TABLE [dbo].[Picture] (
    [PictureID]     INT             IDENTITY (1, 1) NOT NULL,
    [Pictures]      VARBINARY (MAX) NULL,
    [PictureParent] INT             NULL,
    CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED ([PictureID] ASC)
);









