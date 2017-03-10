using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    abstract class CotacaoBase : NegociadasBase
    {
        /// <summary>
        /// Codigo BDI utilizado para classificar os papeis na emissao do boletim diario de informacoes ver tabela anexa X(02)
        /// </summary>
        public string CodBdi { get; set; }

        /// <summary>
        /// Codigo do mercado em que o papel esta cadastrado ver tabela anexa N(03)
        /// </summary>
        public int TipoMercado { get; set; }

        /// <summary>
        /// Codigo de negociacao do papel X(12)
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Nome resumido da empresa emissora do papel X(12)
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// Especificacao do papel para papeis pertencentes ao novo mercado ver tabela anexa X(10)
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// Codigo do tipo de mercado em que o papel esta cadastrado ver tabela anexa N(03)
        /// </summary>
        public int TipoDeMercado { get; set; }

        /// <summary>
        /// Prazo em dias do mercado a termo X(03)
        /// </summary>
        public int Prazo { get; set; }

        /// <summary>
        /// Preco de abertura do papel no pregao N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoAbertura { get; set; }

        /// <summary>
        /// Preco maximo do papel no pregao N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoMaximo { get; set; }

        /// <summary>
        /// Preco minimo do papel no pregao N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoMinimo { get; set; }

        /// <summary>
        /// Preco medio do papel no pregao N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoMedio { get; set; }

        /// <summary>
        /// Preco do ultimo negocio do papel no pregao N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoFechamento { get; set; }

        /// <summary>
        /// Preco da melhor oferta de compra do papel N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoMelhorCompra { get; set; }

        /// <summary>
        /// Preco da melhor oferta de venda do papel N(11)V99 ou N(09)V99
        /// </summary>
        public decimal PrecoMelhorVenda { get; set; }

        /// <summary>
        /// Numero de negocios efetuados com o papel mercado no pregao N(05)
        /// </summary>
        public int TotalNegocios { get; set; }

        /// <summary>
        /// Quantidade total de titulos negociados neste papel no mercado N(18) ou N(15)
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// Volume total de titulos negociados neste papel no mercado N(16)v99 ou N(15)V99
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Preco de exercicio para o mercado de opcoes ou valor do contrato para o mercado de termo secundario N(11)v99 ou N(09)V99
        /// </summary>
        public decimal PrecoExercicio { get; set; }

        /// <summary>
        /// Data do vencimento para os mercados de opcoes ou termo secundario formato "AAAAMMDD" N(08)
        /// </summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// Indicador de correcao de precos de exercicios ou valores de contrato para os mercados de opcoes ou termo secundario ver tabela anexa N(01)
        /// </summary>
        public int IndicadorCorrecaoOpcao { get; set; }

        /// <summary>
        /// Fator de cotacao do papel "1" = cotacao unitaria "1000" = cotacao por lote de mil acoes N(07)
        /// </summary>
        public int FatorCotacao { get; set; }

        /// <summary>
        /// Preco de exercicio em pontos para opcoes referenciadas em dolar ou valor de contrato em pontos para termo secundario para os referenciados em dolar, cada ponto equivale ao valor, na moeda corrente, de um centesimo da taxa media do dolar comercial. Interbancario de fechamento do dia anterior, ou seja, 1 ponto = 1/100 us$ N(07)V06
        /// </summary>
        public decimal PrecoExercicioPontos { get; set; }

        /// <summary>
        /// Codigo do papel no sistema ISIN ou codigo interno do papel codigo do papel no sistema ISIN a partir de 15-05-1995 x(12)
        /// </summary>
        public string CodISIN { get; set; }

        /// <summary>
        /// Numero de distribuicao do papel numero de sequencia do papel correspondente ao estado de direito vigente N(03)
        /// </summary>
        public int DistribuicaoMES { get; set; }
    }
}
