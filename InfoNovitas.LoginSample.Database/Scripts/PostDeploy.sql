﻿
SET IDENTITY_INSERT [dbo].[User] ON
GO

INSERT [dbo].[User] ([Id], [Login], [EMail], [Password], [CreationDate], [ApprovalDate], [LastLoginDate], [IsLocked], [PasswordQuestion], [PasswordAnswer], [ActivationToken], [EmailConfirmed], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'admin@info-novitas.hr', N'admin@info-novitas.hr', N'AP1XMzxDfFlsGWxQUsMFQepsqy8y4cy1x0y0ZIlp/jUtJuZeTtXpBY4pko4DLfD4YA==', NULL, NULL, NULL, 0, NULL, NULL, N'1', 0, N'0dfd8580-c7ca-41da-bdf1-31d50e2b8123', NULL, 0, 0, NULL, 0, 0)
GO

SET IDENTITY_INSERT [dbo].[User] OFF
GO

INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'System', N'Admin', N'admin@info-novitas.hr')
GO
