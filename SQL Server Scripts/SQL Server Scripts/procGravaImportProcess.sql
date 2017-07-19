USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaImportProcess]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGravaImportProcess]
GO

/****** Object:  StoredProcedure [dbo].[procGravaImportProcess]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaImportProcess]
	@importList ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @importList;

	declare @TB_ImportProcess table 
		(
		NodeId		int not null unique,
		ProcessId	int not null,
		Name		nvarchar(200) not null,
		FeedId		int null,
		AutoQueue	bit not null,
		Active		bit not null
		)
		

	INSERT INTO @TB_ImportProcess (NodeId, ProcessId, Name, FeedId, AutoQueue, Active)
	SELECT NodeId, ProcessId, Name, FeedId, AutoQueue, Active
	FROM 
		OPENXML (@idoc, '/ROOT/ImportProcess', 1)
			with (
					NodeId		int,
					ProcessId	int,
					Name		nvarchar(200),
					FeedId		int,
					AutoQueue	bit,
					Active		bit
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE A SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
					A.Name = I.Name,
					A.FeedId = I.FeedId,
					A.AutoQueue = I.AutoQueue,
					A.Active = I.Active
	FROM
		@TB_ImportProcess I
		Inner Join TB_ImportProcess A on I.ProcessId = A.ProcessId

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_ImportProcess (Name, FeedId, AutoQueue, Active)
	SELECT 
		Name,
		FeedId,
		AutoQueue,
		Active
	FROM
		@TB_ImportProcess 
	WHERE
		ProcessId = 0
		
END



GO


