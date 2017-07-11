-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno
-- Create date: 2017-05-03
-- Description:	Busca Process Queue
-- =============================================
alter PROCEDURE procGetProcessQueue 
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @hoje as datetime
	set @hoje = getdate()

    -- Insert statements for procedure here
	SELECT 
		Q.QueueId, 
		Q.ProcessId, 
		Q.DtAgendada,
		Q.DtExecucao,
		Q.DtReferencia, 
		Q.Executado, 
		Q.Success,

		P.Name as "TB_ImportProcess.Name",
		P.FeedId as "TB_ImportProcess.FeedId",
		P.AutoQueue as "TB_ImportProcess.AutoQueue",
		P.Active as "TB_ImportProcess.Active"
	FROM 
		TB_ProcessQueue Q
		Inner Join TB_ImportProcess P on P.ProcessId = Q.ProcessId
	where 
	Q.Executado = 0
	AND Q.DtAgendada <= @hoje
	AND P.Active = 1
END
GO
