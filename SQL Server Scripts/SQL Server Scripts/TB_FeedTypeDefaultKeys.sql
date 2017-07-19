USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FeedType]    Script Date: 2017-05-18 3:48:38 PM ******/
ALTER TABLE TB_FeedTypeDefaultKeys DROP CONSTRAINT FK_FeedTypeDefaulKeys;
GO
DROP TABLE [dbo].[TB_FeedTypeDefaultKeys]
GO

/****** Object:  Table [dbo].[TB_FeedType]    Script Date: 2017-05-18 3:48:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FeedTypeDefaultKeys](
	[DefaultKeyId] INT IDENTITY(1,1) NOT NULL,
	[FeedTypeId] [int] NOT NULL,
	[Chave]		 [nvarchar](100) NOT NULL,
 ) ON [PRIMARY]

GO

ALTER TABLE TB_FeedTypeDefaultKeys ADD CONSTRAINT FK_FeedTypeDefaulKeys FOREIGN KEY (FeedTypeId) REFERENCES TB_FeedType(FeedTypeId);


/*
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (1, 'SiteAddress')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (1, 'FileMask')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (1, 'SaveDownloadAs')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (1, 'ExtractAs')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (1, 'SearchInZip')

Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (2, 'DataCode')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (2, 'ApiKey')
Insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES (2, 'ColumnValue')
*/