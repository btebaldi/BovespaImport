using System;
using System.Text;

namespace BovespaData.DataClass.Entidade.Historico
{
    /// <summary>
    /// Cotacoes historicas por papel-mercado
    /// </summary>
    public class CotacaoState
    {

        #region "Private fields"
        private int _tipoReg;
        private DateTime _dataPregao;
        private int _codBDI;
        private string _codNeg;
        private int _tpMerc;
        private string _nomRes;
        private string _especi;
        private string _prazoT;
        private string _modRef;
        private decimal _preAbe;
        private decimal _preMax;
        private decimal _preMin;
        private decimal _preMed;
        private decimal _preUlt;
        private decimal _preOfC;
        private decimal _preOfV;
        private int _totNeg;
        private long _quaTot;
        private decimal _volTot;
        private decimal _preExe;
        private int _indOpc;
        private DateTime _datVen;
        private int _fatCot;
        private decimal _ptoExe;
        private string _codISIN;
        private int _DISMES;
        #endregion

        #region "Column Properties"
        /// <summary>
        /// Tipo de registro fixo "01" N(02) 01 02
        /// </summary>
        public int TipoRegistro
        {
            get { return _tipoReg; }
            set { _tipoReg = value; }
        }

        /// <summary>
        /// Data do pregao formato "AAAAMMDD" N(08) 03 10
        /// </summary>
        public DateTime DataPregao
        {
            get { return _dataPregao; }
            set { _dataPregao = value; }
        }

        /// <summary>
        /// Codigo BDI utilizado para classificar os papeis na emissao do boletim diario de informacoes ver tabela anexa x(02) 11 12
        /// ToDo: Tabela anexa COD BDI
        /// </summary>
        public int CodigoBDI
        {
            get { return _codBDI; }
            set { _codBDI = value; }
        }

        /// <summary>
        /// Codigo de negociacao do papel x(12) 13 24
        /// </summary>
        public string Ticker
        {
            get { return _codNeg; }
            set { _codNeg = value; }
        }

        /// <summary>
        /// Codigo do mercado em que o papel esta cadastrado ver tabela anexa n(03) 25 27
        /// ToDo: Tabela anexa COD MERCADO
        /// </summary>
        public int TipoMercado
        {
            get { return _tpMerc; }
            set { _tpMerc = value; }
        }

        /// <summary>
        /// Nome resumido da empresa emissora do papel x(12) 28 39
        /// </summary>
        public string NomeResumido
        {
            get { return _nomRes; }
            set { _nomRes = value; }
        }

        /// <summary>
        /// Especificacao do papel ver tabela anexa x(10) 40 49
        /// ToDo: Tabela anexa Especificacao
        /// </summary>
        public string EspecificacaoPapel
        {
            get { return _especi; }
            set { _especi = value; }
        }

        /// <summary>
        /// Prazo em dias do mercado a termo x(03) 50 52
        /// </summary>
        public string Prazo
        {
            get { return _prazoT; }
            set { _prazoT = value; }
        }

        /// <summary>
        /// Moeda de referencia moeda usada na data do pregão x(04) 53 56
        /// ToDo: Moedas???
        /// </summary>
        public string Moeda
        {
            get { return _modRef; }
            set { _modRef = value; }
        }

        /// <summary>
        /// Preco de abertura do papel no pregao n(11)v99 57 69
        /// </summary>
        public decimal PrecoAbertura
        {
            get { return _preAbe; }
            set { _preAbe = value; }
        }

        /// <summary>
        /// Preco maximo do papel no pregao n(11)v99 70 82
        /// </summary>
        public decimal PrecoMaximo
        {
            get { return _preMax; }
            set { _preMax = value; }
        }

        /// <summary>
        /// Preco minimo do papel no pregao n(11)v99 83 95
        /// </summary>
        public decimal PrecoMinimo
        {
            get { return _preMin; }
            set { _preMin = value; }
        }

        /// <summary>
        /// Preco medio do papel no pregao n(11)v99 96 108
        /// </summary>
        public decimal PrecoMedio
        {
            get { return _preMed; ;}
            set { _preMed = value; }
        }

        /// <summary>
        /// Preco do ultimo negocio do papel no pregao n(11)v99 109 121
        /// </summary>
        public decimal PrecoFechamento
        {
            get { return _preUlt; }
            set { _preUlt = value; }
        }

        /// <summary>
        /// Preco da melhor oferta de compra do papel n(11)v99 122 134
        /// </summary>
        public decimal PrecoMelhorCompra
        {
            get { return _preOfC; }
            set { _preOfC = value; }
        }

        /// <summary>
        /// Preco da melhor oferta de venda do papel n(11)v99 135 147
        /// </summary>
        public decimal PrecoMelhorVenda
        {
            get { return _preOfV; }
            set { _preOfV = value; }
        }

        /// <summary>
        /// Numero de negocios efetuados com o papel mercado no pregao n(05) 148 152
        /// </summary>
        public int TotalNegocios
        {
            get { return _totNeg; }
            set { _totNeg = value; }
        }

        /// <summary>
        /// Quantidade total de titulos negociados neste papel no mercado n(18) 153 170
        /// </summary>
        public long Quantidade
        {
            get { return _quaTot; }
            set { _quaTot = value; }
        }

