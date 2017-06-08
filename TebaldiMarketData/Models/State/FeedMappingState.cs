using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Globalization;

namespace Tebaldi.MarketData.Models.State
{
    public class FeedMappingState
    {
        public int MappingId { get; set; }

        public int FeedId { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string StaticValue { get; set; }
               
        public Type Type { get; set; }
        public string DateTimeParseMask { get; set; }
        public CultureInfo Culture { get; set; }
        public string Destination { get; set; }
        public FeedMappingTypeEnum MappingType
        {
            get
            {
                if (!String.IsNullOrEmpty(StaticValue))
                { return FeedMappingTypeEnum.Static; }
                else if (!String.IsNullOrEmpty(ColumnName))
                { return FeedMappingTypeEnum.Name; }
                else if (ColumnIndex > 0)
                { return FeedMappingTypeEnum.Index; }
                else
                { return FeedMappingTypeEnum.Invalid; }
            }
        }

        readonly string _typeFromDb;
        readonly string _cultureFromDb;



        #region "Constructors"
        public FeedMappingState()
        {
            Type = typeof(String);
            Culture = new CultureInfo("");

            Schema = new SchemaStruct();
            Schema.ObjectName = "TB_FEED_MAPPING";
            Schema.MappingId = "MappingId";
            Schema.FeedId = "FeedId";
            Schema.ColumnIndex = "ColumnIndex";
            Schema.ColumnName = "ColumnName";
            Schema.StaticValue = "StaticValue";
            Schema.Type = "Type";
            Schema.DateTimeParseMask = "DateTimeParseMask";
            Schema.Culture = "Culture";
            Schema.Destination = "Destination";
        }
        #endregion

        public SchemaStruct Schema;



        #region "Schema Structure to return Object and Column Names"
        [Serializable]
        public struct SchemaStruct
        {
            public string ObjectName;
            public string MappingId;
            public string FeedId;
            public string ColumnIndex;
            public string ColumnName;
            public string StaticValue;
            public string Type;
            public string DateTimeParseMask;
            public string Culture;
            public string Destination;
        }
        #endregion
    }

    public enum FeedMappingTypeEnum
    {
        Index,
        Name,
        Static,
        Invalid
    }
}
