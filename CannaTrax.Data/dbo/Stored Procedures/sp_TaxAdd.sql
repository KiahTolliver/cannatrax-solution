CREATE PROC [dbo].[sp_TaxAdd]	
	@Name				NVARCHAR(512),		
	@TaxRate			DECIMAL(18,2),	
	@InsertBy			INT		
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblTax]
			(Name,TaxRate,IsDeleted,IsActive, InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@Name,@TaxRate,'False','True',@InsertBy,GETDATE(),@insertBy,GETDATE())				
	END
END
