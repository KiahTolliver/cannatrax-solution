CREATE PROC [dbo].[sp_CustomerAdd]	
	@Name				NVARCHAR(512),	
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@Email				NVARCHAR(512),
	@InsertBy			INT,		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblCustomer]
			(Name,Address,PhoneNo,Email,IsDeleted,IsActive, InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@Name,@Address,@PhoneNo,@Email,'False','True',@InsertBy,GETDATE(),@LastModifiedBy,GETDATE())				
	END
END
