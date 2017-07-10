USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED_QUEUE]    Script Date: 2017-04-27 5:21:11 PM ******/
DROP TABLE [dbo].[TB_ProcessQueue]
GO

/****** Object:  Table [dbo].[TB_FEED_QUEUE]    Script Date: 2017-04-27 5:21:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ProcessQueue](
	[QueueId]			int IDENTITY(1,1) NOT NULL,
	[ProcessId]			int NOT NULL,
	[DtExecucao]		datetime NOT NULL,
	[DtReferencia]		date NULL,
	[Executado]			bit NOT NULL,
	[Success]			bit NOT NULL,

 CONSTRAINT PK_FEED_QUEUE PRIMARY KEY CLUSTERED 
(
	[QueueId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


