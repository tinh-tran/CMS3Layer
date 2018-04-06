CREATE DATABASE CMSTT

go
use CMSTT
--- Tạo bảng user---- 
go

CREATE TABLE Users( 
	"Id" INT  IDENTITY(1,1) PRIMARY KEY,
	"Name" NVARCHAR(256),
	"Username" VARCHAR(64) ,
	"Password" NTEXT,
	"Admin" TINYINT ,
	"Active" TINYINT,
	"Image" NVARCHAR(500) ,
	"DateCreate" DATE,
	"Role" TINYINT,
	"ModuleId" VARCHAR(100),
	"ModuleName" NVARCHAR(500)
)
CREATE  PROCEDURE sp_User_GetByAll
AS
	SELECT * FROM Users
GO
CREATE PROC SP_User_GetById
@Id		int
AS
	SELECT * FROM [Users] WHERE Id = @Id
GO

CREATE PROC sp_User_Insert
	@Name		nvarchar(256),
	@Username		varchar(64),
	@Password		ntext,
	@Admin		tinyint,
	@Active		tinyint,
	@Image		nvarchar(500),
	@DateCreate		date,
	@Role		tinyint,
	@ModuleId		varchar(100),
	@ModuleName		nvarchar(500)
AS
	INSERT INTO [Users]([Name], [Username], [Password], [Admin], [Active], [Image], [DateCreate], [Role], [ModuleId], [ModuleName])
	VALUES(@Name, @Username, @Password, @Admin, @Active, @Image, @DateCreate, @Role, @ModuleId, @ModuleName)
GO
CREATE PROCEDURE sp_User_Update 
	@Id		int,
	@Name		nvarchar(256),
	@Username		varchar(64),
	@Password		ntext,
	@Admin		tinyint,
	@Active		tinyint,
	@Image		nvarchar(500),
	@DateCreate		date,
	@Role		tinyint,
	@ModuleId		varchar(100),
	@ModuleName		nvarchar(500)
AS
begin
	UPDATE Users SET Name = @Name, Username = @Username, Password = @Password, Admin = @Admin, Active = @Active, Image = @Image, DateCreate = @DateCreate, Role = @Role, ModuleId = @ModuleId, ModuleName = @ModuleName
	 WHERE Id = @Id
END

CREATE PROC sp_User_Delete
	@Id int
AS
begin 
DELETE * FROM Users WHERE ID= @ID
END 



GO
CREATE PROC sp_User_UpdatePass
	@Id int, 
	@Password ntext
AS
BEGIN 
UPDATE Users SET Password = @Password WHERE Id= @Id
END