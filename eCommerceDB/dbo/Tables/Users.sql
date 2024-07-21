CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [UserName] VARCHAR(100) NOT NULL, 
    [Name] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(100) NOT NULL
)
