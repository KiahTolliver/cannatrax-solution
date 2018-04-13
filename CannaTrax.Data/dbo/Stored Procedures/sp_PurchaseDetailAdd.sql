Create PROC [dbo].[sp_PurchaseDetailAdd]	
	@PurchaseID			INT,
	@ItemID				INT,
	@Quantity			DEcimal(18,0),
	@Price				Decimal(18,2),
	@Discount			Decimal(18,2),
	@Amount				Decimal(18,2)	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblPurchaseDetail]
			(PurchaseID,ItemID,Quantity,Price,Discount,Amount)
			VALUES (@PurchaseID,@ItemID,@Quantity,@Price,@Discount,@Amount)		
	END
END
