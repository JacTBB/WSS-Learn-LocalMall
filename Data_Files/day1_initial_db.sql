

/****** Object:  Table [dbo].[Mall]    Script Date: 9/8/2015 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

DROP DATABASE IF EXISTS LocalMall 
GO
CREATE DATABASE LocalMall;
GO
USE [LocalMall];

CREATE TABLE [dbo].[Mall](
	[MallId] [varchar](30) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Street] [nvarchar](128) NOT NULL,
	[PostalCode] [char](6) NOT NULL,
	[Website] [varchar](128) NULL,
	[Lat] [float] NULL,
	[Lng] [float] NULL,
	[Description] [nvarchar](500) NULL,
	[NumOfLikes] [int] NOT NULL,
	[Tel] [char](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[MallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Store]    Script Date: 9/8/2015 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Store](
	[StoreId] [int] NOT NULL,
	[MallId] [varchar](30) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Level] [nvarchar](4) NOT NULL,
	[Unit] [nvarchar](16) NULL,
	[Website] [varchar](128) NULL,
	[Tel] [char](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreCategory]    Script Date: 9/8/2015 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreCategory](
	[CatCode] [varchar](16) NOT NULL,
	[Name] [varchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CatCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreCategoryRef]    Script Date: 9/8/2015 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreCategoryRef](
	[StoreId] [int] NOT NULL,
	[CatCode] [varchar](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CatCode] ASC,
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Mall] ADD  DEFAULT ((0)) FOR [NumOfLikes]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_ToMall] FOREIGN KEY([MallId])
REFERENCES [dbo].[Mall] ([MallId])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_ToMall]
GO
ALTER TABLE [dbo].[StoreCategoryRef]  WITH CHECK ADD  CONSTRAINT [FK_StoreCategoryRef_ToStore] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([StoreId])
GO
ALTER TABLE [dbo].[StoreCategoryRef] CHECK CONSTRAINT [FK_StoreCategoryRef_ToStore]
GO
ALTER TABLE [dbo].[StoreCategoryRef]  WITH CHECK ADD  CONSTRAINT [FK_StoreCategoryRef_ToStoreCat] FOREIGN KEY([CatCode])
REFERENCES [dbo].[StoreCategory] ([CatCode])
GO
ALTER TABLE [dbo].[StoreCategoryRef] CHECK CONSTRAINT [FK_StoreCategoryRef_ToStoreCat]
GO

CREATE TABLE [dbo].[User] (
    [UserId] VARCHAR (64) NOT NULL,
    [Pwd]    VARCHAR (32) NOT NULL,
    [Role]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO