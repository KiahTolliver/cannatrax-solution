Create PROC [dbo].[sp_SaleDetailAdd]	
	@SaleID				INT,
	@ItemID				INT,
	@Quantity			DECIMAL(18,0),
	@UnitPrice			DECIMAL(18,2),
	@SellPrice			DECIMAL(18,2),
	@DiscountRate		DECIMAL(18,2),
	@Discount			DECIMAL(18,2),
	@NetAmount			DECIMAL(18,2)	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblSaleDetail]
			(SaleID,ItemID,Quantity,UnitPrice,SellPrice,DiscountRate,Discount,NetAmount)
			VALUES (@SaleID,@ItemID,@Quantity,@UnitPrice,@SellPrice,@DiscountRate,@Discount,@NetAmount)		
	END
END
