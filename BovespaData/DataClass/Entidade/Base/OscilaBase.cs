using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    public class OscilaBase : RegistroBase
    {
        /// <summary>
        /// Indica se e oscilacao positiva ou negativa "A" = alta (positiva) "B" = baixa (negativa) X(01)
        /// </summary>
        public string IndicacaoOscilacao { get; set; }

        /// <summary>
        /// Nome resumido da empresa emissora do papel X(12)
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// Especificacao do papel para papeis pertencentes ao novo mercado. X(10) 
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// Preco do ultimo negocio efetuado com papel-mercado durante o pregao corrente N(09)V99
        /// </summary>
        public decimal PrecoFechamento { get; set; }

        /// <summary>
        /// Número de negócios efetuados com o papel-mercado no pregão corrente N(05)
        /// </summary>
        public int TotalNegocios { get; set; }

        /// <summary>
        /// Oscilacao do preco do papel-mercado em relação ao pregão anterior N(03)V99
        /// </summary>
        public decimal Oscilacao { get; set; }

        /// <summary>
        /// Código de negociação X(12)
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Oscilação do preço do papel-mercado em relação ao pregão anterior N(05)V99
        /// </summary>
        public decimal Oscilacao2 { get; set; }
    }
}
