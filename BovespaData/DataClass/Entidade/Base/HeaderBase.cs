using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    abstract class Header : RegistroBase
    {
        /// <summary>
        /// NOME DO ARQUIVO VER DEFINIÇÃO ABAIXO
        /// </summary>
        public string NomeDoArquivo { get; set; }

        /// <summary>
        /// CÓDIGO DA ORIGEM FIXO "BOVESPA"
        /// </summary>
        public string CodOrigem { get; set; }

        /// <summary>
        /// DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD
        /// </summary>
        public DateTime DataGeracaoDoArquivo { get; set; }
    }
}
