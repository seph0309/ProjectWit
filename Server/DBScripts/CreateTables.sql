USE [WIT]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
	INSERTS USER IN WIT_USER USING ASPNETUSERS.ID
*/
CREATE PROCEDURE [dbo].[CreateUser]
@Id NVARCHAR(128),
@FirstName	NVARCHAR(20),
@MiddleName	NVARCHAR(20),
@LastName	NVARCHAR(20),
@Company_UID	UNIQUEIDENTIFIER,
@EmailAddress	NVARCHAR(20),
@ModifiedBy		NVARCHAR(20)
AS

INSERT INTO Wit_User(User_UID,FirstName,MiddleName,LastName,Company_UID,EmailAddress,ModifiedBy)
VALUES	(@Id,@FirstName,@MiddleName,@LastName,@Company_UID,@EmailAddress,@ModifiedBy)

/*Add default role (GUEST) for the newly added user*/
INSERT INTO AspNetUserRoles(RoleId,UserId)
VALUES
('31CAA23C-A8CE-4F25-B737-C435AD71A444',@Id)





GO
/****** Object:  StoredProcedure [dbo].[spCreateDummyData]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	EXEC spCreateDummyData '299A2AD2-B6A4-47E8-A66A-CA84333AF7C0','SYSADMIN'
*/
CREATE PROCEDURE [dbo].[spCreateDummyData]
(
@UserID	 NVARCHAR(MAX),
@UserName NVARCHAR(MAX)
)AS

INSERT INTO AspNetUsers(Id,UserName,PasswordHash,SecurityStamp,Discriminator)
VALUES (@UserID ,@UserName, 'AKhzjiA1IUNU/1oocYMYx48xteD7aBOCPr/pUiH4e1M/ikFMxDvr1vCxclpCDjsgwQ==',
'2c98d373-0c1b-4112-8b97-6ff5bb17b1ef','ApplicationUser' )

INSERT INTO Wit_User(User_UID, FirstName,MiddleName,LastName,Company_UID,EmailAddress)
VALUES (@UserID ,@UserName, 'S',@UserName,'2D5BDCD6-7237-E411-90A1-EC9A7436DA60','seph0309@gmail.com')

IF @UserName='SYSADMIN'
BEGIN
	INSERT INTO AspNetUserRoles (UserId,RoleId)
	SELECT @UserID ,Id FROM AspNetRoles
END
ELSE 
BEGIN
	INSERT INTO AspNetUserRoles (UserId,RoleId)
	SELECT @UserID ,Id FROM AspNetRoles WHERE Name=@UserName
END


GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Category]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Category](
	[Category_UID] [uniqueidentifier] NOT NULL,
	[Company_UID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Company]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Company](
	[Company_UID] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[CompanyAddress] [nvarchar](100) NULL,
	[CompanyNumber] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Company_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Item]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Item](
	[Item_UID] [uniqueidentifier] NOT NULL,
	[Category_UID] [uniqueidentifier] NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemDescription] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](500) NULL,
	[OnStock] [bit] NOT NULL,
	[SpiceLevel] [nvarchar](20) NULL,
	[Likes] [int] NULL,
	[FoodMark] [nvarchar](20) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DiscountedPrice] [decimal](18, 2) NOT NULL,
	[IsBestSeller] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK__Wit_Item__924FBB2C46F1ABD1] PRIMARY KEY CLUSTERED 
(
	[Item_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_NavBar]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_NavBar](
	[NavBar_UID] [uniqueidentifier] NOT NULL,
	[Menu] [nvarchar](50) NOT NULL,
	[SubMenu] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](500) NULL,
 CONSTRAINT [PK_Wit_NavBar] PRIMARY KEY CLUSTERED 