        /// <summary>
        /// Volume($) total de titulos negociados neste papel no mercado n(16)v99 171 188
        /// </summary>
        public decimal Volume
        {
            get { return _volTot; }
            set { _volTot = value; }
        }

        /// <summary>
        /// Preco de exercicio para o mercado de opcoes
        /// ou valor do contrato para o mercado de termo secundario n(11)v99 189 201
        /// </summary>
        public decimal PrecoExercicio
        {
            get { return _preExe; }
            set { _preExe = value; }
        }

        /// <summary>
        /// Indicador de correcao de precos de exercicios ou valores de contrato para os mercados de opcoes ou termo secundario ver tabela anexa n(01) 202 202
        /// ToDo: Tabela anexa Indicador de correcao
        /// </summary>
        public int IndicadorCorrecaoOpcao
        {
            get { return _indOpc; }
            set { _indOpc = value; }
        }

        /// <summary>
        /// Data do vencimento para os mercados de opcoes ou termo secundario formato "AAAAMMDD" n(08) 203 210
        /// </summary>
        public DateTime DataVencimento
        {
            get { return _datVen; }
            set { _datVen = value; }
        }

        /// <summary>
        /// Fator de cotacao do papel
        /// "1" = cotacao unitaria
        /// "1000" = cotacao por lote de mil acoes n(07) 211 217
        /// </summary>
        public int FatorCotacao
        {
            get { return _fatCot; }
            set { _fatCot = value; }
        }

        /// <summary>
        /// Preco de exercicio em pontos para opcoees referenciadas em dolar
        /// ou valor de contrato em pontos para termo secundario para os referenciados em dolar, 
        /// cada ponto equivale ao valor, na moeda corrente, de um centesimo da taxa media do dolar comercial interbancario de fechamento do dia anterior, 
        /// ou seja, 1 ponto = 1/100 us$ n(07)v06 218 230
        /// </summary>
        public decimal PrecoExercicioPontos
        {
            get { return _ptoExe; }
            set { _preExe = value; }
        }

        /// <summary>
        /// Codigo do papel no sistema ISIN 
        /// ou codigo interno do papel codigo do papel no sistema ISIN a partir de 15-05-1995 x(12) 231 242
        /// </summary>
        public string CodISIN
        {
            get { return _codISIN; }
            set { _codISIN = value; }
        }

        /// <summary>
        /// Numero de distribuicao do papel numero de sequencia do papel correspondente ao estado de direito vigente 9(03) 243 245
        /// </summary>
        public int DistribuicaoMES
        {
            get { return _DISMES; }
            set { _DISMES = value; }
        }
        #endregion

        public SchemaStruct Schema;

        #region "Constructors"
        public CotacaoState()
        {
            Schema = new SchemaStruct();

            Schema.ObjectName = "TB_HISTORICO_COTACAO";
            Schema.TipoRegistro = "TipoRegistro";
            Schema.DataPregao = "DataPregao";
            Schema.CodigoBDI = "CodDBI";
            Schema.Ticker = "Ticker";
            Schema.TipoMercado = "TipoMercado";
            Schema.NomeResumido = "NomeResumido";
            Schema.EspecificacaoPapel = "TipoPapel";
            Schema.Prazo = "Prazo";
            Schema.Moeda = "Moeda";
            Schema.PrecoAbertura = "PrecoAbertura";
            Schema.PrecoMaximo = "PrecoMaximo";
            Schema.PrecoMinimo = "PrecoMinimo";
            Schema.PrecoMedio = "PrecoMedio";
            Schema.PrecoFechamento = "PrecoFechamento";
            Schema.PrecoMelhorCompra = "PrecoMelhorCompra";
            Schema.PrecoMelhorVenda = "PrecoMelhorVenda";
            Schema.TotalNegocios = "TotalNegocios";
            Schema.Quantidade = "Quantidade";
            Schema.Volume = "Volume";
            Schema.PrecoExercicio = "PrecoExercicio";
            Schema.IndicadorCorrecaoOpcao = "IndCorrecao";
            Schema.DataVencimento = "DataVencimento";
            Schema.FatorCotacao = "FatorCotacao";
            Schema.PrecoExercicioPontos = "PrecoExercPontos";
            Schema.ISIN = "ISIN";
            Schema.DistribuicaoMES = "DistribMes";
        }
        #endregion
    }



    #region "Schema Structure to return Object and Column Names"
    [Serializable]
    public struct SchemaStruct
    {
        public string ObjectName;
        public string TipoRegistro;
        public string DataPregao;
        public string CodigoBDI;
        public string Ticker;
        public string TipoMercado;
        public string NomeResumido;
        public string EspecificacaoPapel;
        public string Prazo;
        public string Moeda;
        public string PrecoAbertura;
        public string PrecoMaximo;
        public string PrecoMinimo;
        public string PrecoMedio;
        public string PrecoFechamento;
        public string PrecoMelhorCompra;
        public string PrecoMelhorVenda;
        public string TotalNegocios;
        public string Quantidade;
        public string Volume;
        public string PrecoExercicio;
        public string IndicadorCorrecaoOpcao;
        public string DataVencimento;
        public string FatorCotacao;
        public string PrecoExercicioPontos;
        public string ISIN;
        public string DistribuicaoMES;

    }
    #endregion
}

