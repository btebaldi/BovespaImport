using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Historico 
{
    public class HeaderState
    {

        #region "Private Variables"

        private int _tipoDeRegistro;
        private string _nomeDoArquivo;
        private string _codOrigem;
        private DateTime _dataGeracaoDoArquivo;
        private string _reserva;

        #endregion

        #region "Public Parameters"

        /// <summary>
        /// TIPO DE REGISTRO FIXO "00" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro
        {
            get { return _tipoDeRegistro; }
            set { _tipoDeRegistro = value; }
        }

        /// <summary>
        /// NOME DO ARQUIVO FIXO "COTAHIST.AAAA" X(13) 03 15
        /// </summary>
        public string NomeDoArquivo
        {
            get { return _nomeDoArquivo; }
            set { _nomeDoArquivo = value; }
        }

        /// <summary>
        /// CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 16 23
        /// </summary>
        public string CodigoOrigem
        {
            get { return _codOrigem; }
            set { _codOrigem = value; }
        }

        /// <summary>
        /// DATA DA GERAÇÃO DO ARQUIVO FORMATO "AAAAMMDD" N(08) 24 31
        /// </summary>
        public DateTime DataDoArquivo
        {
            get { return _dataGeracaoDoArquivo; }
            set { _dataGeracaoDoArquivo = value; }
        }

        /// <summary>
        /// RESERVA PREENCHER COM BRANCOS X(214) 32 245
        /// </summary>
        public string Reserva
        {
            get { return _reserva; }
            set { _reserva = value; }
        }

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