(
	[NavBar_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Order]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Order](
	[Order_UID] [uniqueidentifier] NOT NULL,
	[Transaction_UID] [uniqueidentifier] NOT NULL,
	[Item_UID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Status]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Status](
	[Status_UID] [uniqueidentifier] NOT NULL,
	[Company_UID] [uniqueidentifier] NOT NULL,
	[SatusDescription] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Table]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Table](
	[Table_UID] [uniqueidentifier] NOT NULL,
	[Company_UID] [uniqueidentifier] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[TableDescription] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Table_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Transaction]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Transaction](
	[Transaction_UID] [uniqueidentifier] NOT NULL,
	[Table_UID] [uniqueidentifier] NOT NULL,
	[NumberOfGuest] [int] NULL,
	[Status_UID] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Transaction_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_User]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_User](
	[User_UID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[MiddleName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Company_UID] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](20) NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[UsersViewModel]    Script Date: 10/8/2014 7:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[UsersViewModel]
AS
SELECT Wit_User.User_UID,AspNetUsers.UserName,Wit_User.FirstName,Wit_User.MiddleName,Wit_User.LastName,
Wit_User.EmailAddress,Wit_User.ModifiedBy,Wit_User.ModifiedDate,Wit_Company.Company_UID,Wit_Company.CompanyName,
Wit_Company.CompanyNumber,Wit_Company.CompanyAddress
FROM Wit_User
INNER JOIN AspNetUsers ON Wit_User.User_UID= AspNetUsers.Id
INNER JOIN Wit_Company ON Wit_User.Company_UID = Wit_Company.Company_UID



GO
ALTER TABLE [dbo].[Wit_Category] ADD  DEFAULT (newsequentialid()) FOR [Category_UID]
GO
ALTER TABLE [dbo].[Wit_Category] ADD  CONSTRAINT [DF_Wit_Category_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_Company] ADD  DEFAULT (newsequentialid()) FOR [Company_UID]
GO
ALTER TABLE [dbo].[Wit_Company] ADD  CONSTRAINT [DF_Wit_Company_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_Item] ADD  CONSTRAINT [DF__Wit_Item__Item_U__31EC6D26]  DEFAULT (newsequentialid()) FOR [Item_UID]
GO
ALTER TABLE [dbo].[Wit_Item] ADD  CONSTRAINT [DF_Wit_Item_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Wit_Item] ADD  CONSTRAINT [DF_Wit_Item_DiscountedPrice]  DEFAULT ((0)) FOR [DiscountedPrice]
GO
ALTER TABLE [dbo].[Wit_Item] ADD  CONSTRAINT [DF_Wit_Item_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_NavBar] ADD  CONSTRAINT [DF_Wit_NavBar_NavBar_UID]  DEFAULT (newsequentialid()) FOR [NavBar_UID]
GO
ALTER TABLE [dbo].[Wit_Order] ADD  DEFAULT (newsequentialid()) FOR [Order_UID]
GO
ALTER TABLE [dbo].[Wit_Order] ADD  CONSTRAINT [DF_Wit_Order_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_Status] ADD  DEFAULT (newsequentialid()) FOR [Status_UID]
GO
ALTER TABLE [dbo].[Wit_Table] ADD  DEFAULT (newsequentialid()) FOR [Table_UID]
GO
ALTER TABLE [dbo].[Wit_Table] ADD  CONSTRAINT [DF_Wit_Table_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_Transaction] ADD  DEFAULT (newsequentialid()) FOR [Transaction_UID]
GO
ALTER TABLE [dbo].[Wit_Transaction] ADD  CONSTRAINT [DF_Wit_Transaction_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Wit_User] ADD  DEFAULT (newsequentialid()) FOR [User_UID]
GO
ALTER TABLE [dbo].[Wit_User] ADD  CONSTRAINT [DF_Wit_User_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Wit_Category]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Category_Wit_Company] FOREIGN KEY([Company_UID])
REFERENCES [dbo].[Wit_Company] ([Company_UID])
GO
ALTER TABLE [dbo].[Wit_Category] CHECK CONSTRAINT [FK_Wit_Category_Wit_Company]
GO
ALTER TABLE [dbo].[Wit_Item]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Item_Wit_Category] FOREIGN KEY([Category_UID])
REFERENCES [dbo].[Wit_Category] ([Category_UID])
GO
ALTER TABLE [dbo].[Wit_Item] CHECK CONSTRAINT [FK_Wit_Item_Wit_Category]
GO
ALTER TABLE [dbo].[Wit_Order]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Order_Wit_Item] FOREIGN KEY([Item_UID])
REFERENCES [dbo].[Wit_Item] ([Item_UID])
GO
ALTER TABLE [dbo].[Wit_Order] CHECK CONSTRAINT [FK_Wit_Order_Wit_Item]
GO
ALTER TABLE [dbo].[Wit_Order]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Order_Wit_Transaction] FOREIGN KEY([Transaction_UID])
REFERENCES [dbo].[Wit_Transaction] ([Transaction_UID])
GO
ALTER TABLE [dbo].[Wit_Order] CHECK CONSTRAINT [FK_Wit_Order_Wit_Transaction]
GO
ALTER TABLE [dbo].[Wit_Status]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Status_Wit_Company] FOREIGN KEY([Company_UID])
REFERENCES [dbo].[Wit_Company] ([Company_UID])
GO
ALTER TABLE [dbo].[Wit_Status] CHECK CONSTRAINT [FK_Wit_Status_Wit_Company]
GO
ALTER TABLE [dbo].[Wit_Table]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Table_Wit_Company] FOREIGN KEY([Company_UID])
REFERENCES [dbo].[Wit_Company] ([Company_UID])
GO
ALTER TABLE [dbo].[Wit_Table] CHECK CONSTRAINT [FK_Wit_Table_Wit_Company]
GO
ALTER TABLE [dbo].[Wit_Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Transaction_Wit_Status] FOREIGN KEY([Status_UID])
REFERENCES [dbo].[Wit_Status] ([Status_UID])
GO
ALTER TABLE [dbo].[Wit_Transaction] CHECK CONSTRAINT [FK_Wit_Transaction_Wit_Status]
GO
ALTER TABLE [dbo].[Wit_Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Wit_Transaction_Wit_Table] FOREIGN KEY([Table_UID])
REFERENCES [dbo].[Wit_Table] ([Table_UID])
GO
ALTER TABLE [dbo].[Wit_Transaction] CHECK CONSTRAINT [FK_Wit_Transaction_Wit_Table]
GO
ALTER TABLE [dbo].[Wit_User]  WITH CHECK ADD  CONSTRAINT [FK_Wit_User_Wit_Company] FOREIGN KEY([Company_UID])
REFERENCES [dbo].[Wit_Company] ([Company_UID])
GO
ALTER TABLE [dbo].[Wit_User] CHECK CONSTRAINT [FK_Wit_User_Wit_Company]
GO
