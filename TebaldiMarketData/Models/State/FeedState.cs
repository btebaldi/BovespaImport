using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tebaldi.MarketData.Models.State
{
    public class FeedState
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public FeedTypeEnum Type { get; set; }
        public Uri Uri { get; set; }
        public bool Active { get; set; }
        public string FileMask { get; set; }

        public List<FeedMappingState> ColumnMapping { get; set; }
        public List<FeedTransformationState> Transformations { get; set; }

        readonly SchemaStruct _schema;
        public SchemaStruct Schema { get { return _schema; } }

        #region "Constructors"
        /// <summary>
        /// Constructor
        /// </summary>
        public FeedState()
        {
            ColumnMapping = new List<FeedMappingState>();
            Transformations = new List<FeedTransformationState>();

            _schema = new SchemaStruct();
            _schema.ObjectName = "TB_FEED";
            _schema.FeedId = "FeedId";
            _schema.Name = "Name";
            _schema.FeedType = "FeedType";
            _schema.Origem = "Origem";
            _schema.FileMask = "FileMask";
            _schema.Active = "Active";
        }
        #endregion

        public string GetFileName(DateTime date)
        {
            string ret = FileMask;
            Match dateTimeMask = Regex.Match(ret, @"(?<=\[DateTime:).*(?=\])");

            ret = System.Text.RegularExpressions.Regex.Replace(ret, @"\[DateTime:.*\]", date.ToString(dateTimeMask.Value));
            return ret;
        }

        #region "Schema Structure to return Object and Column Names"
        [Serializable]
        public struct SchemaStruct
        {
            public string ObjectName;
            public string FeedId;
            public string Name;
            public string FeedType;
            public string Origem;
            public string FileMask;
            public string Active;
        }
        #endregion
    }

    public enum FeedTypeEnum
    {
        BDI,
        Csv,
        CsvNoHeader
    }


}
