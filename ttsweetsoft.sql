CREATE DATABASE CMSTT

go
use CMSTT
--- Tạo bảng user---- 
go

CREATE TABLE Users( 
	"Id" INT PRIMARY KEY,
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


