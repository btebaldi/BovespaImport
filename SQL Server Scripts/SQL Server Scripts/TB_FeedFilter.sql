USE [TebaldiMarketData]
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[ColumnName] [nvarchar](50) NULL,
	[ColumnValue] [nvarchar](50) NULL,
) ON [PRIMARY]


GO
ALTER TABLE TB_FeedFilter ADD CONSTRAINT FK_Filter_FeedId FOREIGN KEY (FeedId) REFERENCES TB_Feed(FeedId);

