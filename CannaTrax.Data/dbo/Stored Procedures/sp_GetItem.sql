CREATE PROCEDURE [dbo].[sp_GetItem]
	
AS
BEGIN
	SELECT tblItem.ID, tblItem.Name,tblItem.ItemCode, tblItem.PurchasePrice,tblItem.SellingPrice,tblItem.PhotoPath,
	tblItem.DiscountRate,Quantity, tblCategory.Name AS CategoryName,tblItem.CategoryID FROM tblItem
	JOIN tblCategory on tblItem.CategoryID=tblCategory.ID
	WHERE tblItem.IsDeleted='False'
	AND tblCategory.IsDeleted='False'
	ORDER BY tblItem.Name
END
