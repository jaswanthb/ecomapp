CREATE TABLE [dbo].[UserRoles]
(
	[Id] INT NOT NULL PRIMARY KEY  identity(1,1), 
    [UserId] INT NOT NULL, 
    [RoleName] VARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id])
)
