USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGetFeed]    Script Date: 2017-05-19 11:20:34 AM ******/
DROP PROCEDURE [dbo].[procGetFeed]
GO

/****** Object:  StoredProcedure [dbo].[procGetFeed]    Script Date: 2017-05-19 11:20:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bruno
-- Create date: 2017-05-03
-- Description:	Busca Processo Importacao
-- =============================================
CREATE PROCEDURE [dbo].[procGetFeed]
	-- Add the parameters for the stored procedure here
	@FeedId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT FeedId, Name, FeedTypeId, Active from TB_Feed where (FeedId = @FeedId or @FeedId is null)
END

GO


