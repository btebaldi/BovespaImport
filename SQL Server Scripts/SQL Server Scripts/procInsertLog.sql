USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procInsertLog]    Script Date: 2017-04-27 5:28:35 PM ******/
DROP PROCEDURE [dbo].[procInsertLog]
GO

/****** Object:  StoredProcedure [dbo].[procInsertLog]    Script Date: 2017-04-27 5:28:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Teo
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[procInsertLog] 
	-- Add the parameters for the stored procedure here
	@log_date Datetime, 
	@log_utcdate Datetime,
	@log_level nvarchar(50),
	@logger nvarchar(255),
	@log_message nvarchar(4000),
	@exception nvarchar(2000) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into TB_LOG 
	(log_date, log_utcdate, log_Level, Logger, log_Message, Exception)
	values
	(@log_date, @log_utcdate, @log_level, @logger, @log_message, @exception)

	--insert into TB_LOG 
	--(log_date, log_Level, Logger, log_Message, Exception)
	--values
	--(Getdate(), 'TEST', 'PROC', 'TESTE DE PROC', null)
		

END

GO


