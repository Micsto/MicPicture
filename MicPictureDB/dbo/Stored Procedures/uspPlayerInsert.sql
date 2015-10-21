-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-20
--
-- Version			01
-- Revision			01
--
-- Description:		Insert player 
-- Type:            Insert Stored Procedure
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		@PlayerAlias	   			varchar(50)	n/a					The name you want the new Player to have in the database
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	PlayerID					int				n/a					The created Players Id
--					PlayerAlias					varchar			n/a					The created Players Alias/Name
--	
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	Player					PlayerID			Inserted a new Player in the Player Table with a new unique Id and with the Name/Alias you wrote as an input.
--											PlayerAlias
--					
-- ==========================================================================================
CREATE PROCEDURE [dbo].[uspPlayerInsert]
@PlayerAlias	varchar(50)

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE
		@PlayerID int
	BEGIN 
		INSERT INTO dbo.Player
				(PlayerAlias)
			VALUES
				(@PlayerAlias);

		SET @PlayerID = SCOPE_IDENTITY();
	END 
RESULT:
	SET NOCOUNT OFF;

	SELECT PlayerID
		,PlayerAlias
	FROM dbo.Player
	WHERE PlayerID = @PlayerID
		OR PlayerAlias = @PlayerAlias;
END