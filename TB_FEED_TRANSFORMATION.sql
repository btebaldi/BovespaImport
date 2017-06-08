USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED_TB_FEED_TRANSFORMATION] ******/
DROP TABLE [dbo].[TB_FEED_TB_FEED_TRANSFORMATION]
GO

/****** Object:  Table [dbo].[TB_FEED_TB_FEED_TRANSFORMATION] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FEED_TRANSFORMATION](
	
	[FeedId] int NOT NULL,
	[ExecuteOrder] int NOT NULL,
	[OriginalValue] [nvarchar](50) NOT NULL, 
	[OriginalColumn] [nvarchar](50) NOT NULL, 
	[OriginalType] [nvarchar](50) NOT NULL, 
	[NewValue] [nvarchar](50) NOT NULL, 
	[NewColumn] [nvarchar](50) NOT NULL, 
	[NewType] [nvarchar](50) NOT NULL, 

	CONSTRAINT [FK_FeedId_Ativo] FOREIGN KEY([FeedId]) REFERENCES [dbo].[TB_FEED] ([FeedId]) ON DELETE CASCADE

) ON [PRIMARY]

GO
