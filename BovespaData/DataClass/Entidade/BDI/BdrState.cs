using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class BdrState : Entidade.Base.RegistroBase
    {
        //01 -TIPREG -TIPO DE REGISTRO FIXO "09" N(02) 01 02
        //02 - CODNEG – CÓDIGO DE NEGOCIAÇÃO N(15) 03 14
        //03 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 15 26
        //04 –ESPECI – ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 27 36
        //05 –VALREF – VALOR DE REFERÊNCIA N(09)V99 37 47
        //06 -RESERVA EM BRANCO X(303) 48 350
        public decimal PrecoReferencia { get; set; }

        public string Reserva { get; set; }

        public string Ticker { get; set; }

        public string NomeResumido { get; set; }

        public string EspecificacaoPapel { get; set; }
    }
}
