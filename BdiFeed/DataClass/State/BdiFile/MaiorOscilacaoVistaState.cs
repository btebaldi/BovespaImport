using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class MaiorOscilacaoVistaState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "04" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - INDOSC - INDICA SE É OSCILAÇÃO POSITIVA OU NEGATIVA "A" = ALTA (POSITIVA) "B" = BAIXA (NEGATIVA) X(01) 03 03 
        /// </summary>
        public string IndicacaoOscilacao { get; set; }

        /// <summary>
        /// 03 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 04 15
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// 04 - ESPECI - ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 16 25
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// 05 - PREULT - PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM PAPEL-MERCADO DURANTE O PREGÃO CORRENTE N(09)V99 26 36
        /// </summary>
        public decimal PrecoFechamento { get; set; }

        /// <summary>
        /// 06 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL-MERCADO NO PREGÃO CORRENTE N(05) 37 41
        /// </summary>
        public int TotalNegocios { get; set; }

        /// <summary>
        /// 07 - OSCPRE - OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 42 46
        /// </summary>
        public decimal Oscilacao { get; set; }

        /// <summary>
        /// 08 - CODMEG - CÓDIGO DE NEGOCIAÇÃO X(12) 47 58
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// 09 - OSCILA - OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 59 65
        /// </summary>
        public decimal Oscilacao2 { get; set; }

        //10 - RESERVA EM BRANCO X(285) 66 350
        public string Reserva { get; set; }
    }
}
