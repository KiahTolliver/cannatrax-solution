CREATE PROC [dbo].[sp_ItemUpdate]	
	@ID					INT,
	@Name				NVARCHAR(512),	
	@ItemCode			NVARCHAR(50),	
	@CategoryID			INT,	
	@PurchasePrice		DECIMAL(18,2),
	@SellingPrice		DECIMAL(18,2),
	@DiscountRate		DECIMAL(18,2),	
	@Quantity			Decimal(18,3),
	@PhotoPath			NVARCHAR(512),			
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblItem] SET Name=@Name,ItemCode=@ItemCode,CategoryID=@CategoryID,PurchasePrice=@PurchasePrice,
		SellingPrice=@SellingPrice,DiscountRate=@DiscountRate,Quantity=@Quantity, PhotoPath=@PhotoPath,LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID	
	END
END
