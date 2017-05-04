using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class HeaderState
    {
        /// <summary>
        /// 01 - TIPO DE REGISTRO FIXO "00" N(02) 01 02
        /// <summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - NOME DO ARQUIVO VER DEFINIÇÃO ABAIXO X(08) 03 10
        ///     CÓDIGO DO ARQUIVO FIXO "BDIN" X(04) 03 06
        /// <summary>
        public string NomeDoArquivo { get; set; }

        /// <summary>
        /// 03 - CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
        /// <summary>
        public string CodOrigem { get; set; }

        /// <summary>
        /// 04 - CÓDIGO DO DESTINO FIXO "9999" N(04) 19 22
        /// <summary>
        public string CodDestino { get; set; }

        /// <summary>
        /// 05 - DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
        /// <summary>
        public DateTime DataGeracaoDoArquivo { get; set; }

        /// <summary>
        /// 06 - DATA DO PREGÃO FORMATO AAAAMMDD N(08) 31 38
        /// <summary>
        public DateTime DataDoPregao { get; set; }

        /// <summary>
        /// 07 - HORA DE GERAÇÃO FORMATO HHMM N(04) 39 42

        /// <summary>
        /// 08 - RESERVA EM BRANCO X(308) 43 350 
        /// <summary>
        public string Reserva { get; set; }

    }
}
