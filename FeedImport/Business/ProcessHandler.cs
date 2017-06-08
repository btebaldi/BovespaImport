using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Business
{
    class ProcessHandler
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.GenericFeed.cs");

        private readonly string ConnectionString;
        public ProcessHandler()
        {
            //ConnectionString = ConfigCommon.AppConfig.DefaultConnectionString;
            ConnectionString = ConfigCommon.AppConfig.GetConnectionString("TebaldiMktDataSql");
        }

        //public void Reschedule(ImportProcess i) { }

        public List<Tebaldi.MarketData.Models.State.ProcessQueueState> GetProcessQueue()
        {
            Tebaldi.MarketData.ImpProcessHandler handler = new MarketData.ImpProcessHandler(ConnectionString);
            return handler.GetQueue();
        }


        public void Save(List<Tebaldi.MarketData.Models.State.ProcessQueueState> lst)
        {
            Tebaldi.MarketData.ImpProcessHandler handler = new MarketData.ImpProcessHandler(ConnectionString);
            handler.Save(lst);
        }

        public FeedImport.Business.GenericProcess LoadImportProcess(Tebaldi.MarketData.Models.State.ProcessQueueState queue)
        {
            FeedImport.Business.GenericProcess processo = null;
            Tebaldi.MarketData.FeedHandler handler = new MarketData.FeedHandler(ConnectionString);
            Tebaldi.MarketData.Models.State.FeedState feed = handler.GetFeed(queue.FeedId);

            switch (feed.Type)
            {
                //case Tebaldi.MarketData.Models.State.FeedTypeEnum.Csv:
                //    Console.WriteLine("Case 1");
                //    break;
                case Tebaldi.MarketData.Models.State.FeedTypeStateEnum.BDI:
                    processo = new BdiImportProcess(queue);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            processo.QueueInfo = queue;
            processo.Feed = feed;
            processo.KeyValues = handler.GetFeedKeyValues   (queue.FeedId);
            processo.TransformationInfo = handler.GetFeedTransformations (queue.FeedId);
            processo.Feedfilter = handler.GetFeedFilters(queue.FeedId);

            return processo;
        }
        
        internal void WriteDataToDatabase(DataTable table)
        {
            try
            {
                Tebaldi.MarketData.HistoricoCotacaoHandler historicoHandler = new Tebaldi.MarketData.HistoricoCotacaoHandler(ConnectionString);
                historicoHandler.ClearImpTable();
                historicoHandler.Insert(table);
                historicoHandler.ImportImpTable();
                //historicoHandler.ClearImpTable();
            }
            catch (Exception ex)
            {
                logger.Error("Erro ao salvar a tabela IMP de cotacao", ex);
                throw;
            }
        }

    }
}
