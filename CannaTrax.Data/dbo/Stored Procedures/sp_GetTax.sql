Create PROCEDURE [dbo].[sp_GetTax]	
AS
BEGIN
	SELECT * FROM tblTax
	WHERE IsDeleted='False'
END
