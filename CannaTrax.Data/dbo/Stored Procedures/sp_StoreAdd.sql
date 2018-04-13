CREATE PROC [dbo].[sp_StoreAdd]	
	@StoreName			NVARCHAR(512),
	@StoreCode			NVARCHAR(50),		
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@Email				NVARCHAR(512),	
	@LogoPath			NVARCHAR(512),
	@InsertBy			INT,		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblShop]
			(Name,StoreCode,Address,PhoneNo,Email,LogoPath,IsDeleted,IsDefault, InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@StoreName,@StoreCode,@Address,@PhoneNo,@Email,@LogoPath,'False','False',@InsertBy,GETDATE(),@LastModifiedBy,GETDATE())				
	END
END
