Create PROC [dbo].[sp_SaleTaxAdd]	
	@SaleID				INT,
	@TaxID				INT,
	@TaxRate			DECIMAL(18,2),	
	@TaxAmount			DECIMAL(18,2)	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblSaleTax]
			(SaleID,TaxID,TaxRate,TaxAmount)
			VALUES (@SaleID,@TaxID,@TaxRate,@TaxAmount)		
	END
END
