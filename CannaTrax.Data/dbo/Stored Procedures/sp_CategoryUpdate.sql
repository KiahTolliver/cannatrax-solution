Create PROC [dbo].[sp_CategoryUpdate]	
	@ID					INT,
	@Name				NVARCHAR(512),				
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblCategory] SET Name=@Name,LastModifiedBy=@LastModifiedBy,
		LastModifiedDate=GETDATE()
		WHERE ID=@ID	
	END
END
