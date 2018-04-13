CREATE PROC [dbo].[sp_EmployeeAdd]	
	@RoleID				INT,
	@ShopID				INT,		
	@FirstName			NVARCHAR(200),
	@LastName			NVARCHAR(200),
	@PhoneNo			NVARCHAR(50),
	@Email				NVARCHAR(100),
	@Department			NVARCHAR(100),
	@Designation		NVARCHAR(100),
	@Supervisor			NVARCHAR(100),
	@DateOfBirth		DATE,
	@Address			NVARCHAR(1000),		
	@PhotoPath			NVARCHAR(512),	
	@UserName			NVARCHAR(100),	
	@Password			NVARCHAR(512),	
	@InsertBy			INT,		
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO [dbo].[tblUser]
			(RoleID,ShopID,FirstName,LastName,PhoneNo,Email,Department,Designation,Supervisor,DateOfBirth, 
			Address,PhotoPath,UserName,Password,IsActive,IsDeleted,IsDefault, InsertedBy, InsertedDate,LastModifiedBy,LastModifiedDate)
			VALUES (@RoleID,@ShopID,@FirstName,@LastName,@PhoneNo,@Email,@Department,@Designation,@Supervisor,
			@DateOfBirth,@Address,@PhotoPath,@UserName,@Password, 'True','False','False', @InsertBy,GETDATE(),@LastModifiedBy,GETDATE())				
	END
END
