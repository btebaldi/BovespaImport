using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class TrailerState
    {
        /// <summary>
        /// 01 - TIPO DE REGISTRO FIXO "99" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - NOME DO ARQUIVOVER DEFINIÇÃO ABAIXO X(08) 03 10
        ///     CÓDIGO DO ARQUIVO FIXO "BDIN" X(04) 03 06
        /// </summary>
        public string NomeDoArquivo { get; set; }

        /// <summary>
        /// 03 - CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
        /// </summary>
        public string CodigoOrigem { get; set; }

        /// <summary>
        /// 04 - CÓDIGO DO DESTINO FIXO "9999" N(04) 19 22
        /// </summary>
        public DateTime DataDoArquivo { get; set; }

        /// <summary>
        /// 05 - DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
        /// </summary>
        public int TotalRegistros { get; set; }

        /// <summary>
        /// 06 - TOTAL DE REGISTROS INCLUIR TAMBÉM OS REGISTROS HEADER E TRAILER N(09) 31 39 
        /// </summary>
        public string CodigoDestino { get; set; }

        /// <summary>
        /// 07 - RESERVA EM BRANCO X(311) 40 350
        /// </summary>
        public string Reserva { get; set; }
    }
}
