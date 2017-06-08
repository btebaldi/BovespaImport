using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedImport.Business
{
    abstract class ImportProcess
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.ImportProcess.cs");

        protected string strTebaldiMarketDataConnectString;
        public long ProcessId;

        public ImportProcess()
        {
            strTebaldiMarketDataConnectString = ConfigCommon.AppConfig.GetConnectionString("TebaldiMktDataSql");
            ProcessId = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddhhmmss"));
        }

        public DateTime GetLastBussinessDate()
        {
            DateTime mydate = DateTime.Today.AddDays(-1);

            while (mydate.DayOfWeek == DayOfWeek.Saturday || mydate.DayOfWeek == DayOfWeek.Sunday)
            {
                mydate = mydate.AddDays(-1);
            }

            return mydate;
        }

        internal void ImportCotacao(DataTable tblHistoricoCotacao)
        {
            try
            {
                Tebaldi.MarketData.HistoricoCotacaoHandler historicoHandler = new Tebaldi.MarketData.HistoricoCotacaoHandler(strTebaldiMarketDataConnectString);
                historicoHandler.ClearImpTable();
                historicoHandler.Insert(tblHistoricoCotacao);
                historicoHandler.ImportImpTable();
                //historicoHandler.ClearImpTable();
            }
            catch (Exception ex)
            {
                logger.Error("Erro ao salvar a tabela IMP de cotacao", ex);
                throw;
            }
        }

        public DataTable GetHistoricoCotacaoImpTable()
        {
            return Tebaldi.MarketData.HistoricoCotacaoHandler.GetDataTable();
        }
    }
}
