USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED]    Script Date: 2017-04-27 5:21:11 PM ******/
DROP TABLE [dbo].[TB_FEED]
GO

/****** Object:  Table [dbo].[TB_FEED]    Script Date: 2017-04-27 5:21:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ImpProcess](
	[ProcessId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FeedType] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ImpProcess] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


