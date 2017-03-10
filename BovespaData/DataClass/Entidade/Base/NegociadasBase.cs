using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    public abstract class NegociadasBase : RegistroBase
    {

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
        /// Quantidade total de titulos negociados neste papel no mercado N(18) ou N(15)
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// Volume total de titulos negociados neste papel no mercado N(16)v99 ou N(15)V99
        /// </summary>
        public decimal Volume { get; set; }


    }
}
