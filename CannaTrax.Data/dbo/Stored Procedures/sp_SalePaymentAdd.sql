Create PROC [dbo].[sp_SalePaymentAdd]	
	@SaleID				INT,
	@PaymentDate		DATETIME,
	@PaymentMode		NVARCHAR(50),	
	@Amount				DECIMAL(18,2)	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblSalePayment]
			(SaleID,PaymentDate,PaymentMode,Amount)
			VALUES (@SaleID,@PaymentDate,@PaymentMode,@Amount)		
	END
END
