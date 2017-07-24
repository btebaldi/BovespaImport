USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_HISTORICO_COTACAO]    Script Date: 2017-04-27 5:24:46 PM ******/
DROP TABLE [dbo].[TB_HISTORICO_COTACAO]
GO

/****** Object:  Table [dbo].[TB_HISTORICO_COTACAO]    Script Date: 2017-04-27 5:24:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_HISTORICO_COTACAO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtivoId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[DataPregao] [date] NOT NULL,
	--[Ticker] [nvarchar](12) NOT NULL,
	--[TipoMercado] [int] NOT NULL,
	[PrecoAbertura] [decimal](18, 4) NOT NULL,
	[PrecoMaximo] [decimal](18, 4) NOT NULL,
	[PrecoMinimo] [decimal](18, 4) NOT NULL,
	[PrecoMedio] [decimal](18, 4) NOT NULL,
	[PrecoFechamento] [decimal](18, 4) NOT NULL,
	[TotalNegocios] [int] NOT NULL,
	[Quantidade] [bigint] NOT NULL,
	[Volume] [decimal](18, 4) NOT NULL,
	[Variacao] [decimal](10, 6) NULL,
	[DataRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_TB_HISTORICO_COTACAO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Cotacao] UNIQUE NONCLUSTERED 
(
	[AtivoId] ASC,
	[DataPregao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


