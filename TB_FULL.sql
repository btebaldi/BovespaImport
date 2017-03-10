USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_FEED] ******/
DROP TABLE [dbo].[TB_FEED_MAPPING]
DROP TABLE [dbo].[TB_FEED_TRANSFORMATION]
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
	[FileMask] [nvarchar](150) NOT NULL,
	[Active] [bit] NOT NULL,

	CONSTRAINT [PK_FEED] PRIMARY KEY CLUSTERED ([FeedId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO


CREATE TABLE [dbo].[TB_FEED_MAPPING](
		
    [MappingId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[ColumnIndex] [int] NULL, 
	[ColumnName] [nvarchar](50) NULL, 
	[StaticValue] [nvarchar](50) NULL, 
	[Type] [nvarchar](50) NOT NULL,
	[DateTimeParseMask] [nvarchar](50) NULL,
	[Culture] [nvarchar](50) NOT NULL,
	[Destination] [nvarchar](50) NULL,

	CONSTRAINT [FK_FeedId_Mapping] FOREIGN KEY([FeedId]) REFERENCES [dbo].[TB_FEED] ([FeedId]) ON DELETE CASCADE

) ON [PRIMARY]

GO


CREATE TABLE [dbo].[TB_FEED_TRANSFORMATION](
	
	[TransformationId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] int NOT NULL,
	[ExecuteOrder] int NOT NULL,
	[OriginalValue] [nvarchar](50) NOT NULL, 
	[OriginalColumn] [nvarchar](50) NOT NULL, 
	[NewValue] [nvarchar](50) NOT NULL, 
	[NewColumn] [nvarchar](50) NOT NULL, 

	CONSTRAINT [FK_FeedId_Transformation] FOREIGN KEY([FeedId]) REFERENCES [dbo].[TB_FEED] ([FeedId]) ON DELETE CASCADE

) ON [PRIMARY]

GO

--TB_IMP_HISTORICO_COTACAO

DECLARE @mylastident AS int

insert into TB_FEED (Name, FeedType, Origem, [FileMask], Active) VALUES('Bovespa', 'BDI', 'http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/', 'bdi{*}.zip', 0)
SELECT @mylastident = SCOPE_IDENTITY()

insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  1, 'VALE5', 'EXT_ID', 'VALE5', 'Ticker')
insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  2, 'VALE5', 'EXT_ID', '1', 'AtivoId')

insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  3, 'OIBR3', 'EXT_ID', 'OIBR3', 'Ticker')
insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  4, 'OIBR3', 'EXT_ID', '640', 'AtivoId')


insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  5, 'PETR4', 'EXT_ID', 'PETR4', 'Ticker')
insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  6, 'PETR4', 'EXT_ID', '667', 'AtivoId')


insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  7, 'ITUB4', 'EXT_ID', 'ITUB4', 'Ticker')
insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  8, 'ITUB4', 'EXT_ID', '500', 'AtivoId')


insert into TB_FEED_TRANSFORMATION VALUES(@mylastident,  9, 'ITSA4', 'EXT_ID', 'ITSA4', 'Ticker')
insert into TB_FEED_TRANSFORMATION VALUES(@mylastident, 10, 'ITSA4', 'EXT_ID', '498', 'AtivoId')


insert into TB_FEED_TRANSFORMATION VALUES(@mylastident, 11, 'IBOVESPA', 'EXT_ID', 'IBOV', 'Ticker')

insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, Null, 'Cotacao.Ticker', null, 'System.String', NULL, 'en-US', 'EXT_ID')

 insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, Null, 'Cotacao.PrecoFechamento', null, 'System.String', NULL, 'en-US', 'PrecoFechamento')


insert into TB_FEED (FeedType, Name, Origem, [FileMask], Active) VALUES ('Csv', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/', 'PR_NI.csv', 1)
SELECT @mylastident = SCOPE_IDENTITY()

--insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES (@mylastident , 'LME/PR_NI', NULL, 'LME.NICKEL')

insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, Null, Null, 'LME/PR_NI', 'System.String', NULL, 'en-US', 'EXT_ID')

 insert into TB_FEED_TRANSFORMATION VALUES(@mylastident, 10, 'LME/PR_NI', 'EXT_ID', 'LME.NICKEL', 'Ticker')


insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, Null, 'Date', Null, 'System.DateTime', 'yyyy-MM-dd', 'en-US', 'DataPregao')


insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, 2, null, null, 'System.Decimal', NULL, 'en-US', 'PrecoFechamento')



insert into TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, Type, DateTimeParseMask, Culture, Destination)
 VALUES (@mylastident, Null, 'Cash Seller & Settlement', null, 'System.Decimal', NULL, 'en-US', 'PrecoFechamento')
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 

--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '3-months Buyer', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '3-months Seller', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '15-months Buyer', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , '15-months Seller', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 1 Buyer', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 1 Seller', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 2 Buyer', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 2 Seller', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 3 Buyer', 'System.Decimal', 'en-US', NULL) 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Dec 3 Seller', 'System.Decimal', 'en-US', NULL) 


--insert into TB_FEED (FeedType, Name, Origem, Active) VALUES ('CSV', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/PR_AL.csv', 1)
--SELECT @mylastident = SCOPE_IDENTITY()

--insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'LME/PR_AL', NULL, 'LME.ALUMIN')

--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Date', 'System.DateTime', 'en-US', 'DataPregao') 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 



--insert into TB_FEED (FeedType, Name, Origem, Active) VALUES('CSV', 'Quandl', 'https://www.quandl.com/api/v3/datasets/LME/PR_CU.csv', 1)
--SELECT @mylastident = SCOPE_IDENTITY()

--insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES(@mylastident , 'LME/PR_CU', NULL, 'LME.COPPER')

--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Date', 'System.DateTime', 'en-US', 'DataPregao') 
--insert into TB_FEED_MAPPING (FeedId, FeederColumn, Type, Culture, Destination) VALUES(@mylastident , 'Cash Seller & Settlement', 'System.Decimal', 'en-US', 'PrecoFechamento') 


--insert into TB_FEED (FeedType, Origem, Active) VALUES('CSV', 'MOEDAS', 'https://ptax.bcb.gov.br/ptax_internet/consultaBoletim.do?method=gerarCSVTodasAsMoedas&id=59719', 1)
--SELECT @mylastident = SCOPE_IDENTITY()

--insert into TB_FEED_Ativo (FeedId, EXT_ID, AtivoId, Ticker) VALUES (@mylastident, '', AtivoId, Ticker)

-- https://ptax.bcb.gov.br/ptax_internet/consultaBoletim.do?method=gerarCSVFechamentoMoedaNoPeriodo&ChkMoeda=61&DATAINI=19/06/2016&DATAFIM=19/07/2016
-- https://ptax.bcb.gov.br/ptax_internet/consultaBoletim.do?method=gerarCSVTodasAsMoedas&id=59719

/* *************************************************************************** */



select * from TB_FEED
select * from TB_FEED_MAPPING
select * from TB_FEED_TRANSFORMATION






select * from TB_FEED F
	left join TB_FEED_MAPPING C on F.FeedId=C.FeedId
	left join TB_FEED_TRANSFORMATION T on F.FeedId=T.FeedId
