Create PROCEDURE [dbo].[sp_GetCategory]	
AS
BEGIN
	SELECT * FROM tblCategory
	WHERE IsDeleted='False'
END
