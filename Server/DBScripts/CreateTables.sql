USE [WIT]
GO
/****** Object:  Table [dbo].[Wit_Category]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_Company]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_Item]    Script Date: 8/31/2014 3:02:44 AM ******/
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
	[DiscountedPrice] [decimal](18, 2) NULL,
	[IsBestSeller] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Item_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Order]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_Role]    Script Date: 8/31/2014 3:02:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_Role](
	[Role_UID] [uniqueidentifier] NOT NULL,
	[RoleDescription] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Role_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_Status]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_Table]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_Transaction]    Script Date: 8/31/2014 3:02:44 AM ******/
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
/****** Object:  Table [dbo].[Wit_User]    Script Date: 8/31/2014 3:02:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_User](
	[User_UID] [uniqueidentifier] NOT NULL,
	[FirsName] [nvarchar](20) NULL,
	[MiddleName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Company_UID] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wit_UserRole]    Script Date: 8/31/2014 3:02:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wit_UserRole](
	[UserRole_UID] [uniqueidentifier] NOT NULL,
	[Role_UID] [uniqueidentifier] NOT NULL,
	[User_UID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRole_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Wit_Category] ADD  DEFAULT (newsequentialid()) FOR [Category_UID]
GO
ALTER TABLE [dbo].[Wit_Company] ADD  DEFAULT (newsequentialid()) FOR [Company_UID]
GO
ALTER TABLE [dbo].[Wit_Item] ADD  DEFAULT (newsequentialid()) FOR [Item_UID]
GO
ALTER TABLE [dbo].[Wit_Order] ADD  DEFAULT (newsequentialid()) FOR [Order_UID]
GO
ALTER TABLE [dbo].[Wit_Role] ADD  DEFAULT (newsequentialid()) FOR [Role_UID]
GO
ALTER TABLE [dbo].[Wit_Status] ADD  DEFAULT (newsequentialid()) FOR [Status_UID]
GO
ALTER TABLE [dbo].[Wit_Table] ADD  DEFAULT (newsequentialid()) FOR [Table_UID]
GO
ALTER TABLE [dbo].[Wit_Transaction] ADD  DEFAULT (newsequentialid()) FOR [Transaction_UID]
GO
ALTER TABLE [dbo].[Wit_User] ADD  DEFAULT (newsequentialid()) FOR [User_UID]
GO
ALTER TABLE [dbo].[Wit_UserRole] ADD  DEFAULT (newsequentialid()) FOR [UserRole_UID]
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
ALTER TABLE [dbo].[Wit_UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Wit_UserRole_Wit_Role] FOREIGN KEY([Role_UID])
REFERENCES [dbo].[Wit_Role] ([Role_UID])
GO
ALTER TABLE [dbo].[Wit_UserRole] CHECK CONSTRAINT [FK_Wit_UserRole_Wit_Role]
GO
ALTER TABLE [dbo].[Wit_UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Wit_UserRole_Wit_User] FOREIGN KEY([User_UID])
REFERENCES [dbo].[Wit_User] ([User_UID])
GO
ALTER TABLE [dbo].[Wit_UserRole] CHECK CONSTRAINT [FK_Wit_UserRole_Wit_User]
GO
