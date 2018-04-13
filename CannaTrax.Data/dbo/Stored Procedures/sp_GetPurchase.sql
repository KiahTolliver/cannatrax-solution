CREATE PROCEDURE [dbo].[sp_GetPurchase]	
AS
BEGIN
	SELECT tblPurchase.ID,tblPurchase.PurchaseDate,tblPurchase.TotalItem,tblPurchase.TotalAmount,
	tblPurchase.Payment,tblPurchase.PaidBy,tblSupplier.Name FROM tblPurchase	
	INNER JOIN tblSupplier on tblPurchase.SupplierID=tblSupplier.ID
	WHERE tblPurchase.IsDeleted='False'
	ORDER BY tblPurchase.PurchaseDate DESC
END
