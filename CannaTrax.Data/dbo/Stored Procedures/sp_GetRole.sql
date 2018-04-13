CREATE PROCEDURE [dbo].[sp_GetRole]
	@ID INT
AS
BEGIN
	SELECT * FROM tblRole		
	WHERE IsSuperAdmin='false'
	AND IsDeleted='False'
END
