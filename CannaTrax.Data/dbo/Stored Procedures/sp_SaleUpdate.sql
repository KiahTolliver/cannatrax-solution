Create PROC [dbo].[sp_SaleUpdate]	
	@SaleID				INT,	
	@RefNumber			NVARCHAR(50),	
	@CustomerID			INT,	
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
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblSale] SET RefNumber=@RefNumber,CustomerID=@CustomerID,TotalItem=@TotalItem,SubTotal=@SubTotal,
		TotalTax=@TotalTax,TotalDiscount=@TotalDiscount,NetAmount=@NetAmount,Payment=@Payment,Change=@Change,
		Status=@Status,OrderStatus=@OrderStatus,Notes=@Notes,LastModifiedBy=@LastModifiedBy,LastModifiedDate=GETDATE()
		WHERE ID=@SaleID
	END
END
