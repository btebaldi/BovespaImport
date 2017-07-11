using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Business
{
    class QueueHandler
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.GenericFeed.cs");

        private readonly string ConnectionString;
        public QueueHandler()
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

        public Tebaldi.MarketData.Models.State.ProcessQueueState ReQueue(Tebaldi.MarketData.Models.State.ProcessQueueState item)
        {
            Tebaldi.MarketData.Models.State.ProcessQueueState obj = new MarketData.Models.State.ProcessQueueState();
            obj.QueueId = 0;

            obj.Process = item.Process;

            obj.DataAgendada = item.DataAgendada.AddDays(1);
            if (item.DataReferencia.DayOfWeek == DayOfWeek.Friday)
            {
                obj.DataReferencia = item.DataReferencia.AddDays(3);
            }
            else
            {
                obj.DataReferencia = item.DataReferencia.AddDays(1);
            }

            obj.Executado = false;
            obj.Success = false;

            return obj;
        }
        public void Save(List<Tebaldi.MarketData.Models.State.ProcessQueueState> lst)
        {
            Tebaldi.MarketData.ImpProcessHandler handler = new MarketData.ImpProcessHandler(ConnectionString);
            handler.Save(lst);
        }

        public FeedImport.Business.GenericProcess CreateImport(Tebaldi.MarketData.Models.State.ProcessQueueState queue)
        {
            FeedImport.Business.GenericProcess processo = null;

            switch (queue.Process.Feed.Type)
            {
                case Tebaldi.MarketData.Models.State.FeedTypeEnum.BDI:
                    processo = new BdiImportProcess(queue);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return processo;
        }



    }
}
