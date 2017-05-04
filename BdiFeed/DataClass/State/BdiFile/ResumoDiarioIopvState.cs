using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class ResumoDiarioIopvState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "08" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - IDENTI - IDENTIFICAÇÃO DO IOPV N(02) 03 04
        /// </summary>
        public string Identificacao { get; set; }

        /// <summary>
        /// 03 - SIGLA - SIGLA DO IOPV X(04) 05 08
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// 04 - NOMRES - NOME RESUMIDO DO IOPV X(12) 09 20
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// 05 - NOMIND - NOME DO IOPV X(30) 21 50
        /// </summary>
        public string NomeIopv { get; set; }

        /// <summary>
        /// 06 - IDCABE - IOPV DE ABERTURA DO PREGÃO N(05)V99 51 57
        /// </summary>
        public decimal IopvAbertura { get; set; }

        /// <summary>
        /// 07 - IDCMIN - IOPV MÍNIMO DO PREGÃO N(05)V99 58 64
        /// </summary>
        public decimal IopvMinimo { get; set; }

        /// <summary>
        /// 08 - IDCMAX - IOPV MÁXIMO DO PREGÃO N(05)V99 65 71
        /// </summary>
        public decimal IopvMaximo { get; set; }

        /// <summary>
        /// 09 - IDCMED - IOPV DA MÉDIA ARITMÉTICA DOS IOPV‟s DO PREGÃO N(05)V99 72 78
        /// </summary>
        public decimal IopvMedia { get; set; }

        /// <summary>
        /// 10 - IDCFEC - IOPV DE FECHAMENTO N(05)V99 79 85
        /// </summary>
        public decimal IopvFechamento { get; set; }

        /// <summary>
        /// 11 - SINEVO - SINAL DA EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 86 86
        /// </summary>
        public decimal Evolucao { get; set; }

        /// <summary>
        /// 12 - EVOIND - EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO N(03)V99 87 91
        /// </summary>
        public string SinalEvoluvao { get; set; }

        /// <summary>
        /// 13 - RESERVA EM BRANCO X(259) 92 350
        /// </summary>
        public string Reserva { get; set; }
    }
}
