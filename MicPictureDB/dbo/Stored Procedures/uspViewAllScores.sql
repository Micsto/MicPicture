-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-21
--
-- Version			01
-- Revision			01
--
-- Description:		View all Score 
-- Type:            list Stored Procedure
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		n/A				   			n/a				n/a					n/a
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	Score						int				n/a					The Players scores
--					
--	
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	
--					
-- ==========================================================================================
CREATE PROCEDURE [dbo].[uspViewAllScores]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.Player.PlayerAlias, dbo.Score.UserScore
	FROM          dbo.Player INNER JOIN
                  dbo.PlayerGroupItem ON dbo.Player.PlayerID = dbo.PlayerGroupItem.PlayerID INNER JOIN
                  dbo.Score ON dbo.PlayerGroupItem.ScoreID = dbo.Score.ScoreID
END