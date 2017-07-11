using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Business
{
    class CotacaoDataHandler
    {
        internal static void WriteDataToDatabase(DataTable table)
        {
            string ConnectionString = ConfigCommon.AppConfig.GetConnectionString("TebaldiMktDataSql");
            Tebaldi.MarketData.HistoricoCotacaoHandler historicoHandler = new Tebaldi.MarketData.HistoricoCotacaoHandler(ConnectionString);
            historicoHandler.ClearImpTable();
            historicoHandler.Insert(table);
            historicoHandler.ImportImpTable();
            //historicoHandler.ClearImpTable();
        }
    }
}
