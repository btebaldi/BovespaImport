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
        public readonly Tebaldi.MarketData.Models.State.ProcessQueueState Queue;

        protected DataTable Data;

        #endregion

        #region abstract Methods

        public abstract void LoadConfig();
        public abstract void ExecuteFeed();
        

        public virtual void ExecuteFilter()
        {
            if (Queue.Process.Feed.Filter.Count > 0)
            {
                DataTable CleanData = Data.Clone();

                foreach (Tebaldi.MarketData.Models.State.FeedFilterState filter in Queue.Process.Feed.Filter)
                {
                    foreach (DataRow row in Data.Rows)
                    {
                        if (row[filter.ColumnName].Equals(Convert.ChangeType(filter.ColumnValue, Data.Columns[filter.ColumnName].DataType)))
                        {
                            CleanData.Rows.Add(row.ItemArray);
                            break;
                        }
                    }
                }
                Data = CleanData;
            }
        }

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="queue"></param>
        public GenericProcess(Tebaldi.MarketData.Models.State.ProcessQueueState queue)
        {
            Queue = queue;

            WorkingDir = new DirectoryInfo(".\\Queue_" + queue.ToString());
            Data = Tebaldi.MarketData.HistoricoCotacaoHandler.GetDataTable();
        }

        public DataTable GetData()
        { return Data; }

        public void ExecuteTransformations()
        {

            //List<Tebaldi.MarketData.Models.State.FeedTransformationState> TransformationInfo = 


            if (this.Queue.Process.Feed.Transformations == null)
            { throw new Exceptions.TransformationsNotLoaded("Transformacoes nao carregadas"); }

            if (this.Queue.Process.Feed.Transformations.Count > 0)
            {
                foreach (DataRow row in Data.Rows)
                {
                    foreach (MarketData.Models.State.FeedTransformationState transform in this.Queue.Process.Feed.Transformations.OrderBy(t => t.ExecuteOrder))
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
