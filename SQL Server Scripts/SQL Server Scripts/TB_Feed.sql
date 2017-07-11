USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED]    Script Date: 2017-04-27 5:21:11 PM ******/
GO
DROP TABLE [dbo].[TB_Feed]
GO

/****** Object:  Table [dbo].[TB_FEED]    Script Date: 2017-04-27 5:21:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Feed](
	[FeedId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FeedTypeId] [int] NOT NULL,
 CONSTRAINT [PK_feed] PRIMARY KEY CLUSTERED 
(
	[FeedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE TB_Feed ADD CONSTRAINT FK_Feed_FeedType FOREIGN KEY (FeedTypeId) REFERENCES TB_FeedType(FeedTypeId);