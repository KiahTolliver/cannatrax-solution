CREATE PROC [dbo].[sp_PurchaseAdd]	
	@SupplierID			INT,
	@PurchaseDate		DATETIME,
	@TotalItem			DEcimal(18,0),
	@TotalAmount		Decimal(18,2),
	@Payment			Decimal(18,2),
	@PaidBy				Nvarchar(50),
	@Note				nvarchar(512),			
	@InsertBy			INT,
	@PurchaseID			INT OUTPUT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblPurchase]
			(SupplierID,PurchaseDate,TotalItem,TotalAmount,Payment,PaidBy,Note,IsDeleted,InsertedBy,
			InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@SupplierID,@PurchaseDate,@TotalItem,@TotalAmount,@Payment,@PaidBy,@Note,
			'False',@InsertBy,GETDATE(),@insertBy,GETDATE())
		SET @PurchaseID = SCOPE_IDENTITY();				
	END
END
