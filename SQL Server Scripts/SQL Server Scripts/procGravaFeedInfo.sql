USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedInfo]    Script Date: 2017-04-27 5:27:54 PM ******/
DROP PROCEDURE [dbo].[procGravaFeedInfo]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedInfo]    Script Date: 2017-04-27 5:27:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaFeedInfo]
	@FeedInfoXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @FeedInfoXML;


	declare @TB_IMP_FEED table 
		(
		[NodeId]			int not null unique,
		[FeedId]			int not null,
		[Name]				nvarchar(100) not null,
		[FeedTypeId]		int not null
		)


	INSERT INTO @TB_IMP_FEED ([NodeId], [FeedId], [Name], [FeedTypeId])
	SELECT [NodeId], [FeedId], [Name], [FeedTypeId]
	FROM 
		OPENXML (@idoc, '/ROOT/FeedInfo', 1)
			with (
				[NodeId]	int,
				[FeedId]	int,
				[Name]		nvarchar(100),
				[FeedTypeId]	int
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE F SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		F.[Name] = ImF.[Name],
		F.[FeedTypeId] = ImF.[FeedTypeId]
	FROM
		@TB_IMP_FEED ImF
		Inner Join TB_FEED F on F.FeedId = ImF.FeedId

-- Adiciono novos mapeamentos que tem Id=0

	DECLARE @WorkedIds TABLE (newFeedId INT)

	insert into @WorkedIds select FeedId from @TB_IMP_FEED where FeedId<>0


	INSERT INTO TB_FEED ([Name], [FeedTypeId])
	OUTPUT INSERTED.FeedId INTO @WorkedIds
	SELECT 
		[Name],
		[FeedTypeId]
	FROM
		@TB_IMP_FEED 
	WHERE
		[FeedId] = 0


 -- Adiciono eventuais Valores de Chaves que tem de ser acrescentados
	insert into TB_FeedKeyValue (FeedId, Chave, Valor, FeedSpecific)
	SELECT F.FeedId, FTD.Chave, 'SomeValue', 1 
	from	TB_FEED F
			INNER JOIN @WorkedIds WF on F.FeedId = WF.newFeedId
			INNER JOIN TB_FeedType FT on F.FeedTypeId = FT.FeedTypeId
			INNER JOIN TB_FeedTypeDefaultKeys FTD on FTD.FeedTypeId = F.FeedTypeId 
			LEFT JOIN TB_FeedKeyValue KV on F.FeedId = KV.FeedID and KV.Chave = FTD.Chave
	WHERE 
			KV.Chave is null
			
END



GO


