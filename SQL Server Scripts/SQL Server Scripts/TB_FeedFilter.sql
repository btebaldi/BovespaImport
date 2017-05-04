USE [TebaldiMarketData]
GO

--ALTER TABLE [dbo].[TB_FEED_MAPPING] DROP CONSTRAINT [FK_FeedId_Mapping]
GO

/****** Object:  Table [dbo].[TB_FEED_MAPPING]    Script Date: 2017-04-27 5:21:42 PM ******/
DROP TABLE [dbo].[TB_FeedFilter]
GO

/****** Object:  Table [dbo].[TB_FEED_MAPPING]    Script Date: 2017-04-27 5:21:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FeedFilter](
	--[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[ColumnName] [nvarchar](50) NULL,
	[ColumnValue] [nvarchar](50) NULL,
) ON [PRIMARY]

GO

--ALTER TABLE [dbo].[TB_FEED_MAPPING]  WITH CHECK ADD  CONSTRAINT [FK_FeedId_Mapping] FOREIGN KEY([FeedId])
--REFERENCES [dbo].[TB_FEED] ([FeedId])
--ON DELETE CASCADE
--GO

--ALTER TABLE [dbo].[TB_FEED_MAPPING] CHECK CONSTRAINT [FK_FeedId_Mapping]
--GO


