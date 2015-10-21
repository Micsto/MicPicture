-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-21
--
-- Version			01
-- Revision			01
--
-- Description:		Insert PlayerGroupItem, what player got what scores
-- Type:            Insert Stored Procedure
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		@UserID			   			int				n/a					the players score
--					@PlayerID					int				n/a					the players ID
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	PlayerGroupItemID			int				n/a					the playergroupitem ID
--					ScoreID						int				n/a					The scores Id
--					PlayerID					int				n/a					the players ID
--				
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	PlayerGroupItem			ScoreID				Many to many relationship table
--											PlayerID
--					
-- ==========================================================================================
Create PROCEDURE [dbo].[uspPlayerGroupItemInsert]
@PlayerID	int
,@ScoreID	int

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE
		@PlayerGroupItemID int 
	BEGIN 
	
		INSERT INTO dbo.PlayerGroupItem
				(PlayerID,
				ScoreID)
			
			VALUES
				(@PlayerID,
				@ScoreID);
	   SET @PlayerGroupItemID = SCOPE_IDENTITY();
	
	END 
RESULT:
	SET NOCOUNT OFF;

	SELECT PlayerGroupItemID
	,PlayerID
	,ScoreID
	FROM dbo.PlayerGroupItem
	WHERE PlayerGroupItemID = @PlayerGroupItemID
END