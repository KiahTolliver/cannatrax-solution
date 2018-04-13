CREATE PROC [dbo].[sp_StoreUpdate]	
	@ID					INT,
	@StoreName			NVARCHAR(512),
	@StoreCode			NVARCHAR(50),		
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@Email				NVARCHAR(512),	
	@LogoPath			NVARCHAR(512),			
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblShop] SET Name=@StoreName,StoreCode=@StoreCode,Address=@Address,PhoneNo=@PhoneNo,
		Email=@Email,LogoPath=@LogoPath,LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID		
	END
END
