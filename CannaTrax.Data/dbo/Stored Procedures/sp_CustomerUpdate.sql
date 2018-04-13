CREATE PROC [dbo].[sp_CustomerUpdate]	
	@ID					INT,
	@Name				NVARCHAR(512),	
	@Address			NVARCHAR(1000),
	@PhoneNo			NVARCHAR(50),
	@Email				NVARCHAR(512),
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblCustomer] SET Name=@Name,Address=@Address,PhoneNo=@PhoneNo,Email=@Email,
		LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID	
	END
END
