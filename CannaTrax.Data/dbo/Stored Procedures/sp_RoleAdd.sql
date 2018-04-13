CREATE PROC [dbo].[sp_RoleAdd]	
	@RoleName			NVARCHAR(50),		
	@InsertBy			INT,		
	@LastModifiedBy		INT,		
	@RoleID				INT OUTPUT
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblRole]
			(Name,IsDeleted,IsSuperAdmin,IsDefault, InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@RoleName,'False','False','False',@InsertBy,GETDATE(),@LastModifiedBy,GETDATE())		
		SET @RoleID = SCOPE_IDENTITY();
	END
END
