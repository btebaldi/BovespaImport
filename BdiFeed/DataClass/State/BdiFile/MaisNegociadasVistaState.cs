using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class MaisNegociadasVistaState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "06" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 03 14
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// 03 - ESPECI - ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 15 24
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// 04 - QUATOT - QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 25 39
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// 05 - VOLTOT - VOLUME GERAL NO PREGÃO DESTE PAPEL - MERCADO N(15)V99 40 56
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 06 - CODMEG - CÓDIGO DE NEGOCIAÇÃO X(12) 57 68
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// 07 - RESERVA EM BRANCO X(282) 69 350
        /// </summary>
        public string Reserva { get; set; }
    }
}
