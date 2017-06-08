USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procDeleteFeed]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procDeleteFeed]
	@FeedInfoXML ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @FeedInfoXML;

	declare @TB_FeedList table 
		(
		[NodeId]	int not null unique,
		[FeedId]	int not null,
		[Name]		nvarchar(100) not null,
		[FeedType]	nvarchar(100) not null,
		[Active]	bit not null
		)


	INSERT INTO @TB_FeedList ([NodeId], [FeedId], [Name], [FeedType], [Active])
	SELECT [NodeId], [FeedId], [Name], [FeedType], [Active]
	FROM 
		OPENXML (@idoc, '/ROOT/FeedInfo', 1)
			with (
				[NodeId]	int,
				[FeedId]	int,
				[Name]		nvarchar(100),
				[FeedType]	nvarchar(100),
				[Active]	bit
				) x 

	EXEC sp_xml_removedocument @idoc; 
	

	DELETE FT
		FROM TB_FeedFilter FT Inner Join @TB_FeedList FL on FT.FeedId = FL.FeedId;
		
	DELETE KV
		FROM TB_FeedKeyValue KV Inner Join @TB_FeedList FL on KV.FeedId = FL.FeedId;

	DELETE TR
		FROM TB_FeedTransformation TR Inner Join @TB_FeedList FL on TR.FeedId = FL.FeedId;

	DELETE F
		FROM TB_Feed F Inner Join @TB_FeedList FL on F.FeedId = FL.FeedId;

END

GO
    