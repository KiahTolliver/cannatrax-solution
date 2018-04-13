CREATE PROCEDURE [dbo].[sp_GetItemStock]	
	@ItemID				INT
AS
BEGIN
	SELECT i.ID,i.Name,i.PhotoPath,i.ItemCode,c.Name AS CategoryName,
		(SELECT ISNULL(SUM(Quantity), 0) OpeningBalance FROM tblItem Where tblItem.ID=i.ID) AS OpeningBalance,
		(SELECT ISNULL(SUM(p1.Quantity),0) From tblPurchase p INNER JOIN tblPurchaseDetail p1 ON p.ID=p1.PurchaseID
			WHERE p.IsDeleted='False' AND p1.ItemID=i.ID) AS Inwards,
		(SELECT ISNULL(SUM(s1.Quantity),0) From tblSale s INNER JOIN tblSaleDetail s1 ON s.ID=s1.SaleID
			WHERE s.IsDeleted='False' AND s1.ItemID=i.ID) AS Outwards FROM tblItem i
		INNER JOIN tblCategory c ON i.CategoryID=c.ID
	WHERE ((@ItemID IS NULL) OR (i.ID = @ItemID))
	AND i.IsDeleted='False'
END
