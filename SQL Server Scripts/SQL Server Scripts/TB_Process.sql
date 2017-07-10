USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_Process]  ******/
DROP TABLE [dbo].[TB_Process]
GO

/****** Object:  Table [dbo].[TB_Process]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Process](
	ProcessId		int IDENTITY(1,1) NOT NULL,
	FeedId			int NOT NULL,
	AutoQueue		bit NOT NULL,
	InUse			bit NOT NULL,

 CONSTRAINT PK_Process PRIMARY KEY CLUSTERED 
(
	ProcessId ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


insert into tb_process (FeedId, AutoQueue, InUse) values(1,1,1)