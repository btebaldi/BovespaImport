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
-- Author:		Bruno Tebaldi
-- Create date: 2017-06-08
-- Description:	
-- =============================================
CREATE PROCEDURE procGetFeedTypeDefaultValues
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select
		FT.FeedTypeId,
		FT.EnumCode,
		FT.Descricao,
		DV.DefaultKeyId,
		DV.FeedTypeId,
		DV.Chave
	from TB_FeedType FT
	Inner Join TB_FeedTypeDefaultKeys DV on FT.FeedTypeId = DV.FeedTypeId 
END
GO
