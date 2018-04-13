CREATE PROC [dbo].[sp_TaxUpdate]	
	@ID					INT,
	@Name				NVARCHAR(512),		
	@TaxRate			DECIMAL(18,2),		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblTax] SET Name=@Name,TaxRate=@TaxRate,LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID	
	END
END
