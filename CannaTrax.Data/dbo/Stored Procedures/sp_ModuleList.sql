CREATE PROCEDURE [dbo].[sp_ModuleList]
	@ID INT
AS
BEGIN
	WITH cte AS (
		SELECT t.Id, t.ModuleName, t.parentModuleId,CAST(t.ModuleName AS NVARCHAR(MAX)) AS FullName,t.IsActive,t.displayOrder,
		1 as Level
			FROM tblModule AS t   
			where t.IsDeleted = 'False' 			
			AND ((@ID IS NULL) OR (t.ParentModuleID = @ID))					
		UNION all
		SELECT c.Id, c.ModuleName, t.parentModuleId, CAST(t.ModuleName AS NVARCHAR(MAX))+ ' > ' +c.FullName,c.IsActive,t.displayOrder,
			c.Level + 1 FROM tblModule AS t
			INNER JOIN cte AS c ON c.parentModuleId = t.Id   			
			where c.Level < 100    									
		)
	SELECT id, ModuleName, FullName,IsActive,DisPlayOrder
		FROM cte
		WHERE parentModuleid=0
		ORDER BY DisplayOrder,FullName
		option (maxrecursion 0);
END
