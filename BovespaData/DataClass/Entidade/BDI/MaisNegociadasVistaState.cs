using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class MaisNegociadasVistaState : Base.NegociadasBase
    {
        //01 - TIPREG -TIPO DE REGISTRO FIXO "06" N(02) 01 02
        //02 - NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 03 14
        //03 - ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 15 24
        //04 - QUATOT -QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 25 39
        //05 - VOLTOT -VOLUME GERAL NO PREGÃO DESTE PAPEL -MERCADO N(15)V99 40 56
        //06 – CODMEG – CÓDIGO DE NEGOCIAÇÃO X(12) 57 68
        //07 - RESERVA EM BRANCO X(282) 69 350
        public string Reserva { get; set; }
    }
}
