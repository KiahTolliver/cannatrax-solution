Create PROC [dbo].[sp_SupplierUpdate]	
	@ID					INT,
	@Name				NVARCHAR(512),	
	@CompanyName		NVARCHAR(512),	
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@City				NVARCHAR(50),	
	@Email				NVARCHAR(512),
	@SupplierType		NVARCHAR(50),				
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblSupplier] SET Name=@Name,CompanyName=@CompanyName, Address=@Address,PhoneNo=@PhoneNo,
	 	City=@City,Email=@Email,SupplierType=@SupplierType,LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID	
	END
END
