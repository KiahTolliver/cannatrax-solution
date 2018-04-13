Create PROC [dbo].[sp_RoleUpdate]	
	@ID					INT,
	@RoleName			NVARCHAR(50),		
	@LastModifiedBy		INT
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblRole] SET Name=@RoleName,LastModifiedBy=@LastModifiedBy,LastModifiedDate=GETDATE()
		WHERE ID=@ID		
	END
END
