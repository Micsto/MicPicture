-- ==========================================================================================
-- Author:			Michele Stoltz
-- Created:			2015-10-24
--
-- Version			01
-- Revision			01
--
-- Description:		View all Pictures 
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Input Param:		@PictureParent				int				n/a					n/a
--
--					Parameter Name				Type			Default Value		Description
--				-----------------------------------------------------------------------------
-- Output Param:	Pictures					varbynary		n/a					n/a
--					
--	
--					Table Name				Column				Description
--				-----------------------------------------------------------------------------
-- Table Updated:	
--					
-- ==========================================================================================
CREATE PROCEDURE [dbo].[uspViewAllPictures]
@PictureParent int = null
AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.Picture.Pictures
	FROM          dbo.Picture
	Where		dbo.Picture.PictureParent = @PictureParent
END