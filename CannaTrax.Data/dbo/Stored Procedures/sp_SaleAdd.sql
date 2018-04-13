CREATE PROC [dbo].[sp_SaleAdd]	
	@OrderNo			INT,
	@RefNumber			NVARCHAR(50),
	@OrderDate			DATETIME,
	@CustomerID			INT,
	@ShopID				INT,
	@TotalItem			DECIMAL(18,0),
	@SubTotal			DECIMAL(18,2),
	@TotalTax			DECIMAL(18,2),
	@TotalDiscount		DECIMAL(18,2),
	@NetAmount			DECIMAL(18,2),
	@Payment			DECIMAL(18,2),
	@Change				DECIMAL(18,2),
	@Status				NVARCHAR(50),
	@OrderStatus		NVARCHAR(50),
	@Notes				NVARCHAR(512),			
	@InsertBy			INT,
	@SaleID				INT OUTPUT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblSale]
			(OrderNo,RefNumber, OrderDate,CustomerID,ShopID,TotalItem,SubTotal,TotalTax,TotalDiscount,NetAmount,
			Payment,Change,Status,OrderStatus, Notes,IsDeleted,InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@OrderNo,@RefNumber, @OrderDate,@CustomerID,@ShopID,@TotalItem,@SubTotal,@TotalTax,@TotalDiscount,
			@NetAmount,@Payment,@Change,@Status,@OrderStatus, @Notes,'False',@InsertBy,GETDATE(),@insertBy,GETDATE())
		SET @SaleID = SCOPE_IDENTITY();				
	END
END
