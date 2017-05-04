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
		[FeedType]			nvarchar(100) not null,
		[Origem]			nvarchar(2000) not null,
		[FileMask]			nvarchar(150) not null,
		[Active]			bit not null
		)


	INSERT INTO @TB_IMP_FEED ([NodeId], [FeedId], [Name], [FeedType], [Origem], [FileMask], [Active])
	SELECT [NodeId], [FeedId], [Name], [FeedType], [Origem], [FileMask], [Active]
	FROM 
		OPENXML (@idoc, '/ROOT/FeedInfo', 1)
			with (
				[NodeId]	int,
				[FeedId]	int,
				[Name]		nvarchar(100),
				[FeedType]	nvarchar(100),
				[Origem]	nvarchar(2000),
				[FileMask]	nvarchar(150),
				[Active]	bit
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE F SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		F.[Name] = ImF.[Name],
		F.[FeedType] = ImF.[FeedType],
		F.[Origem] = ImF.[Origem],
		F.[FileMask] = ImF.[FileMask],
		F.[Active] = ImF.[Active]
	FROM
		@TB_IMP_FEED ImF
		Inner Join TB_FEED F on F.FeedId = ImF.FeedId

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_FEED ([Name], [FeedType], [Origem], [FileMask], [Active])
	SELECT 
		[Name],
		[FeedType],
		[Origem],
		[FileMask],
		[Active]
	FROM
		@TB_IMP_FEED 
	WHERE
		[FeedId] = 0
END



GO


