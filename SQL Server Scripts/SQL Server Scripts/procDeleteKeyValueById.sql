USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
DROP PROCEDURE [dbo].[procDeleteKeyValueById]
GO

/****** Object:  StoredProcedure [dbo].[procGravaFeedMapping]    Script Date: 2017-04-27 5:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procDeleteKeyValueById]
	@KeyValueId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DELETE FROM TB_FeedKeyValue where KeyValueId = @KeyValueId and FeedSpecific = 0

END

GO
    