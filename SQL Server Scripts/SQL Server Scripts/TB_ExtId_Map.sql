USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_ExtId_Map]    Script Date: 2017-06-06 2:56:07 PM ******/
DROP TABLE [dbo].[TB_ExtId_Map]
GO

/****** Object:  Table [dbo].[TB_ExtId_Map]    Script Date: 2017-06-06 2:56:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ExtId_Map](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EXT_ID] [nvarchar](100) NOT NULL,
	[TebaldiBiz_AtivoId] [int] NOT NULL,
 CONSTRAINT [PK_TB_ExtId_Map] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ExtIdMap] UNIQUE NONCLUSTERED 
(
	[EXT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


-- CARGA INICIAL
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.IBOVESPA', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GFSA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ALPA4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ABEV3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BTOW3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.FIBR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BBDC3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BBDC4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BRAP4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BRKM5', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.HYPE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CCRO3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CESP6', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CGAS5', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CMIG4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.MMXM3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CPFE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CPLE6', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CSAN3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CSNA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CTAX4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.MRVE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CYRE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.DASA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.TAEE11', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ECOR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ELET3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ELET6', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ELPL4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.EMAE4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.EMBR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ENBR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.EQTL3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.OGXP3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.IGTA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GETI4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GGBR4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GOAU4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GOLL4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GRND3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ITUB4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.ITSA4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.KLBN4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.LAME4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.LIGT3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.LREN3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.JBSS3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.MAGG3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.PCAR4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.LOGN3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.PETR4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.PMAM3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.POMO4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BRFS3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.PSSA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.COCE5', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.RAPT4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.RENT3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.NATU3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.RSID3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.TIMP3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.SULA11', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.SBSP3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.SANB11', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.TBLE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.VIVT4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.UGPA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.PDGR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.OIBR3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.OIBR4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.TOTS3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.TRPL4', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.MDIA3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.USIM5', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.VALE5', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.CIEL3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.WSON33', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.WEGE3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.BVMF3', 0)
INSERT INTO TB_ExtId_Map (Ext_ID, TebaldiBiz_AtivoId) VALUES ('BVSP.GPIV33', 0)
