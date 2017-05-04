USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_IMP_HISTORICO_COTACAO]    Script Date: 2017-04-27 5:24:58 PM ******/
DROP TABLE [dbo].[TB_IMP_HISTORICO_COTACAO]
GO

/****** Object:  Table [dbo].[TB_IMP_HISTORICO_COTACAO]    Script Date: 2017-04-27 5:24:58 PM ******/
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
	[ISIN] [nvarchar](12) NULL,
	[Variacao] [decimal](10, 6) NULL,
	[UpdateStatus] [bit] NOT NULL DEFAULT ((0)),
	[ImportStatus] [bit] NOT NULL DEFAULT ((0))
) ON [PRIMARY]

GO


