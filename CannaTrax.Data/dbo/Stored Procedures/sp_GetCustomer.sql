Create PROCEDURE [dbo].[sp_GetCustomer]	
AS
BEGIN
	SELECT * FROM tblCustomer	
	WHERE IsDeleted='False'
END
