using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tebaldi.FeedImport.Business
{
    abstract class GenericProcess
    {
        #region Properties

        protected DirectoryInfo WorkingDir { get; set; }
        public Tebaldi.MarketData.Models.State.ProcessQueueState QueueInfo { get; set; }
        public Tebaldi.MarketData.Models.State.FeedState Feed { get; set; }
        public List<Tebaldi.MarketData.Models.State.KeyValueState> KeyValues { get; set; }
        public List<Tebaldi.MarketData.Models.State.FeedTransformationState> TransformationInfo { get; set; }
        public List<Tebaldi.MarketData.Models.State.FeedFilterState> Feedfilter { get; set; }

        protected DataTable Data;
        protected string GetValue(string key)
        { return KeyValues.Find(c => c.Key == key).Value; }
        #endregion

        #region abstract Methods

        public abstract void LoadConfig();
        public abstract void ExecuteFeed();
        public abstract void ExecuteFilter();

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="queue"></param>
        public GenericProcess(Tebaldi.MarketData.Models.State.ProcessQueueState queue)
        {
            QueueInfo = queue;
            WorkingDir = new DirectoryInfo(".\\Queue_" + QueueInfo.QueueId);
            Data = Tebaldi.MarketData.HistoricoCotacaoHandler.GetDataTable();
        }

        public DataTable GetData()
        { return Data; }

        public void ExecuteTransformations()
        {
            if (TransformationInfo == null)
            { throw new Exceptions.TransformationsNotLoaded("Transformacoes nao carregadas"); }

            if (TransformationInfo.Count > 0)
            {
                foreach (DataRow row in Data.Rows)
                {
                    foreach (MarketData.Models.State.FeedTransformationState transform in TransformationInfo.OrderBy(t => t.ExecuteOrder))
                    {
                        if (row[transform.OriginalColumn].Equals(Convert.ChangeType(transform.OriginalValue, Data.Columns[transform.OriginalColumn].DataType)))
                        {
                            row[transform.NewColumn] = Convert.ChangeType(transform.NewValue, Data.Columns[transform.NewColumn].DataType);
                        }
                    }
                }
            }
        }

        protected string ParseDateTimeMask(string text, DateTime date)
        {
            System.Text.RegularExpressions.Match pattern = System.Text.RegularExpressions.Regex.Match(text, "(?<=<~DateTime:).*(?=~>)");
            return System.Text.RegularExpressions.Regex.Replace(text, "<~DateTime:.*~>", date.ToString(pattern.Value));
        }
    }
}
