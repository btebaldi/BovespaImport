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
-- Description:	Busca Key Value
-- =============================================
alter PROCEDURE procGetKeyValue 
	-- Add the parameters for the stored procedure here
	@FeedId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT KeyValueId, FeedId, Chave, Valor, FeedSpecific from TB_FeedKeyValue where FeedId = @FeedId
END
GO
