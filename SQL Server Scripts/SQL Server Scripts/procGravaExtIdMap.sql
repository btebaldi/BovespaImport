USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaExtIdMap]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGravaExtIdMap]
GO

/****** Object:  StoredProcedure [dbo].[procGravaExtIdMap]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaExtIdMap]
	@extIdMapList ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @extIdMapList;

	declare @TB_ExtIdMap table 
		(
		NodeId				int not null unique,
		Id					int not null,
		EXT_ID				nvarchar(200) not null, 
		TebaldiBiz_AtivoId	int not null,
		Ticker				nvarchar(12) not null 
		)
	
	INSERT INTO @TB_ExtIdMap (NodeId,Id, EXT_ID, TebaldiBiz_AtivoId, Ticker)
	SELECT NodeId,Id, EXT_ID, TebaldiBiz_AtivoId, Ticker
	FROM 
		OPENXML (@idoc, '/ROOT/ExtIdMap', 1)
			with (
					NodeId				int,
					Id					int,
					EXT_ID				nvarchar(200), 
					TebaldiBiz_AtivoId	int,
					Ticker				int
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE A SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		A.EXT_ID = I.EXT_ID,
		A.TebaldiBiz_AtivoId = I.TebaldiBiz_AtivoId,
		A.Ticker = I.Ticker
	FROM
		@TB_ExtIdMap I
		Inner Join tb_ExtId_Map A on I.Id = A.Id

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO tb_ExtId_Map (EXT_ID, TebaldiBiz_AtivoId, Ticker)
	SELECT 
		EXT_ID,
		TebaldiBiz_AtivoId,
		Ticker
	FROM
		@TB_ExtIdMap 
	WHERE
		Id = 0
		
END



GO


