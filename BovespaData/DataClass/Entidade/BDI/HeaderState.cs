using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class HeaderState
    {

        // 01 - TIPO DE REGISTRO FIXO "00" N(02) 01 02
        // 02 - NOME DO ARQUIVO VER DEFINIÇÃO ABAIXO X(08) 03 10
        //          CÓDIGO DO ARQUIVO FIXO "BDIN" X(04) 03 06
        //          CÓDIGO DO USUÁRIO FIXO "9999" N(04) 07 10
        // 03 - CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
        // 04 - CÓDIGO DO DESTINO FIXO "9999" N(04) 19 22
        // 05 - DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
        // 06 - DATA DO PREGÃO FORMATO AAAAMMDD N(08) 31 38
        // 07 - HORA DE GERAÇÃO FORMATO HHMM N(04) 39 42
        // 08 - RESERVA EM BRANCO X(308) 43 350 

        #region "Private Variables"

        public int TipoDeRegistro { get; set; }
        public string NomeDoArquivo { get; set; }
        public string CodOrigem { get; set; }
        public string CodDestino { get; set; }
        public DateTime DataGeracaoDoArquivo { get; set; }
        public DateTime DataDoPregao { get; set; }
        public string Reserva { get; set; }

        #endregion

        public SchemaStruct Schema;

        #region "Constructors"
        public HeaderState()
        {
            Schema = new SchemaStruct();
            Schema.ObjectName = "";
            Schema.TipoRegistro = "";
            Schema.NomeDoArquivo = "";
            Schema.CodOrigem = "";
            Schema.DataGeracao = "";
            Schema.Reserva = "";
        }
        #endregion

        #region "Schema Structure to return Object and Column Names"
        [Serializable]
        public struct SchemaStruct
        {
            public string ObjectName;
            public string TipoRegistro;
            public string NomeDoArquivo;
            public string CodOrigem;
            public string DataGeracao;
            public string Reserva;
        }
        #endregion
    }
}
