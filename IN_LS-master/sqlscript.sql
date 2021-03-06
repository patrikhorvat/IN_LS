USE [master]
GO
/****** Object:  Database [dbAutori]    Script Date: 3.1.2019. 0:08:03 ******/
CREATE DATABASE [dbAutori]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbAutori', FILENAME = N'E:\SQLServer\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbAutori.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbAutori_log', FILENAME = N'E:\SQLServer\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbAutori_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbAutori] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbAutori].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbAutori] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbAutori] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbAutori] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbAutori] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbAutori] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbAutori] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbAutori] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbAutori] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbAutori] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbAutori] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbAutori] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbAutori] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbAutori] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbAutori] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbAutori] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbAutori] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbAutori] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbAutori] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbAutori] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbAutori] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbAutori] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbAutori] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbAutori] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbAutori] SET  MULTI_USER 
GO
ALTER DATABASE [dbAutori] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbAutori] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbAutori] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbAutori] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbAutori] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbAutori] SET QUERY_STORE = OFF
GO
USE [dbAutori]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3.1.2019. 0:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[DateModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [Key1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NULL,
	[Name] [nvarchar](2000) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ShortContent] [nvarchar](max) NULL,
	[GenreId] [int] NULL,
	[Year] [date] NULL,
	[LastModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vBooks]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vBooks]
AS
select 
	B.Id,
	B.DateCreated,
	B.UserCreated,
	UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
	B.Name,
	B.Description,
	B.ShortContent,
	B.GenreId,
	G.Name AS GenreName,
    B.LastModified,
	B.UserLastModified,
	ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName
