USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedTransformation]    Script Date: 28/07/2016 20:49:16 ******/
DROP PROCEDURE [dbo].[procGravaFeedTransformation]
GO


/****** Object:  StoredProcedure [dbo].[procGravaFeedTransformation]    Script Date: 28/07/2016 18:08:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[procGravaFeedTransformation]
	@TransformationXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @TransformationXML;

	

	declare @TB_IMP_TRANSFORMATION table 
		(
		[NodeId]			int not null unique,
		[TransformationId]	int not null,
		[FeedId]			int not null,
		[ExecuteOrder]		int not null,
		[OriginalValue]		nvarchar(100) not null,
		[OriginalColumn]	nvarchar(100) not null,
		[NewValue]			nvarchar(100) not null,
		[NewColumn]			nvarchar(100) not null
		)


	INSERT INTO @TB_IMP_TRANSFORMATION ([NodeId], [TransformationId], [FeedId], [ExecuteOrder], [OriginalValue], [OriginalColumn], [NewValue], [NewColumn])
	SELECT [NodeId], [TransformationId], [FeedId], [ExecuteOrder], [OriginalValue], [OriginalColumn], [NewValue], [NewColumn]
	FROM 
		OPENXML (@idoc, '/ROOT/Transformation', 1)
			with (
				[NodeId]			int,
				[TransformationId]	int,
				[FeedId]			int,
				[ExecuteOrder]		int,
				[OriginalValue]		nvarchar(100),
				[OriginalColumn]	nvarchar(100),
				[NewValue]			nvarchar(100),
				[NewColumn]			nvarchar(100)
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE T SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		T.[ExecuteOrder] = IT.[ExecuteOrder],
		T.[OriginalValue] = IT.[OriginalValue],
		T.[OriginalColumn] = IT.[OriginalColumn],
		T.[NewValue] = IT.[NewValue],
		T.[NewColumn] = IT.[NewColumn]
	FROM
		@TB_IMP_TRANSFORMATION IT
		Inner Join TB_FEED_TRANSFORMATION T on T.TransformationId = IT.TransformationId

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_FEED_TRANSFORMATION ([FeedId], [ExecuteOrder], [OriginalValue], [OriginalColumn], [NewValue], [NewColumn])
	SELECT 
		 [FeedId],
		 [ExecuteOrder],
		 [OriginalValue],
		 [OriginalColumn],
		 [NewValue],
		 [NewColumn]
	FROM
		@TB_IMP_TRANSFORMATION 
	WHERE
		[TransformationId] = 0
		
END


GO

