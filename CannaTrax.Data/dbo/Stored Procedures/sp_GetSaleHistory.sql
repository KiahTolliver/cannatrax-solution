CREATE PROCEDURE [dbo].[sp_GetSaleHistory]	
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN
	SELECT tblSale.ID,tblsale.ShopID,tblSale.RefNumber, tblSale.OrderDate,tblSale.OrderNo, tblSale.TotalItem,tblSale.SubTotal,tblSale.NetAmount,
	tblSale.Payment,tblSale.Status,tblSale.OrderStatus, tblCustomer.Name AS CustomerName FROM tblSale
	INNER JOIN tblCustomer on tblSale.CustomerID=tblCustomer.ID
	WHERE tblSale.IsDeleted='False'
	AND ((@FromDate IS NULL) OR (tblSale.OrderDate>=@FromDate))
	AND ((@ToDate IS NULL) OR (tblSale.OrderDate<=@ToDate))		
	ORDER BY tblSale.OrderDate DESC
END
