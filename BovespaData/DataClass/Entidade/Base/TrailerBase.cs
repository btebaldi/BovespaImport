using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    public abstract class TrailerBase : RegistroBase
    {
        /// <summary>
        /// Nome do arquivo
        /// </summary>
        public string NomeDoArquivo { get; set; }

        /// <summary>
        /// Codigo da origem fixo X(08)
        /// </summary>
        public string CodigoOrigem { get; set; }

        /// <summary>
        /// Data da geracao do arquivo formato "AAAAMMDD" N(08)
        /// </summary>
        public DateTime DataDoArquivo { get; set; }

        /// <summary>
        /// Total de registros incluir tambem os registros header e trailer. N(11)
        /// </summary>
        public int TotalRegistros { get; set; }
    }
}