from dbo.Book B
LEFT OUTER JOIN dbo.Genre G
On G.Id = B.GenreId
LEFT OUTER JOIN dbo.UserInfo UC
ON UC.Id = B.UserCreated
LEFT OUTER JOIN dbo.UserInfo ULM
ON ULM.Id = B.UserLastModified
WHERE B.Active = 1
GO
/****** Object:  Table [dbo].[Author]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[DeathDate] [date] NULL,
	[DeathPlace] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [varchar](max) NULL,
	[LastModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book.Author]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book.Author](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_Book.Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriber]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriber](
	[Id] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[LName] [nvarchar](50) NOT NULL,
	[BooksReserved] [int] NOT NULL,
 CONSTRAINT [PK_Subscriber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](500) NULL,
	[CreationDate] [datetime] NULL,
	[ApprovalDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[IsLocked] [bit] NOT NULL,
	[PasswordQuestion] [nvarchar](max) NULL,
	[PasswordAnswer] [nvarchar](max) NULL,
	[ActivationToken] [nvarchar](200) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime2](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UX_User_EMail] UNIQUE NONCLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UX_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistrationToken]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistrationToken](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Token] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SecurityToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UX_UserRegistrationToken_Token] UNIQUE NONCLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_EmailConfirmed]  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_PhoneNumberConfirmed]  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_TwoFactorEnabled]  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_AccessFailCount]  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[Author]  WITH CHECK ADD  CONSTRAINT [FK_Author_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Author] CHECK CONSTRAINT [FK_Author_UserInfo]
GO
ALTER TABLE [dbo].[Author]  WITH CHECK ADD  CONSTRAINT [FK_Author_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Author] CHECK CONSTRAINT [FK_Author_UserInfo1]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Genre]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_UserInfo]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_UserInfo1]
GO
ALTER TABLE [dbo].[Book.Author]  WITH CHECK ADD  CONSTRAINT [FK_Book.Author_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Book.Author] CHECK CONSTRAINT [FK_Book.Author_Author]
GO
ALTER TABLE [dbo].[Book.Author]  WITH CHECK ADD  CONSTRAINT [FK_Book.Author_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[Book.Author] CHECK CONSTRAINT [FK_Book.Author_Book]
GO
ALTER TABLE [dbo].[Genre]  WITH CHECK ADD  CONSTRAINT [FK_Genre_Genre] FOREIGN KEY([Id])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Genre] CHECK CONSTRAINT [FK_Genre_Genre]
GO
ALTER TABLE [dbo].[Genre]  WITH CHECK ADD  CONSTRAINT [FK_Genre_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Genre] CHECK CONSTRAINT [FK_Genre_UserInfo]
GO
ALTER TABLE [dbo].[Genre]  WITH CHECK ADD  CONSTRAINT [FK_Genre_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Genre] CHECK CONSTRAINT [FK_Genre_UserInfo1]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [Relationship6] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [Relationship6]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
/****** Object:  StoredProcedure [dbo].[Author.Delete]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Author.Delete]
	@Id INT,
	@LastModified DATETIMEOFFSET(0),
	@UserLastModified INT
AS
BEGIN
	UPDATE dbo.Author
		SET 
		Active = 0,
		LastModified = @LastModified,
		UserLastModified = @UserLastModified
		WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Author.Get]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Author.Get]
	@Id INT
AS
BEGIN
	SELECT A.Id,
           A.Active,
           A.DateCreated,
           A.UserCreated,
		   U1.FirstName + ' ' + U1.LastName AS UserCreatedFullName,
           A.FirstName,
           A.LastName,
           A.LastModified,
           A.UserLastModified,
		   U2.FirstName + ' ' + U2.LastName AS UserLastModifiedFullName,
		   		   A.BirthDate,
		   A.BirthPlace,
		   A.DeathDate,
		   A.DeathPlace,
		   A.Description,
		   A.Url
		   FROM dbo.Author A
		   INNER JOIN dbo.UserInfo U1
		   ON U1.Id = A.UserCreated
		   LEFT OUTER JOIN dbo.UserInfo U2
		   ON U2.Id = A.UserLastModified
		   WHERE A.Id = @Id AND A.Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Author.GetAll]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Author.GetAll]

AS
BEGIN
	SELECT A.Id,
           A.Active,
           A.DateCreated,
           A.UserCreated,
		   U1.FirstName + ' ' + U1.LastName AS UserCreatedFullName,
           A.FirstName,
           A.LastName,
           A.LastModified,
           A.UserLastModified,
		   U2.FirstName + ' ' + U2.LastName AS UserLastModifiedFullName,
		   A.BirthDate,
		   A.BirthPlace,
		   A.DeathDate,
		   A.DeathPlace,
		   A.Description,
		   A.Url
		   FROM dbo.Author A
		   INNER JOIN dbo.UserInfo U1
		   ON U1.Id = A.UserCreated
		   LEFT OUTER JOIN dbo.UserInfo U2
		   ON U2.Id = A.UserLastModified
		   WHERE A.Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Author.Insert]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Author.Insert]
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@DateCreated DATETIMEOFFSET(0),
	@UserCreated INT,
	@BirthDate DATETIME,
	@BirthPlace VARCHAR(50),
	@DeathDate DATETIME,
	@DeathPlace VARCHAR(50),
	@Description VARCHAR(MAX),
	@Url VARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.Author
	(
	    Active,
	    DateCreated,
	    UserCreated,
	    FirstName,
	    LastName,
		BirthDate,
		BirthPlace,
		DeathDate,
		DeathPlace,
		Description,
		Url,
	    LastModified,
	    UserLastModified
	)
	VALUES
	(   1,                -- Active - bit
	    @DateCreated, -- DateCreated - datetimeoffset(0)
	    @UserCreated,                   -- UserCreated - int
	    @FirstName,                 -- FirstName - nvarchar(50)
	    @LastName,                 -- LastName - nvarchar(50)
		@BirthDate,
		@BirthPlace,
		@DeathDate,
		@DeathPlace,
		@Description,
		@Url,
	    NULL, -- LastModified - datetimeoffset(0)
	    NULL                   -- UserLastModified - int
	    )

	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[Author.Save]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Author.Save]
	@Id INT,
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@BirthDate DATETIME,
	@BirthPlace VARCHAR(50),
	@DeathDate DATETIME,
	@DeathPlace VARCHAR(50),
	@Description VARCHAR(MAX),
	@Url VARCHAR(MAX),
	@LastModified DATETIMEOFFSET(0),
	@UserLastModified INT
AS
BEGIN
	UPDATE dbo.Author
		SET 
		FirstName = @FirstName,
		LastName = @LastName,
		BirthDate=@BirthDate,
		BirthPlace=@BirthPlace,
		DeathDate=@DeathDate,
		DeathPlace=@DeathPlace,
		Description=@Description,
		Url=@Url,
		LastModified = @LastModified,
		UserLastModified = @UserLastModified
		WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Book.Authors.GetAll]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book.Authors.GetAll]
@BookId INT
AS 
BEGIN
		SELECT A.Id,
           A.FirstName,
           A.LastName,
		   A.FirstName + ' ' + A.LastName AS AuthorFullName
		   FROM dbo.Author A
		   WHERE A.Active = 1
			AND A.Id IN (SELECT AuthorId FROM dbo.[Book.Author] WHERE BookId = @BookId)
END
GO
/****** Object:  StoredProcedure [dbo].[Book.DeleteBook]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Book.DeleteBook]
	@Id INT,
	@DateModified DATETIMEOFFSET(0)
	
AS
BEGIN
	UPDATE dbo.Book
		SET 
		Active = 0,
		DateModified = @DateModified
		
		WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Book.GetAllBooks]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Book.GetAllBooks]

AS
BEGIN
	SELECT * FROM dbo.vBooks
END
GO
/****** Object:  StoredProcedure [dbo].[Book.GetBook]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Book.GetBook]

@Id INT

AS
BEGIN
	SELECT * FROM dbo.vBooks WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Book.InsertBook]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Book.InsertBook]
	
	@DateCreated DATETIMEOFFSET(0),
	@CreatedBy INT,
	@Name VARCHAR(50),
	@Description VARCHAR(MAX),
	@ShortContent VARCHAR(MAX),
	@Genre VARCHAR(50),
	@Year DATE,
	@Author VARCHAR(50),
	@DateModified DATETIMEOFFSET(0)
AS
BEGIN
	--INSERT INTO dbo.Book
	--(
	--    Active,
	--	DateCreated,
	--	CreatedBy,
	--	Name ,
	--	Description,
	--	ShortContent,
	--	Genre,
	--	Year,
	--	Author,
	--	DateModified
	--)
	--VALUES
	--(   1,                -- Active - bit
	--   	@DateCreated,
	--	@CreatedBy,
	--	@Name,
	--	@Description,
	--	@ShortContent,
	--	@Genre,
	--	@Year,
	--	@Author,
	--	@DateModified
	--    )

	--SELECT CAST(SCOPE_IDENTITY() AS INT)
	SELECT 1
END
GO
/****** Object:  StoredProcedure [dbo].[Book.SaveBook]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Book.SaveBook]
	@Id INT,
	@DateCreated DATETIMEOFFSET(0),
	@CreatedBy INT,
	@Name VARCHAR(50),
	@Description VARCHAR(MAX),
	@ShortContent VARCHAR(MAX),
	@Genre VARCHAR(50),
	@Year DATE,
	@Author VARCHAR(50),
	@DateModified DATETIMEOFFSET(0)
	
AS
BEGIN
	--UPDATE dbo.Book
	--	SET 

	--	DateCreated=@DateCreated,
	--	CreatedBy=@CreatedBy,
	--	Name = @Name,
	--	Description=@Description,
	--	ShortContent=@ShortContent,
	--	Genre=@Genre,
	--	Year=@Year,
	--	Author=@Author,
	--	DateModified=@DateModified

	--	WHERE Id = @Id
	SELECT 1
END
GO
/****** Object:  StoredProcedure [dbo].[Genre.DeleteGenre]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Genre.DeleteGenre]
	@Id INT,
	@DateModified DATETIMEOFFSET(0)
	
AS
BEGIN
	UPDATE dbo.Genre
		SET 
		Active = 0,
		DateModified = @DateModified
		
		WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Genre.GetAllGenres]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Genre.GetAllGenres]

AS
BEGIN
	SELECT A.Id,
           A.Active,
           A.DateCreated,
		   A.UserCreated,
		   U1.FirstName + ' ' + U1.LastName AS UserCreatedFullName,
           A.Name,
           A.Description,
		   A.DateModified,
		   A.UserLastModified,
		   U2.FirstName + ' ' + U2.LastName AS UserLastModifiedFullName

		   FROM dbo.Genre A
		   INNER JOIN dbo.UserInfo U1
		   ON U1.Id = A.UserCreated
		   LEFT OUTER JOIN dbo.UserInfo U2
		   ON U2.Id = A.UserLastModified
		   WHERE A.Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Genre.GetGenre]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Genre.GetGenre]

@Id INT

AS
BEGIN
	SELECT A.Id,
           A.Active,
           A.DateCreated,
           A.Name,
           A.Description,
		   A.DateModified
		   
		   FROM dbo.Genre A
		
		   WHERE A.Id = @Id AND A.Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Genre.InsertGenre]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Genre.InsertGenre]
	

	@DateCreated DATETIMEOFFSET(0),
	@UserCreated INT,
	@Name VARCHAR(50),
	@Description VARCHAR(MAX)
	
    

AS
BEGIN
	INSERT INTO dbo.Genre
	(
	    Active,
		DateCreated,
		UserCreated,
		Name ,
		Description,
		DateModified,
		UserLastModified
	)
	VALUES
	(   1,                
	   	@DateCreated,
		@UserCreated,
		@Name,
		@Description,
		NULL,
		NULL
	    )

	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[Genre.SaveGenre]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Genre.SaveGenre]

	@Id INT,
	@Name VARCHAR(50),
	@Description VARCHAR(MAX),
	@DateModified DATETIMEOFFSET(0),
	@UserLastModified INT
AS
BEGIN
	UPDATE dbo.Genre
		SET 
		Name = @Name,
		Description=@Description,
		DateModified = DateModified,
		UserLastModified = @UserLastModified
		WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Subscriber.Get]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subscriber.Get]
	@Id INT
AS
BEGIN
	SELECT A.Id,
           A.Active,
		   A.FName,
		   A.LName,
		   A.BooksReserved
         
		   FROM dbo.Subscriber A
		 
		   WHERE A.Id = @Id AND A.Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Subscriber.GetAll]    Script Date: 3.1.2019. 0:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subscriber.GetAll]

AS
BEGIN
	SELECT A.Id,
           A.Active,
		   A.FName,
		   A.LName,
		   A.BooksReserved
          
		   FROM dbo.Subscriber A
		   
		   WHERE A.Active = 1
END
GO
USE [master]
GO
ALTER DATABASE [dbAutori] SET  READ_WRITE 
GO
