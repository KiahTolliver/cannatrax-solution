CREATE PROC [dbo].[sp_ItemAdd]	
	@Name				NVARCHAR(512),	
	@ItemCode			NVARCHAR(50),	
	@CategoryID			INT,	
	@PurchasePrice		DECIMAL(18,2),
	@SellingPrice		DECIMAL(18,2),
	@DiscountRate		DECIMAL(18,2),	
	@Quantity			Decimal(18,3),
	@PhotoPath			NVARCHAR(512),
	@InsertBy			INT,		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblItem]
			(Name,ItemCode,CategoryID,PurchasePrice,SellingPrice,DiscountRate,Quantity, PhotoPath,IsDeleted, InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@Name,@ItemCode,@CategoryID,@PurchasePrice,@SellingPrice,@DiscountRate,@Quantity, @PhotoPath, 'False',@InsertBy,GETDATE(),@LastModifiedBy,GETDATE())				
	END
END
