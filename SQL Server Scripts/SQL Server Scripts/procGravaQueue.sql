USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaQueue]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGravaQueue]
GO

/****** Object:  StoredProcedure [dbo].[procGravaQueue]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGravaQueue]
	@queueList ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idoc int

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @queueList;

	declare @TB_Queue table 
		(
		NodeId			int not null unique,
		QueueId			int not null,
		ProcessId		int not null,
		DtExecucao		DateTime null,
		DtAgendada		DateTime not null,
		DtReferencia	DateTime not null,
		Executado		bit not null,
		Success			bit not null
		)


	INSERT INTO @TB_Queue (NodeId, QueueId, ProcessId, DtAgendada, DtExecucao, DtReferencia, Executado, Success)
	SELECT NodeId, QueueId, ProcessId, DtAgendada, DtExecucao, DtReferencia, Executado, Success
	FROM 
		OPENXML (@idoc, '/ROOT/Queue', 1)
			with (
					NodeId			int,
					QueueId			int,
					ProcessId		int,
					DtExecucao		DateTime,
					DtAgendada		DateTime,
					DtReferencia	DateTime,
					Executado		bit,
					Success			bit
				) x 

	EXEC sp_xml_removedocument @idoc; 
	
-- Atualizacao dos mapeamentos determinados.
	UPDATE Q SET
		/* CAMPOS DESLIGADOS. SAO ATUALIZADOS APENAS NO CADASTRO MANUAL */
		Q.DtExecucao = I.DtExecucao,
		Q.DtReferencia = I.DtReferencia,
		Q.DtAgendada = I.DtAgendada,
		Q.Executado = I.Executado,
		Q.Success = I.Success
	FROM
		@TB_Queue I
		Inner Join TB_ProcessQueue Q on I.QueueId = Q.QueueId

-- Adiciono novos mapeamentos que tem Id=0
	INSERT INTO TB_ProcessQueue (ProcessId, DtExecucao, DtAgendada, DtReferencia, Executado, Success)
	SELECT 
		ProcessId,
		DtExecucao,
		DtAgendada,
		DtReferencia,
		Executado,
		Success
	FROM
		@TB_Queue 
	WHERE
		QueueId = 0
		
END



GO


