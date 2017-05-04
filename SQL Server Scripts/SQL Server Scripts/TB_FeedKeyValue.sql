USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED_KEY_VALUE]    Script Date: 2017-04-27 5:21:31 PM ******/
DROP TABLE [dbo].[TB_FeedKeyValue]
GO

/****** Object:  Table [dbo].[TB_FEED_KEY_VALUE]    Script Date: 2017-04-27 5:21:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FeedKeyValue](
	KeyValueId [int] IDENTITY(1,1) NOT NULL,
	FeedId [int] NOT NULL,
	Chave [nvarchar](100) NOT NULL,
	Valor [nvarchar](1000) NOT NULL,
	FeedSpecific [bit] NOT NULL,
 CONSTRAINT [PK_FeedKeyValue] PRIMARY KEY CLUSTERED 
(
	[KeyValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],

CONSTRAINT [UK_FeedKeyValue] UNIQUE NONCLUSTERED 
(
	[FeedId] ASC,
	[Chave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


) ON [PRIMARY]

GO


