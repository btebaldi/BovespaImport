using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class ResumoBdiState : Base.RegistroBase
    {
        //01 - TIPREG - TIPO DE REGISTRO FIXO "03" N(02) 01 02
        //02 - CODBDI - CÓDIGO BDI VER TABELA ASSOCIADA NE001 N(02) 03 04
        //03 - DESBDI - DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
        //04 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(05) 35 39
        //05 - QUATOT - QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS N(15) 40 54
        //06 - VOLTOT - VOLUME GERAL TRANSACIONADO NO PREGÃO CORRENTE N(15)V99 55 71
        //07 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(09) 72 80
        //08 - RESERVA EM BRANCO X(270) 81 350
        public int CodBdi { get; set; }

        public string DescricaoBdi { get; set; }

        public int TotalNegocios { get; set; }

        public long Quantidade { get; set; }

        public decimal Volume { get; set; }

        public int TotalNegocios2 { get; set; }

        public string Reserva { get; set; }
    }
}
