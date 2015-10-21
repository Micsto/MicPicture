-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-20
--
-- Version			01
-- Revision			01
--
-- Description:		Insert score 
-- Type:            Insert Stored Procedure
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		@UserScore		   			int				n/a					the players score
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	ScoreID						int				n/a					The created scores Id
--				
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	Score					ScoreID				Inserted a new Score in the Score Table with a new unique Id and with the you score.
--											UserScore
--					
-- ==========================================================================================
Create PROCEDURE [dbo].[uspScoreInsert]
@UserScore	int

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE
		@ScoreID int 
	BEGIN 
	
		INSERT INTO dbo.Score
				(UserScore)
			
			VALUES
				(@UserScore);
	   SET @ScoreID = SCOPE_IDENTITY();
	
	END 
RESULT:
	SET NOCOUNT OFF;

	SELECT ScoreID
	FROM dbo.Score
	WHERE ScoreID = @ScoreID
END