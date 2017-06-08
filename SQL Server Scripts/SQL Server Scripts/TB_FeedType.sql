USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FeedType]    Script Date: 2017-06-02 11:36:20 AM ******/
DROP TABLE [dbo].[TB_FeedType]
GO

/****** Object:  Table [dbo].[TB_FeedType]    Script Date: 2017-06-02 11:36:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FeedType](
	[FeedTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EnumCode] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](50) NULL,
 CONSTRAINT [PK_TB_FeedType] PRIMARY KEY CLUSTERED 
(
	[FeedTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


