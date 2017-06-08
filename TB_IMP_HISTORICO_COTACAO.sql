USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_IMP_HISTORICO_COTACAO]    Script Date: 11/07/2016 16:00:05 ******/
DROP TABLE [dbo].[TB_IMP_HISTORICO_COTACAO]
GO

/****** Object:  Table [dbo].[TB_IMP_HISTORICO_COTACAO]    Script Date: 11/07/2016 16:00:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_IMP_HISTORICO_COTACAO](
	
	[EXT_ID] [nvarchar](50) NOT NULL,
	[AtivoId] [int] NULL,
	[FeedId] [nvarchar](50) NULL,
	[DataPregao] [date] NULL,
	[Ticker] [nvarchar](12) NULL,
	[TipoMercado] [int] NULL,
	[NomeResumido] [nvarchar](12) NULL,
	[EspecPapel] [nvarchar](10) NULL,
	[PrecoAbertura] [decimal](18, 4) NULL,
	[PrecoMaximo] [decimal](18, 4) NULL,
	[PrecoMinimo] [decimal](18, 4) NULL,
	[PrecoMedio] [decimal](18, 4) NULL,
	[PrecoFechamento] [decimal](18, 4) NULL,
	[TotalNegocios] [int] NULL,
	[Quantidade] [bigint] NULL,
	[Volume] [decimal](18, 4) NULL,
	[ISIN] [nvarchar](12) NULL

) ON [PRIMARY]

GO


