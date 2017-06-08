USE [TebaldiBovespa]
GO

/****** Object:  Table [dbo].[TB_FEED_PARAMETER] ******/
DROP TABLE [dbo].[TB_FEED_PARAMETER]
GO

/****** Object:  Table [dbo].[TB_FEED_PARAMETER] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FEED_PARAMETER](
		
    [ParameterId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[ParameterKey] [nvarchar](50) NOT NULL, 
	[ParameterValue] [nvarchar](50) NOT NULL,

	CONSTRAINT [FK_FeedId_Config] FOREIGN KEY([FeedId]) REFERENCES [dbo].[TB_FEED] ([FeedId]) ON DELETE CASCADE

) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[TB_FEED_PARAMETER] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FEED_PARAMETER_VALUE](
		
    [ParameterValueId] [int] IDENTITY(1,1) NOT NULL,
	[Desc] [nvarchar](150) NOT NULL, 

	CONSTRAINT [PK_ParameterValueId] PRIMARY KEY CLUSTERED ([ParameterValueId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO
