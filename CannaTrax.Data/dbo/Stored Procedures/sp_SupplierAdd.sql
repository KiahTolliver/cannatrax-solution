Create PROC [dbo].[sp_SupplierAdd]	
	@Name				NVARCHAR(512),	
	@CompanyName		NVARCHAR(512),	
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@City				NVARCHAR(50),	
	@Email				NVARCHAR(512),
	@SupplierType		NVARCHAR(50),	
	@InsertBy			INT,		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblSupplier]
			(Name,CompanyName,Address,PhoneNo,Email,City,IsDeleted,InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@Name,@CompanyName, @Address,@PhoneNo,@Email,@City,'False',@InsertBy,GETDATE(),@LastModifiedBy,GETDATE())				
	END
END
