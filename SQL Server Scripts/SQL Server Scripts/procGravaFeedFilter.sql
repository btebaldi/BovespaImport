USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGravaFeedFilter]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaFeedFilter]
	@filterXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @filterXML;

	declare @TB_IMP_Filter table 
		(
		[NodeId]				int not null unique,
		[FilterId]			int not null,
		[FeedId]				int not null,
		[ColumnName]			nvarchar(50) null,
		[ColumnValue]			nvarchar(50) null
		)


	INSERT INTO @TB_IMP_Filter (NodeId, FilterId, FeedId, ColumnName, ColumnValue)
	SELECT NodeId, FilterId, FeedId, ColumnName, ColumnValue
	FROM 
		OPENXML (@idoc, '/ROOT/Filter', 1)
			with (
					[NodeId]			int,
					[FilterId]			int,
					[FeedId]			int,
					[ColumnName]		nvarchar(50),
					[ColumnValue]		nvarchar(50)
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE F SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		F.ColumnName = ImF.ColumnName,
		F.ColumnValue = ImF.ColumnValue
	FROM
		@TB_IMP_Filter ImF
		Inner Join TB_FeedFilter F on F.Id = ImF.FilterId 

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_FeedFilter (FeedId, ColumnName, ColumnValue)
	SELECT 
		 [FeedId],
		 [ColumnName],
		 [ColumnValue]
	FROM
		@TB_IMP_Filter 
	WHERE
		FilterId = 0
		
END



GO


