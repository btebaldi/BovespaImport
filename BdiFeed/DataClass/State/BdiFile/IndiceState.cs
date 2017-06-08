using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class IndiceState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "01" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - IDENTI - IDENTIFICAÇÃO DO ÍNDICE VER TABELA ASSOCIADA IN001 N(02) 03 04
        /// </summary>    
        public int IdentificaIndice { get; set; }

        /// <summary>
        /// 03 - NOMIND - NOME DO ÍNDICE X(30) 05 34
        /// </summary>
        public string NomeIndice { get; set; }

        /// <summary>
        /// 04 - IDCABE - ÍNDICE DE ABERTURA DO PREGÃO N(06) 35 40
        /// </summary>
        public decimal IndiceAbertura { get; set; }

        /// <summary>
        /// 05 - IDCMIN - ÍNDICE MÍNIMO DO PREGÃO N(06) 41 46
        /// </summary>
        public decimal IndiceMinimo { get; set; }

        /// <summary>
        /// 06 - IDCMAX - ÍNDICE MÁXIMO DO PREGÃO N(06) 47 52
        /// </summary>
        public decimal IndiceMaximo { get; set; }

        /// <summary>
        /// 07 - IDCMED - ÍNDICE DA MÉDIA ARITMÉTICA DOS ÍNDICES DO PREGÃO N(06) 53 58
        /// </summary>
        public decimal IndiceMedia { get; set; }

        /// <summary>
        /// 08 - IDCLIQ - ÍNDICE PARA LIQUIDAÇÃO SOMENTE PARA O ÍNDICE "01" N(06) 59 64
        /// </summary>
        public decimal IndideLiquidacao { get; set; }

        /// <summary>
        /// 09 - IDMAXA - ÍNDICE MÁXIMO DO ANO N(06) 65 70
        /// </summary>
        public decimal AnoIndiceMaximo { get; set; }

        /// <summary>
        /// 10 - DATMAX - DATA DO ÍNDICE MÁXIMO DO ANO FORMATO AAAAMMDD N(08) 71 78
        /// </summary>
        public DateTime AnoDataIndiceMax { get; set; }

        /// <summary>
        /// 11 - IDMINA - ÍNDICE MÍNIMO DO ANO N(06) 79 84
        /// </summary>
        public decimal AnoIndiceMinimo { get; set; }

        /// <summary>
        /// 12 - DATMIN - DATA ÍNDICE MÍNIMO DO ANO FORMATO AAAAMMDD N(08) 85 92
        /// </summary>
        public DateTime AnoDataIndiceMin { get; set; }

        /// <summary>
        /// 13 - IDCFEC - ÍNDICE DE FECHAMENTO N(06) 93 98
        /// </summary>
        public decimal IndiceFechamento { get; set; }

        /// <summary>
        /// 14 - SINEVO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 99 99 
        /// </summary>
        public string SinalEvolucaoPercentual { get; set; }

        /// <summary>
        /// 15 - EVOIND - EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO N(03)V99 100 104
        /// </summary>
        public decimal EvolucaoPercentualDeFechamento { get; set; }

        /// <summary>
        /// 16 - SINONT - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM VER TABELA ASSOCIADA PA019 X(01) 105 105
        /// </summary>
        public string OntemSinalEvolucao { get; set; }

        /// <summary>
        /// 17 - EVONTE - EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM N(03)V99 106 110
        /// </summary>
        public decimal OntemEvolucaoPercentual { get; set; }

        /// <summary>
        /// 18 - SINSEM - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA VER TABELA ASSOCIADA PA019 X(01) 111 111
        /// </summary>
        public string NaSemanaSinalEvolucao { get; set; }

        /// <summary>
        /// 19 - EVOSEM - EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA N(03)V99 112 116
        /// </summary>
        public decimal NaSemanaEvolucaoPercentual { get; set; }

        /// <summary>
        /// 20 - SI1SEM - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA VER TABELA ASSOCIADA PA019 X(01) 117 117
        /// </summary>
        public string EmUmaSemanaSinalEvolucao { get; set; }

        /// <summary>
        /// 21 - EV1SEM - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA N(03)V99 118 122
        /// </summary>
        public decimal EmUmaSemanaEvolucaoPercentual { get; set; }

        /// <summary>
        /// 22 - SINMES - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS VER TABELA ASSOCIADA PA019 X(01) 123 123
        /// </summary>
        public string NoMesSinalEvolucao { get; set; }

        /// <summary>
        /// 23 - EVOMES - EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS N(03)V99 124 128
        /// </summary>
        public decimal NoMesEvolucaoPercentual { get; set; }

        /// <summary>
        /// 24 - SI1MES - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS VER TABELA ASSOCIADA PA019 X(01) 129 129
        /// </summary>
        public string EmUmMesSinalEvolucao { get; set; }

        /// <summary>
        /// 25 - EV1MES - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS N(03)V99 130 134
        /// </summary>
        public decimal EmUmMesEvolucaoPercentual { get; set; }

        /// <summary>
        /// 26 - SINANO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO VER TABELA ASSOCIADA PA019 X(01) 135 135
        /// </summary>
        public string NoAnoSinalEvolucao { get; set; }

        /// <summary>
        /// 27 - EVOANO - EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO N(03)V99 136 140
        /// </summary>
        public decimal NoAnoEvolucaoPercentual { get; set; }

        /// <summary>
        /// 28 - SI1ANO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO VER TABELA ASSOCIADA PA019 X(01) 141 141
        /// </summary>
        public string EmUmAnoSinalEvolucao { get; set; }

        /// <summary>
        /// 29 - EV1ANO - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO N(03)V99 142 146
        /// </summary>
        public decimal EmUmAnoEvolucaoPercentual { get; set; }

        /// <summary>
        /// 30 - ACOALT - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM ALTA N(03) 147 149
        /// </summary>
        public int AcoesNoIndiceEmAlta { get; set; }

        /// <summary>
        /// 31 - ACOBAI - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM BAIXA N(03) 150 152
        /// </summary>
        public int AcoesNoIndiceEmBaixa { get; set; }

        /// <summary>
        /// 32 - ACOEST - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE PERMANECERAM ESTÁVEIS N(03) 153 155
        /// </summary>
        public int AcoesNoIndiceEstaveis { get; set; }

        /// <summary>
        /// 33 - ACOTOT - NÚMERO TOTAL DE AÇÕES PERTENCENTES AO ÍNDICE N(03) 156 158
        /// </summary>
        public int AcoesNoIndiceTotal { get; set; }

        /// <summary>
        /// 34 - NNGIND - NÚMERO DE NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(06) 159 164
        /// </summary>
        public int NegociosComAcoesDoIndice { get; set; }

        /// <summary>
        /// 35 - QTDIND - QUANTIDADE DE TÍTULOS NEGOCIADOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15) 165 179
        /// </summary>
        public Int64 QtdTitulosNegociadosIndice { get; set; }

        /// <summary>
        /// 36 - VOLIND - VOLUME DOS NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15)V99 180 196
        /// </summary>
        public decimal VolumeNegociosDoIndice { get; set; }

        /// <summary>
        /// 37 - IDCMDP - ÍNDICE DA MÉDIA PONDERADA N(06) 197 202
        /// </summary>
        public decimal IndiceMediaPonderada { get; set; }

        /// <summary>
        /// 38 - RESERVA EM BRANCO X(148) 203 350 
        /// </summary>
        public string Reserva { get; set; }
    }
}
