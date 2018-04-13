CREATE PROCEDURE [dbo].[sp_GetShop]
	
AS
BEGIN
	SELECT * FROM tblShop
	WHERE IsDeleted='False'
	ORDER BY Name
END
