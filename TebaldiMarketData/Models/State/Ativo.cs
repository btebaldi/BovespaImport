using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.MarketData.Models.State
{
    class Ativo
    {
        public int AtivoId { get; set; }
        public string ExtID { get; set; }
        public int TebaldiBizAtivoId { get; set; }
        public string Bolsa { get; set; }
        public int FeedId { get; set; }
        public bool Import { get; set; }

        public SchemaStruct Schema;

        #region "Constructors"
        public Ativo()
        {
            Schema = new SchemaStruct();
            Schema.ObjectName = "TB_ATIVO";

            Schema.AtivoId = "id";
            Schema.ExtID = "EXT_ID";
            Schema.TebaldiBizAtivoId = "IdAtivoTebaldiBiz";
            Schema.Bolsa = "Bolsa";
            Schema.FeedId = "Feed";
            Schema.Import = "Import";
            Schema.DataRegistro = "DataRegistro";
        }
        #endregion

        #region "Schema Structure to return Object and Column Names"
        [Serializable]
        public struct SchemaStruct
        {
            // Nome da tabela
            public string ObjectName;

            // Nome das colunas
            public string AtivoId;
            public string ExtID;
            public string TebaldiBizAtivoId;
            public string Bolsa;
            public string FeedId;
            public string Import;
            public string DataRegistro;
        }
        #endregion

    }
}
