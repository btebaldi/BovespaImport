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
-- Create date: 2017-07-12
-- Description:	
-- =============================================
alter PROCEDURE procGetExtIdMap 
	-- Add the parameters for the stored procedure here
	@Id int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Id, 
		EXT_ID, 
		TebaldiBiz_AtivoId,
		Ticker
	FROM TB_ExtId_Map
	where
	((Id = @Id ) OR (@Id is null))
END
GO
