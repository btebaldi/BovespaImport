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

	declare @hoje as date
	set @hoje = getdate()

    -- Insert statements for procedure here
	SELECT Q.QueueId, Q.ProcessId, Q.DtExecucao, Q.DtReferencia, Q.Executado, Q.Success from TB_ProcessQueue Q
	Inner Join TB_Process P on P.ProcessId = Q.ProcessId
	where Q.Executado = 0
	and Q.DtExecucao <= @hoje
	and P.InUse = 1
END
GO
