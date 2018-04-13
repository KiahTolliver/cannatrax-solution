Create PROCEDURE [dbo].[sp_GetSupplier]
	
AS
BEGIN
	SELECT * FROM tblSupplier
	WHERE IsDeleted='False'	
	ORDER BY Name
END
