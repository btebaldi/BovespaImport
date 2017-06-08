USE [TebaldiMarketData]
GO

SELECT [KeyValueId]
      ,[FeedId]
      ,[Chave]
      ,[Valor]
      ,[FeedSpecific]
  FROM [dbo].[TB_FeedKeyValue]
GO


--Update [TB_FeedKeyValue] set [Valor] = 'http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/' Where Chave='SiteAddress'
--Update [TB_FeedKeyValue] set [Valor] = 'bdi<~DateTime:MMdd~>.zip' Where Chave='FileMask'
--Update [TB_FeedKeyValue] set [Valor] = 'bdi.zip' Where Chave='SaveDownloadAs'
--Update [TB_FeedKeyValue] set [Valor] = 'bdi_<~DateTime:yyyy-MM-dd~>.txt' Where Chave='ExtractAs'
--Update [TB_FeedKeyValue] set [Valor] = 'BDIN' Where Chave='SearchInZip'
