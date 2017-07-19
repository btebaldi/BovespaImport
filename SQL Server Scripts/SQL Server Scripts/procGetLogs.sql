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
-- Description:	Busca Logs
-- =============================================
alter PROCEDURE procGetLogs
-- Add the parameters for the stored procedure here
	@Date Date = NULL  -- NULL default value
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		top 100 
		id, log_date, log_utcdate, Log_Level, Logger, log_Message, Exception
	from
		TB_Log
	Where 
	((log_date = @Date) OR (@Date is null))
	order by log_utcdate desc
END
GO
