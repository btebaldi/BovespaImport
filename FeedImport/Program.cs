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
            Tebaldi.FeedImport.Business.ProcessHandler handler = new Business.ProcessHandler();

            // busco lista de processos em fila
            List<Tebaldi.MarketData.Models.State.ProcessQueueState> lstQueue = handler.GetProcessQueue();

            foreach (Tebaldi.MarketData.Models.State.ProcessQueueState item in lstQueue)
            {
                FeedImport.Business.GenericProcess impPorcess = handler.LoadImportProcess(item);

                item.DataExecucao = DateTime.Now;
                item.Executado = true;
                try
                {
                    // Carego as configuracoes de importacao
                    impPorcess.LoadConfig();

                    // executo o feed de importacao
                    impPorcess.ExecuteFeed();

                    // executo filtros de importacao
                    impPorcess.ExecuteFilter();

                    impPorcess.ExecuteTransformations();

                    handler.WriteDataToDatabase(impPorcess.GetData());

                    item.Success = true;

                    //if (handler.RescheduleOnSuccess)
                    //{
                    //    handler.Reschedule(i);
                    //}

                }
                catch (Exceptions.DownloadError404Exception ex)
                {
                    item.Success = false;
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    item.Success = false;
                    logger.Error(ex.Message);
                }
            }
            handler.Save(lstQueue);

            logger.Info("Fim de processo");
            log4net.LogManager.Flush(15000);
        }
    }
}
