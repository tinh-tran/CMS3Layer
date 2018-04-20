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
GO 
-- giao diện của chương trình ví dụ slider... ---
CREATE TABLE ImagesType(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50),
	Code varchar(50),
	Active tinyint
)
GO 
-- hình ảnh của bài viết --- 
CREATE TABLE ImagesDetail
(
	Id int IDENTITY(1,1) primary key, 
	Name nvarchar(512) ,
	Image nvarchar(500),
	ImagesId varchar(50),
	Active int ,
	Summary ntext
)

CREATE TABLE Module (
	Id INT IDENTITY(1,1) primary key,
	Name NVARCHAR(50),
	Idcha INT NULL DEFAULT NULL,
	Ord TINYINT NULL DEFAULT NULL,
	Icon VARCHAR(50) NULL DEFAULT NULL,
	Link NVARCHAR(100) NULL DEFAULT NULL,
	Active TINYINT NULL DEFAULT NULL
)
--- Img Type----
CREATE PROCEDURE sp_ImgType_GetById
	@Id		int
AS
	SELECT * FROM ImgType WHERE Id = @Id

GO
CREATE PROCEDURE sp_ImgType_GetByAll
AS
	SELECT * FROM ImgType
GO
CREATE PROCEDURE sp_ImageType_GetByTop
@Top	nvarchar(10),
@Where	nvarchar(200),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Select @SQL = 'SELECT top (' + @Top + ') * FROM ImgType'
	if len(@Top) = 0 
		BEGIN
			Select @SQL = 'SELECT * FROM ImgType'
		END
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)

--- ImagesDetail ---
CREATE PROC sp_ImagesDetail_GetById
	@Id int 
AS 
SELECT * FROM ImagesDetail WHERE Id= @Id 
GO

CREATE PROC sp_ImagesDetail_GetByAll
AS
SELECT * FROM ImagesDetail
GO
CREATE  PROCEDURE sp_User_GetByAll
AS
	SELECT * FROM Users
GO
CREATE PROC SP_User_GetById
@Id		int
AS
	SELECT * FROM [Users] WHERE Id = @Id
GO

CREATE PROC sp_ImagesDetail_Delete
	@Id int 
AS
begin 
Delete FROM ImagesDetail where Id= @ID
end 
go

CREATE PROC sp_ImagesDetail_Insert
	@Name nvarchar(512) ,
	@Image nvarchar(500),
	@ImagesId varchar(50),
	@Active int ,
	@Summary ntext
AS
	INSERT INTO ImagesDetail(Name, Image, ImagesId, Active, Summary)
	VALUES(@Name, @Username, @Password, @Admin, @Active, @Image, @DateCreate, @Role, @ModuleId, @ModuleName)
GO

ALTER PROCEDURE sp_ImagesDetail_Update
	@Id		int,
	@Name		nvarchar(512),
	@Image		ntext,
	@ImagesId		varchar(50),
	@Active		int,
	@Summary ntext
AS
	UPDATE ImagesDetail SET Name = @Name, Image = @Image, ImagesId = @ImagesId, Active = @Active , Summary = @Summary
	 WHERE Id = @Id




CREATE PROC sp_ImagesDetail_Delete
	@Id int 
as 
delete from ImagesDetail where Id= @Id

CREATE PROCEDURE sp_ImagesDetail_GetByTop
@Top	nvarchar(10),
@Where	nvarchar(200),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Select @SQL = 'SELECT top (' + @Top + ') * FROM [ImagesDetail]'
	if len(@Top) = 0 
		BEGIN
			Select @SQL = 'SELECT * FROM [ImagesDetail]'
		END
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
--- User------
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

--- Module --- 
Create proc sp_Module_GetByAll
AS
	SELECT * FROM Module
GO
Create proc sp_Module_GetById
	@Id int
AS
	SELECT * FROM Module where Id= @Id
GO
Create PROCEDURE sp_Module_GetByTop
@Top	nvarchar(10),
@Where	nvarchar(200),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Select @SQL = 'SELECT top (' + @Top + ') * FROM Module'
	if len(@Top) = 0 
		BEGIN
			Select @SQL = 'SELECT * FROM Module'
		END
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
CREATE PROCEDURE sp_Module_Getlistmodule
	@ModuleId		varchar(100)
	
AS

begin
		select * into #A from dbo.splitstring (@ModuleId)
	select * from Module inner join #A on Module.Id =  #A.Name
		drop table #A
	end
GO

CREATE PROC sp_Module_Insert 
	@Name		nvarchar(50),
	@Idcha		int,
	@Ord		tinyint,
	@Icon		varchar(50),
	@Link		nvarchar(100),
	@Active		tinyint
AS
	INSERT INTO Module(Name, Idcha, Ord, Icon, Link, Active)
	VALUES(@Name, @Idcha, @Ord, @Icon, @Link, @Active)
GO
CREATE PROC sp_Module_Update
	@Id 		int,
	@Name		nvarchar(50),
	@Idcha		int,
	@Ord		tinyint,
	@Icon		varchar(50),
	@Link		nvarchar(100),
	@Active		tinyint
AS
UPDATE Module SET Name = @Name, Idcha = @Idcha, Ord = @Ord, Icon = @Icon, Link = @Link, Active = @Active
	 WHERE Id = @Id
GO
CREATE proc sp_Module_Delete 
	@Id int
AS 
Delete From Module where Id=@Id