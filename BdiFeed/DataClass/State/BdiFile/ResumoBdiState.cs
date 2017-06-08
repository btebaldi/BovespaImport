using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class ResumoBdiState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "03" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - CODBDI - CÓDIGO BDI VER TABELA ASSOCIADA NE001 N(02) 03 04
        /// </summary>
        public int CodBdi { get; set; }

        /// <summary>
        /// 03 - DESBDI - DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
        /// </summary>
        public string DescricaoBdi { get; set; }

        /// <summary>
        /// 04 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(05) 35 39
        /// </summary>
        public int TotalNegocios { get; set; }

        /// <summary>
        /// 05 - QUATOT - QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS N(15) 40 54
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// 06 - VOLTOT - VOLUME GERAL TRANSACIONADO NO PREGÃO CORRENTE N(15)V99 55 71
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 07 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(09) 72 80
        /// </summary>
        public int TotalNegocios2 { get; set; }

        /// <summary>
        /// 08 - RESERVA EM BRANCO X(270) 81 350
        /// </summary>
        public string Reserva { get; set; }
    }
}
