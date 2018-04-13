Create PROC [dbo].[sp_CategoryAdd]	
	@Name				NVARCHAR(512),		
	@InsertBy			INT		
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblCategory]
			(Name,IsDeleted,InsertedBy,InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@Name,'False',@InsertBy,GETDATE(),@insertBy,GETDATE())				
	END
END
