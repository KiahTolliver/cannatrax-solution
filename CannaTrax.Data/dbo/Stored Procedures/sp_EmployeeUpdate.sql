Create PROC [dbo].[sp_EmployeeUpdate]	
	@ID					INT,
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
	@LastModifiedBy		INT	
AS
BEGIN		  	
	BEGIN
		SET NOCOUNT ON;
		UPDATE [dbo].[tblUser] SET RoleID=@RoleID,ShopID=@ShopID,FirstName=@FirstName,LastName=@LastName,
		PhoneNo=@PhoneNo,Email=@Email,Department=@Department,Designation=@Designation,Supervisor=@Supervisor,
		DateOfBirth=@DateOfBirth, Address=@Address,PhotoPath=@PhotoPath,UserName=@UserName,Password=@Password,
		LastModifiedBy=@LastModifiedBy,LastModifiedDate=GETDATE()
		WHERE ID=@ID		
	END
END
