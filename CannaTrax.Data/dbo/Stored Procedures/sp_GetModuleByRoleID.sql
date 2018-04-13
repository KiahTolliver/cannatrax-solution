Create PROCEDURE [dbo].[sp_GetModuleByRoleID]
	@RoleID				INT,
	@ParentModuleID		INT
AS
BEGIN
	IF(@RoleID=0)
		SELECT * FROM tblModule m		
		WHERE IsDeleted='False'			
		AND((@ParentModuleID IS NULL) OR (m.ParentModuleID = @ParentModuleID))
		ORDER BY m.DisplayOrder
	ELSE
		SELECT m.ID,m.ModuleName,m.PageIcon,m.PageSlug,m.PageUrl FROM tblModule m
		JOIN tblUserPermission u ON m.ID =u.ModuleID
		WHERE IsDeleted='False'	
		AND ((@RoleID IS NULL) OR (u.RoleID = @RoleID))
		AND((@ParentModuleID IS NULL) OR (m.ParentModuleID = @ParentModuleID))
		ORDER BY m.DisplayOrder
END
