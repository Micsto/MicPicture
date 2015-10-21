-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-21
--
-- Version			01
-- Revision			01
--
-- Description:		View Player Score 
-- Type:            list Stored Procedure
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		@PlayerID		   			int				n/a					the id of the player you want to see score of
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	Score						int				n/a					The Players scores
--					PlayerAlias					varchar			n/a					The  Players Alias/Name
--	
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	
--					
-- ==========================================================================================
Create PROCEDURE [dbo].[uspViewPlayerScore]
@PlayerID	int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.Player.PlayerAlias, dbo.Score.UserScore
	FROM          dbo.Player INNER JOIN
                  dbo.PlayerGroupItem ON dbo.Player.PlayerID = dbo.PlayerGroupItem.PlayerID INNER JOIN
                  dbo.Score ON dbo.PlayerGroupItem.ScoreID = dbo.Score.ScoreID
				  where dbo.PlayerGroupItem.PlayerID = @PlayerID
END