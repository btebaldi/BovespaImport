USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]   ******/
DROP PROCEDURE [dbo].[procGravaFeedMapping]
GO


/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[procGravaFeedMapping]
	@mappingXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @mappingXML;

	declare @TB_IMP_MAPPING table 
		(
		[NodeId]				int not null unique,
		[MappingId]			int not null,
		[FeedId]				int not null,
		[ColumnIndex]			int null,
		[ColumnName]			nvarchar(100) null,
		[StaticValue]			nvarchar(100) null,
		[Type]				nvarchar(100) not null,
		[DateTimeParseMask]	nvarchar(100) null,
		[Culture]				nvarchar(100) not null,
		[Destination]			nvarchar(100) null
		)


	INSERT INTO @TB_IMP_MAPPING (NodeId, MappingId, FeedId, ColumnIndex, ColumnName, StaticValue, [Type], [DateTimeParseMask], Culture, Destination)
	SELECT NodeId, MappingId, FeedId, ColumnIndex, ColumnName, StaticValue, [Type], [DateTimeParseMask], Culture, Destination
	FROM 
		OPENXML (@idoc, '/ROOT/Mapping', 1)
			with (
					[NodeId]			int,
					[MappingId]			int,
					[FeedId]			int,
					[ColumnIndex]		int,
					[ColumnName]		nvarchar(100),
					[StaticValue]		nvarchar(100),
					[Type]				nvarchar(100),
					[DateTimeParseMask]	nvarchar(100),
					[Culture]			nvarchar(100),
					[Destination]		nvarchar(100)
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE M SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		M.[ColumnIndex] = IM.[ColumnIndex],
		M.[ColumnName] = IM.[ColumnName],
		M.[StaticValue] = IM.[StaticValue],
		M.[Type] = IM.[Type],
		M.[DateTimeParseMask] = IM.[DateTimeParseMask],
		M.[Culture] = IM.[Culture],
		M.[Destination] = IM.[Destination]
	FROM
		@TB_IMP_MAPPING IM
		Inner Join TB_FEED_MAPPING M on M.MappingId = IM.MappingId

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_FEED_MAPPING (FeedId, ColumnIndex, ColumnName, StaticValue, [Type], [DateTimeParseMask], Culture, Destination)
	SELECT 
		 [FeedId],
		 [ColumnIndex],
		 [ColumnName],
		 [StaticValue],
		 [Type],
		 [DateTimeParseMask],
		 [Culture],
		 [Destination]
	FROM
		@TB_IMP_MAPPING 
	WHERE
		[MappingId] = 0
		
END


GO

