USE [TebaldiMarketData]
GO

/****** Object:  Table [dbo].[TB_ATIVO]    Script Date: 2017-04-27 5:20:58 PM ******/
DROP TABLE [dbo].[TB_ATIVO]
GO

/****** Object:  Table [dbo].[TB_ATIVO]    Script Date: 2017-04-27 5:20:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ATIVO](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EXT_ID] [nvarchar](50) NOT NULL,
	[IdAtivoTebaldiBiz] [int] NULL,
	[Bolsa] [nvarchar](50) NOT NULL,
	[Feed] [int] NOT NULL,
	[Import] [bit] NOT NULL,
	[DataRegistro] [datetime] NOT NULL
) ON [PRIMARY]

GO


