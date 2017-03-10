USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED] ******/
DROP TABLE [dbo].[TB_FEED]
GO

/****** Object:  Table [dbo].[TB_FEED] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_FEED](
	
    [FeedId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FeedType] [nvarchar](50) NOT NULL,
	[Origem] [nvarchar](1000) NOT NULL,
	[Active] [bit] NOT NULL,

	CONSTRAINT [PK_FEED] PRIMARY KEY CLUSTERED ([FeedId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO
/*

--TB_IMP_HISTORICO_COTACAO

DECLARE @mylastident AS int

insert into TB_FEED (Name, FeedType, Origem, Active) VALUES('Bovespa', 'BDI', '', 0)
SELECT @mylastident = SCOPE_IDENTITY()

insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident ,	 'VALE5',	 1, 'VALE5')
insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident ,	 'OIBR3',  640, 'OIBR3')
insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident ,	 'PETR4',  667, 'PETR4')
insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident ,	 'ITUB4',  500, 'ITUB4')
insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident ,    'ITSA4',  498, 'ITSA4')
insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'IBOVESPA', NULL, 'IBOVESPA')


insert into TB_FEED (FeedType, Name, Origem, Active) VALUES ('CSV', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/PR_NI.csv', 1)
SELECT @mylastident = SCOPE_IDENTITY()

insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'LME/PR_NI', NULL, 'LME.NICKEL')

insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Date', 'System.DateTime', 'en-US', 'DataPregao') 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 

insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '3-months Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '15-months Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '15-months Seller', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 1 Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 1 Seller', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 2 Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 2 Seller', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 3 Buyer', 'System.Decimal', 'en-US', NULL) 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 3 Seller', 'System.Decimal', 'en-US', NULL) 


insert into TB_FEED (FeedType, Name, Origem, Active) VALUES ('CSV', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/PR_AL.csv', 1)
SELECT @mylastident = SCOPE_IDENTITY()

insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'LME/PR_AL', NULL, 'LME.ALUMIN')

insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Date', 'System.DateTime', 'en-US', 'DataPregao') 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 



insert into TB_FEED (FeedType, Name, Origem, Active) VALUES('CSV', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/PR_CU.csv', 1)
SELECT @mylastident = SCOPE_IDENTITY()

insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'LME/PR_CU', NULL, 'LME.COPPER')

insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Date', 'System.DateTime', 'en-US', 'DataPregao') 
insert into TB_FEED_CONFIG (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 


--insert into TB_FEED (FeedType, Origem, Active) VALUES('CSV', 'MOEDAS', 'https://www.bcb.org/dollar.csv', 1)
--SELECT @mylastident = SCOPE_IDENTITY()


--insert into TB_FEED (FeedType, Origem, Active) VALUES('Quandl', 'CSV', '', 1)
--insert into TB_FEEDER_COTACAO (FeederType, Origem, EXT_ID, AtivoId, CotacaoActive) VALUES('CSV','BCB', 'PTAX', 0, 1)
--insert into TB_FEEDER_COTACAO (FeederType, Origem, EXT_ID, AtivoId, CotacaoActive) VALUES('CSV','BCB', 'EUR', 0, 1)
--insert into TB_FEEDER_COTACAO (FeederType, Origem, EXT_ID, AtivoId, CotacaoActive) VALUES('CSV','BCB', 'JPY', 0, 1)
--insert into TB_FEEDER_COTACAO (FeederType, Origem, EXT_ID, AtivoId, CotacaoActive) VALUES('CSV','BCB', 'CHN', 0, 1)


*/