GO
IF NOT EXISTS(SELECT TOP 1 1 FROM Users WHERE UserName = 'Jaswanth123')
BEGIN
	INSERT [dbo].[Users] ([UserName], [Name], [Email], [Password]) VALUES (N'Jaswanth123', N'Jaswanth Bommu', N'jaswanth@gmail.com', N'Test@123')
	DECLARE @IdentUserId INT = IDENT_CURRENT('Users')
	
	INSERT [dbo].[UserRoles] ([UserId], [RoleName]) VALUES (@IdentUserId, N'Admin')
	INSERT [dbo].[UserRoles] ([UserId], [RoleName]) VALUES (@IdentUserId, N'User')
END
GO
IF NOT EXISTS(SELECT TOP 1 1 FROM Users WHERE UserName = 'Aravind')
BEGIN
	INSERT [dbo].[Users] ([UserName], [Name], [Email], [Password]) VALUES (N'Aravind', N'Aravind Marka', N'aravind@gmail.com', N'Test@123')
	DECLARE @IdentUserId INT = IDENT_CURRENT('Users')
	
	INSERT [dbo].[UserRoles] ([UserId], [RoleName]) VALUES (@IdentUserId, N'Admin')
END
GO