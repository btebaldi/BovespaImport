USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED_CONFIG] ******/
DROP TABLE [dbo].[TB_FEED_CONFIG]
GO

/****** Object:  Table [dbo].[TB_FEED_CONFIG] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FEED_CONFIG](
		
    [ConfigId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[FeederColumnIndex] [int] NULL, 
	[FeederColumnName] [nvarchar](50) NULL, 
	[FeederStaticValue] [nvarchar](50) NULL, 
	[Type] [nvarchar](50) NOT NULL,
	[DateTimeParseMask] [nvarchar](50) NULL,
	[Culture] [nvarchar](50) NOT NULL,
	[Destination] [nvarchar](50) NULL,

	CONSTRAINT [FK_FeedId_Config] FOREIGN KEY([FeedId]) REFERENCES [dbo].[TB_FEED] ([FeedId]) ON DELETE CASCADE

) ON [PRIMARY]

GO

