USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procClearImpTable]    Script Date: 2017-04-27 5:27:44 PM ******/
DROP PROCEDURE [dbo].[procClearImpTable]
GO

/****** Object:  StoredProcedure [dbo].[procClearImpTable]    Script Date: 2017-04-27 5:27:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Teo
-- Create date: 2017-01-20
-- Description:	Clear IMP tables
-- =============================================
CREATE PROCEDURE [dbo].[procClearImpTable] 
	-- Add the parameters for the stored procedure here
	--@p1 int = 0, 
	--@p2 int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE TB_IMP_HISTORICO_COTACAO
END

GO


