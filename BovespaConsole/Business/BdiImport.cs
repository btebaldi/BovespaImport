using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConfigCommon;
using System.Data;

namespace FeedImport.Business
{
    class BdiImport : ImportProcess
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.Business.BdiImport.cs");

        //public void ImportaBdiOntem()
        //{
        //    //ImportaBdi(GetLastBussinessDate());
        //}

        //public void ImportaBdiPeriodo(DateTime inicio, DateTime fim)
        //{
        //    while (inicio <= fim)
        //    {
        //        //ImportaBdi(inicio);
        //        //inicio = inicio.AddDays(1);
        //    }
        //}

        public bool DownloadBdiFile(Config.BdiConfig bdiConfig)
        {
            bool tudoOk = false;
            try
            {
                MobralWorker.DownloadFile(bdiConfig.SourceFile.FileAddress, bdiConfig.DownloadedFile);
                logger.Debug("Download de arquivo BDI realizado");
                tudoOk = true;
            }
            catch (System.Net.WebException ex)
            {
                // logger.Error("Download error", ex);
                if (ex.Status == System.Net.WebExceptionStatus.ProtocolError)
                {
                    logger.Info("Status Code: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Erro no download do arquivo BDI", ex);
                throw;
            }

            return tudoOk;
        }

        public void DecompressBdiZip(Config.BdiConfig bdiConfig)
        {
            try
            {
                MobralWorker.GetFileFromZip(bdiConfig.DownloadedFile, bdiConfig.ZipFile.SearchForFile, bdiConfig.ZipFile.SaveFileAs);
                logger.Debug("Descompresao de arquivo BDI realizado");
            }
            catch (Exception ex)
            {
                logger.Error("Erro na descompressao do arquivo bdi", ex);
                throw;
            }

        }

        public DataTable ProcessaArquivoBdi(FeedImport.Config.BdiConfig bdiConfig)
        {
            DataTable table = base.GetHistoricoCotacaoImpTable();

            try
            {
                // Read File
                BovespaData.BusinessClass.Bdi bdiHandler = new BovespaData.BusinessClass.Bdi();
                BovespaData.DataClass.Entidade.BDI.BdiFileState bdiFile = new BovespaData.DataClass.Entidade.BDI.BdiFileState();

                bdiFile = bdiHandler.Load(bdiConfig.BdiFile.FullName);
                bdiHandler.ValidaArquivo(bdiFile);


                // Busco ativos que sarao importados
                // Tebaldi.MarketData.FeedHandler feedhandler = new Tebaldi.MarketData.FeedHandler("strTebaldiMarketDataConnectString");

                // feedhandler.

                // Leio o arquivo de importacao

                FillCotacoes(ref table, bdiFile);
                FillIndices(ref table, bdiFile);

            }
            catch (Exception ex)
            {
                logger.Error("Erro no processamento do arquivo bdi", ex);
                throw;
            }
            return table;
        }

        private void FillCotacoes(ref DataTable table, BovespaData.DataClass.Entidade.BDI.BdiFileState bdiFile)
        {
            foreach (BovespaData.DataClass.Entidade.BDI.CotacaoState cotacao in bdiFile.Cotacoes)
            {
                try
                {
                    DataRow row = table.NewRow();

                    row["EXT_ID"] = cotacao.Ticker;
                    row["FeedId"] = "BDI.Cotacao";
                    row["AtivoId"] = 0;
                    row["DataPregao"] = bdiFile.Header.DataDoPregao;
                    row["NomeResumido"] = cotacao.NomeResumido;
                    row["EspecPapel"] = cotacao.EspecificacaoPapel;
                    row["Ticker"] = cotacao.Ticker;
                    row["TipoMercado"] = cotacao.TipoDeMercado;
                    row["PrecoAbertura"] = cotacao.PrecoAbertura;
                    row["PrecoMaximo"] = cotacao.PrecoMaximo;
                    row["PrecoMedio"] = cotacao.PrecoMedio;
                    row["PrecoMinimo"] = cotacao.PrecoMinimo;
                    row["PrecoFechamento"] = cotacao.PrecoFechamento;
                    row["Quantidade"] = cotacao.Quantidade;
                    row["TotalNegocios"] = cotacao.TotalNegocios;
                    row["Volume"] = cotacao.Volume;
                    row["ISIN"] = cotacao.CodISIN;

                    if (cotacao.SinalOscilacao == "+")
                    { row["Variacao"] = cotacao.Oscilacao / 100; }
                    else
                    { row["Variacao"] = -cotacao.Oscilacao / 100; }

                    table.Rows.Add(row);
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "Sequence contains no matching element")
                    { }
                    else
                    { throw; }
                }
                catch (Exception ex)
                {
                    logger.Error("Arquivo excluido do processo de importacao.", ex);
                }

            }
        }

        private void FillIndices(ref DataTable table, BovespaData.DataClass.Entidade.BDI.BdiFileState bdiFile)
        {
            foreach (BovespaData.DataClass.Entidade.BDI.IndiceState indice in bdiFile.Indices)
            {
                try
                {
                    DataRow row = table.NewRow();

                    row["EXT_ID"] = indice.NomeIndice;
                    row["FeedId"] = "BDI.Indice";
                    row["AtivoId"] = 0;
                    row["DataPregao"] = bdiFile.Header.DataDoPregao;
                    row["NomeResumido"] = indice.NomeIndice;
                    row["EspecPapel"] = "INDICE";
                    row["Ticker"] = indice.NomeIndice;
                    row["TipoMercado"] = 99;
                    row["PrecoAbertura"] = indice.IndiceAbertura;
                    row["PrecoMaximo"] = indice.IndiceMaximo;
                    row["PrecoMedio"] = indice.IndiceMedia;
                    row["PrecoMinimo"] = indice.IndiceMinimo;
                    row["PrecoFechamento"] = indice.IndiceFechamento;
                    row["Quantidade"] = indice.QtdTitulosNegociadosIndice;
                    row["TotalNegocios"] = indice.NegociosComAcoesDoIndice;
                    row["Volume"] = indice.VolumeNegociosDoIndice;
                    row["ISIN"] = "";

                    if (indice.OntemSinalEvolucao == "+")
                    { row["Variacao"] = indice.OntemEvolucaoPercentual; }
                    else
                    { row["Variacao"] = -indice.OntemEvolucaoPercentual; }

                    table.Rows.Add(row);
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "Sequence contains no matching element")
                    { }
                    else
                    { throw; }
                }
                catch (Exception ex)
                {
                    logger.Error("Arquivo excluido do processo de importacao.", ex);
                }

            }
        }

    }
}
