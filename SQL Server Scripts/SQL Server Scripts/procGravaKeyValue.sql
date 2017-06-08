USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGravaKeyValue]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaKeyValue]
	@keyValueXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @keyValueXML;

	declare @TB_IMP_KeyValue table 
		(
		NodeId			int not null unique,
		KeyValueId		int not null,
		FeedId			int not null,
		Chave			nvarchar(200) not null,
		Valor			nvarchar(2000) not null,
		FeedSpecific	bit not null
		)


	INSERT INTO @TB_IMP_KeyValue (NodeId, KeyValueId, FeedId, Chave, Valor, FeedSpecific)
	SELECT NodeId, KeyValueId, FeedId, Chave, Valor, FeedSpecific
	FROM 
		OPENXML (@idoc, '/ROOT/KeyValue', 1)
			with (
					NodeId			int,
					KeyValueId		int,
					FeedId			int,
					Chave			nvarchar(200),
					Valor			nvarchar(2000),
					FeedSpecific	bit
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE KV SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		KV.Chave = I.Chave,
		KV.Valor = I.Valor,
		KV.FeedSpecific = I.FeedSpecific
	FROM
		@TB_IMP_KeyValue I
		Inner Join TB_FeedKeyValue KV on I.KeyValueId = KV.KeyValueId 

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_FeedKeyValue (FeedId, Chave, Valor, FeedSpecific)
	SELECT 
		 FeedId,
		 Chave, 
		 Valor, 
		 FeedSpecific
	FROM
		@TB_IMP_KeyValue 
	WHERE
		KeyValueId = 0
		
END



GO


