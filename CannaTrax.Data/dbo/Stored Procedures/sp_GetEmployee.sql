CREATE PROCEDURE [dbo].[sp_GetEmployee]
	
AS
BEGIN
	SELECT tblUser.* FROM tblUser
	JOIN tblRole ON tblUser.RoleID=tblRole.ID
	WHERE tblUser.IsDeleted='False'
	AND tblRole.IsSuperAdmin='False'
	ORDER BY FirstName
END
