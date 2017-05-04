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
            // Inicializo o handler dos processos
            Tebaldi.FeedImport.Business.ProcessHandler handler = new Business.ProcessHandler();

            // busco lista de processos em fila
            List<Tebaldi.MarketData.Models.State.ProcessQueueState> lstQueue = handler.GetProcessQueue();

            foreach (Tebaldi.MarketData.Models.State.ProcessQueueState item in lstQueue)
            {
                FeedImport.Business.GenericProcess impPorcess = handler.LoadImportProcess(item);

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

                    //if (handler.RescheduleOnSuccess)
                    //{
                    //    handler.Reschedule(i);
                    //}

                }
                catch (Exceptions.DownloadError404Exception ex)
                {
                    logger.Warn(ex.Message);
                }
            }
        }
    }
}
