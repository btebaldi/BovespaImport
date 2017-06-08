USE [TebaldiMarketData]
GO

/****** Object:  StoredProcedure [dbo].[procImportIMP]    Script Date: 2017-04-27 5:28:22 PM ******/
DROP PROCEDURE [dbo].[procImportIMP]
GO

/****** Object:  StoredProcedure [dbo].[procImportIMP]    Script Date: 2017-04-27 5:28:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Teo
-- Create date: 2017-01-20
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[procImportIMP] 
	-- Add the parameters for the stored procedure here
	--@p1 int = 0, 
	--@p2 int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		
		-- Determino ID dos ativos
		UPDATE I
		Set
			I.AtivoId = A.Id,
			I.ImportStatus = 1
		From 
		TB_IMP_HISTORICO_COTACAO I (nolock) 
		Inner join TB_ExtId_Map A (nolock) on I.EXT_ID=A.EXT_ID

		-- Determino Quais ativos serao atualizados
		UPDATE I
		Set
			I.UpdateStatus = 1,
			I.ImportStatus = 0
		From 
		TB_IMP_HISTORICO_COTACAO I 
		Inner join TB_HISTORICO_COTACAO H on
			    I.AtivoId = H.AtivoId
			AND I.DataPregao = H.DataPregao
		
		-- ATUALIZO AS COTACOES ANTIGAS FORNERCIDOS
		UPDATE H
		Set 
			H.FeedId = I.FeedId,
			H.Ticker = I.Ticker,
			H.TipoMercado=I.TipoMercado,
			H.PrecoAbertura = I.PrecoAbertura,
			H.PrecoMaximo= I.PrecoMaximo,
			H.PrecoMinimo = I.PrecoMinimo,
			H.PrecoMedio = I.PrecoMedio,
			H.PrecoFechamento = I.PrecoFechamento,
			H.TotalNegocios = I.TotalNegocios,
			H.Quantidade = I.Quantidade,
			H.Volume = I.Volume,
			H.Variacao = I.Variacao,
			H.DataRegistro = GetDate()
		From 
			TB_HISTORICO_COTACAO H
			Inner join TB_IMP_HISTORICO_COTACAO I on
					I.AtivoId = H.AtivoId
				AND I.DataPregao = H.DataPregao
		where
			I.UpdateStatus = 1


		-- ADICIONO NOVAS COTACOES
		INSERT INTO TB_HISTORICO_COTACAO
		Select 
			AtivoId,
			FeedId,
			DataPregao,
			Ticker,
			TipoMercado, 
			PrecoAbertura, 
			PrecoMaximo, 
			PrecoMinimo, 
			PrecoMedio, 
			PrecoFechamento, 
			TotalNegocios, 
			Quantidade, 
			Volume,
			Variacao,
			GETDATE()
		from
			TB_IMP_HISTORICO_COTACAO
		WHERE
			ImportStatus=1

			declare @atualizados varchar(10), @inseridos varchar(10), @excluidos varchar(10)

			select @atualizados = count(0) from TB_IMP_HISTORICO_COTACAO where UpdateStatus = 1
			select @inseridos = count(0) from TB_IMP_HISTORICO_COTACAO where ImportStatus = 1
			select @excluidos = count(0) from TB_IMP_HISTORICO_COTACAO where ImportStatus = 0 and UpdateStatus = 0

			declare @log_date Datetime, @log_utcdate Datetime, @log_level nvarchar(50), @logger nvarchar(255), @log_message nvarchar(4000)

			set @log_date =  GETDATE();
			set @log_utcdate =  GETUTCDATE();
			set @log_level = 'INFO';
			set @logger = 'procImportIMP';

			set @log_message = @atualizados + ' itens atualizados';
			EXEC	[dbo].[procInsertLog] @log_date, @log_utcdate, @log_level, @logger, @log_message, @exception = NULL

			set @log_message = @inseridos + ' itens inseridos';
			EXEC	[dbo].[procInsertLog] @log_date, @log_utcdate, @log_level, @logger, @log_message, @exception = NULL

			set @log_message = @excluidos + ' itens excluidos';
			EXEC	[dbo].[procInsertLog] @log_date, @log_utcdate, @log_level, @logger, @log_message, @exception = NULL

END

GO


