using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class BdrState
    {
        //01 -TIPREG -TIPO DE REGISTRO FIXO "09" N(02) 01 02
        public int TipoDeRegistro { get; set; }

        //02 - CODNEG – CÓDIGO DE NEGOCIAÇÃO N(15) 03 14
        public string Ticker { get; set; }

        //03 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 15 26
        public string NomeResumido { get; set; }

        //04 –ESPECI – ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 27 36
        public string EspecificacaoPapel { get; set; }

        //05 –VALREF – VALOR DE REFERÊNCIA N(09)V99 37 47
        public decimal PrecoReferencia { get; set; }

        //06 -RESERVA EM BRANCO X(303) 48 350
        public string Reserva { get; set; }
    }
}
