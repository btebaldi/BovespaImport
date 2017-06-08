USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED_TB_FEED_TRANSFORMATION] ******/
DROP TABLE [dbo].[TB_FeedTransformation]
GO

/****** Object:  Table [dbo].[TB_FEED_TB_FEED_TRANSFORMATION] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FeedTransformation](
	[TransformationId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] int NOT NULL,
	[ExecuteOrder] int NOT NULL,
	[OriginalValue] [nvarchar](50) NOT NULL, 
	[OriginalColumn] [nvarchar](50) NOT NULL, 
	[NewValue] [nvarchar](50) NOT NULL, 
	[NewColumn] [nvarchar](50) NOT NULL, 
	CONSTRAINT [PK_Transformation] PRIMARY KEY CLUSTERED 
(
	[TransformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE TB_FeedTransformation ADD CONSTRAINT FK_Trans_FeedId FOREIGN KEY (FeedId) REFERENCES TB_Feed(FeedId);