using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tebaldi.Quandl.Business;

namespace Tebaldi.FeedImport.Business
{
    class QuandlImportProcess : GenericProcess
    {
        // objeto responsavel por logar
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.BdiImportProcess.cs");

        // arquivo de coniguracao
        private TimeSeiresRequest request;

        // Construtor
        public QuandlImportProcess(Tebaldi.MarketData.Models.State.ProcessQueueState queue) : base(queue)
        { }


        public override void LoadConfig()
        {
            if (Queue.Process.Feed.KeyValues == null)
            { throw new Exceptions.KeyValuesNotLoaded("Key Values nao carregados"); }

            ValidadeKeyValue();

            Tebaldi.Quandl.Types.Datacode datacode = new Quandl.Types.Datacode(Queue.Process.Feed.GetValue("DataCode"));

            this.request = new TimeSeiresRequest(datacode);

            request.ApiKey = Queue.Process.Feed.GetValue("ApiKey");

            request.Format = Quandl.Types.FileFormats.XML;
            request.Frequency = Quandl.Types.Frequencies.None;

            request.Type = RequestType.TimeSeriesAndMetadata;

            request.StartDate = Queue.DataReferencia;
            request.EndDate = Queue.DataReferencia;

            request.Limit = 1;
            request.Sort = Quandl.Types.SortOrders.Ascending;
            request.Transformation = Quandl.Types.Transformations.None;
        }


        public override void ExecuteFeed()
        {
            try
            {
                Tebaldi.Quandl.Business.Connection conn = new Tebaldi.Quandl.Business.Connection();
                TimeSeriesResponse res = conn.Get(request);
                FillCotacoes(res);

            }
            catch (Exception ex)
            {
                logger.Error("Erro no processamento do arquivo bdi", ex);
                throw;
            }
        }

        private void FillCotacoes(TimeSeriesResponse res)
        {
            foreach (DataRow cotacao in res.Data.Rows)
            {
                DataRow row = Data.NewRow();

                row["EXT_ID"] = res.Request.Datacode.ToString();
                row["ProcessId"] = Queue.Process.Id;
                row["AtivoId"] = 0;
                row["DataPregao"] = res.Request.EndDate;
                row["NomeResumido"] = res.Request.Datacode.ToString();
                row["EspecPapel"] = "";
                row["Ticker"] = res.Request.Datacode.ToString('.');
                row["TipoMercado"] = 99;
                row["PrecoAbertura"] = cotacao[Queue.Process.Feed.GetValue("ColumnValue")];
                row["PrecoMaximo"] = cotacao[Queue.Process.Feed.GetValue("ColumnValue")];
                row["PrecoMedio"] = cotacao[Queue.Process.Feed.GetValue("ColumnValue")];
                row["PrecoMinimo"] = cotacao[Queue.Process.Feed.GetValue("ColumnValue")];
                row["PrecoFechamento"] = cotacao[Queue.Process.Feed.GetValue("ColumnValue")];
                row["Quantidade"] = 1;
                row["TotalNegocios"] = 1;
                row["Volume"] = 1;
                row["ISIN"] = "";
                row["Variacao"] = 0;

                Data.Rows.Add(row);
            }
        }

        private void ValidadeKeyValue()
        {
            string strErrorMessage = "";
            if (Queue.Process.Feed.KeyValues.FindIndex(kv => kv.Key == "ColumnValue") < 0)
            { strErrorMessage = strErrorMessage + "Key \'ColumnValue\' nao encontrada\n"; }

            if (Queue.Process.Feed.KeyValues.FindIndex(kv => kv.Key == "ApiKey") < 0)
            { strErrorMessage = strErrorMessage + "Key \'ApiKey\' nao encontrada\n"; }

            if (Queue.Process.Feed.KeyValues.FindIndex(kv => kv.Key == "DataCode") < 0)
            { strErrorMessage = strErrorMessage + "Key \'DataCode\' nao encontrada\n"; }

            if (!String.IsNullOrEmpty(strErrorMessage))
            {
                logger.Error(strErrorMessage);
                throw new Exception(strErrorMessage);
            }
        }

    }
}
