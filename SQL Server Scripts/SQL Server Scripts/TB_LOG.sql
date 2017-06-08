USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_LOG]    Script Date: 2017-04-27 5:26:55 PM ******/
DROP TABLE [dbo].[TB_LOG]
GO

/****** Object:  Table [dbo].[TB_LOG]    Script Date: 2017-04-27 5:26:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_LOG](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[log_date] [datetime] NOT NULL,
	[log_utcdate] [datetime] NOT NULL,
	[Log_Level] [nvarchar](50) NOT NULL,
	[Logger] [nvarchar](255) NOT NULL,
	[log_Message] [nvarchar](4000) NOT NULL,
	[Exception] [nvarchar](2000) NULL,
 CONSTRAINT [PK_TB_LOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


