USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procGetFilter]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procGetFilter]
	@FeedId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT Id, FeedId, ColumnName, ColumnValue FROM TB_FeedFilter where FeedId = @FeedId

END

GO


