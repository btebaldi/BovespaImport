using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Reflection;

namespace Tebaldi.FeedImport
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.BdiImportProcess.cs");

        static void Main(string[] args)
        {
            logger.Info("Inicio de processo");

            // Inicializo o handler dos processos
            Tebaldi.FeedImport.Business.QueueHandler handler = new Business.QueueHandler();

            // busco lista de processos em fila
            List<Tebaldi.MarketData.Models.State.ProcessQueueState> lstQueue = handler.GetProcessQueue();
            List<Tebaldi.MarketData.Models.State.ProcessQueueState> lstNewQueue = new List<MarketData.Models.State.ProcessQueueState>();

            foreach (Tebaldi.MarketData.Models.State.ProcessQueueState item in lstQueue)
            {

                logger.Info("Executando Processo: " + item.Process.Name + " (id: " + item.Process.Id.ToString() + ") Date: " + item.DataReferencia.ToString("s"));

                item.DataExecucao = DateTime.Now;
                item.Executado = true;
                item.Success = false;

                if (item.Process.Active)
                {

                    FeedImport.Business.GenericProcess impPorcess = handler.CreateImport(item);

                    try
                    {
                        // Carego as configuracoes de importacao
                        impPorcess.LoadConfig();

                        // executo o feed de importacao
                        impPorcess.ExecuteFeed();

                        // executo filtros de importacao
                        impPorcess.ExecuteFilter();

                        impPorcess.ExecuteTransformations();

                        Business.CotacaoDataHandler.WriteDataToDatabase(impPorcess.GetData());

                        item.Success = true;

                        if (item.Process.AutoQueue)
                        {
                            lstNewQueue.Add(handler.ReQueue(item));
                        }

                    }
                    catch (Exceptions.DownloadError404Exception ex)
                    {
                        logger.Warn(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                    }
                }
            }

            lstQueue.AddRange(lstNewQueue);

            handler.Save(lstQueue);

            logger.Info("Fim de processo");
            log4net.LogManager.Flush(60000);
        }
    }
}
