using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class IndiceState
    {

        //    01 - TIPREG - TIPO DE REGISTRO FIXO "01" N(02) 01 02
        //    02 - IDENTI - IDENTIFICAÇÃO DO ÍNDICE VER TABELA ASSOCIADA IN001 N(02) 03 04
        //    03 - NOMIND - NOME DO ÍNDICE X(30) 05 34
        //    04 - IDCABE – ÍNDICE DE ABERTURA DO PREGÃO N(06) 35 40
        //    05 - IDCMIN - ÍNDICE MÍNIMO DO PREGÃO N(06) 41 46
        //    06 - IDCMAX - ÍNDICE MÁXIMO DO PREGÃO N(06) 47 52
        //    07 - IDCMED - ÍNDICE DA MÉDIA ARITMÉTICA DOS ÍNDICES DO PREGÃO N(06) 53 58
        //    08 - IDCLIQ - ÍNDICE PARA LIQUIDAÇÃO SOMENTE PARA O ÍNDICE "01" N(06) 59 64
        //    09 – IDMAXA - ÍNDICE MÁXIMO DO ANO N(06) 65 70
        //    10 - DATMAX - DATA DO ÍNDICE MÁXIMO DO ANO FORMATO AAAAMMDD N(08) 71 78
        //    11 - IDMINA - ÍNDICE MÍNIMO DO ANO N(06) 79 84
        //    12 - DATMIN - DATA ÍNDICE MÍNIMO DO ANO FORMATO AAAAMMDD N(08) 85 92
        //    13 - IDCFEC - ÍNDICE DE FECHAMENTO N(06) 93 98
        //    14 - SINEVO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 99 99 
        //    15 - EVOIND - EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO N(03)V99 100 104
        //    16 - SINONT - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM VER TABELA ASSOCIADA PA019 X(01) 105 105
        //    17 - EVONTE - EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM N(03)V99 106 110
        //    18 - SINSEM - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA VER TABELA ASSOCIADA PA019 X(01) 111 111
        //    19 - EVOSEM - EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA N(03)V99 112 116
        //    20 - SI1SEM - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA VER TABELA ASSOCIADA PA019 X(01) 117 117
        //    21 - EV1SEM - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA N(03)V99 118 122
        //    22 - SINMES - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS VER TABELA ASSOCIADA PA019 X(01) 123 123
        //    23 - EVOMES - EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS N(03)V99 124 128
        //    24 - SI1MES - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS VER TABELA ASSOCIADA PA019 X(01) 129 129
        //    25 - EV1MES - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS N(03)V99 130 134
        //    26 - SINANO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO VER TABELA ASSOCIADA PA019 X(01) 135 135
        //    27 - EVOANO - EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO N(03)V99 136 140
        //    28 - SI1ANO - SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO VER TABELA ASSOCIADA PA019 X(01) 141 141
        //    29 - EV1ANO - EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO N(03)V99 142 146
        //    30 - ACOALT - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM ALTA N(03) 147 149
        //    31 - ACOBAI - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM BAIXA N(03) 150 152
        //    32 - ACOEST - NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE PERMANECERAM ESTÁVEIS N(03) 153 155
        //    33 - ACOTOT - NÚMERO TOTAL DE AÇÕES PERTENCENTES AO ÍNDICE N(03) 156 158
        //    34 - NNGIND - NÚMERO DE NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(06) 159 164
        //    35 - QTDIND - QUANTIDADE DE TÍTULOS NEGOCIADOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15) 165 179
        //    36 - VOLIND - VOLUME DOS NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15)V99 180 196
        //    37 - IDCMDP - ÍNDICE DA MÉDIA PONDERADA N(06) 197 202
        //    38 - RESERVA EM BRANCO X(148) 203 350 


        #region "Properties Variables"

        //    01 -TIPREG -TIPO DE REGISTRO FIXO "01" N(02) 01 02
        public int TipoDeRegistro { get; set; }
        //    02 -IDENTI -IDENTIFICAÇÃO DO ÍNDICE VER TABELA ASSOCIADA IN001 N(02) 03 04
        public int IdentificaIndice { get; set; }
        //    03 -NOMIND -NOME DO ÍNDICE X(30) 05 34
        public string NomeIndice { get; set; }
        //    04 -IDCABE – ÍNDICE DE ABERTURA DO PREGÃO N(06) 35 40
        public decimal IndiceAbertura { get; set; }
        //    05 -IDCMIN -ÍNDICE MÍNIMO DO PREGÃO N(06) 41 46
        public decimal IndiceMinimo { get; set; }
        //    06 -IDCMAX -ÍNDICE MÁXIMO DO PREGÃO N(06) 47 52
        public decimal IndiceMaximo { get; set; }
        //    07 -IDCMED -ÍNDICE DA MÉDIA ARITMÉTICA DOS ÍNDICES DO PREGÃO N(06) 53 58
        public decimal IndiceMedia { get; set; }
        //    08 -IDCLIQ -ÍNDICE PARA LIQUIDAÇÃO SOMENTE PARA O ÍNDICE "01" N(06) 59 64
        public decimal IndideLiquidacao { get; set; }
        //    09 – IDMAXA – ÍNDICE MÁXIMO DO ANO N(06) 65 70
        public decimal AnoIndiceMaximo { get; set; }
        //    10 -DATMAX -DATA DO ÍNDICE MÁXIMO DO ANO FORMATO AAAAMMDD N(08) 71 78
        public DateTime AnoDataIndiceMax { get; set; }
        //    11 -IDMINA -ÍNDICE MÍNIMO DO ANO N(06) 79 84
        public decimal AnoIndiceMinimo { get; set; }
        //    12 -DATMIN -DATA ÍNDICE MÍNIMO DO ANO FORMATO AAAAMMDD N(08) 85 92
        public DateTime AnoDataIndiceMin { get; set; }
        //    13 -IDCFEC -ÍNDICE DE FECHAMENTO N(06) 93 98
        public decimal IndiceFechamento { get; set; }
        //    14 -SINEVO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 99 99 
        public string SinalEvolucaoPercentual { get; set; }
        //    15 -EVOIND -EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO N(03)V99 100 104
        public decimal EvolucaoPercentualDeFechamento { get; set; }
        //    16 -SINONT -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM VER TABELA ASSOCIADA PA019 X(01) 105 105
        public string OntemSinalEvolucao { get; set; }
        //    17 -EVONTE -EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM N(03)V99 106 110
        public decimal OntemEvolucaoPercentual { get; set; }
        //    18 -SINSEM -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA VER TABELA ASSOCIADA PA019 X(01) 111 111
        public string NaSemanaSinalEvolucao { get; set; }
        //    19 -EVOSEM -EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA N(03)V99 112 116
        public decimal NaSemanaEvolucaoPercentual { get; set; }
        //    20 -SI1SEM -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA VER TABELA ASSOCIADA PA019 X(01) 117 117
        public string EmUmaSemanaSinalEvolucao { get; set; }
        //    21 -EV1SEM -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA N(03)V99 118 122
        public decimal EmUmaSemanaEvolucaoPercentual { get; set; }
        //    22 -SINMES -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS VER TABELA ASSOCIADA PA019 X(01) 123 123
        public string NoMesSinalEvolucao { get; set; }
        //    23 -EVOMES -EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS N(03)V99 124 128
        public decimal NoMesEvolucaoPercentual { get; set; }
        //    24 -SI1MES -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS VER TABELA ASSOCIADA PA019 X(01) 129 129
        public string EmUmMesSinalEvolucao { get; set; }
        //    25 -EV1MES -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS N(03)V99 130 134
        public decimal EmUmMesEvolucaoPercentual { get; set; }
        //    26 -SINANO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO VER TABELA ASSOCIADA PA019 X(01) 135 135
        public string NoAnoSinalEvolucao { get; set; }
        //    27 -EVOANO -EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO N(03)V99 136 140
        public decimal NoAnoEvolucaoPercentual { get; set; }
        //    28 -SI1ANO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO VER TABELA ASSOCIADA PA019 X(01) 141 141
        public string EmUmAnoSinalEvolucao { get; set; }
        //    29 -EV1ANO -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO N(03)V99 142 146
        public decimal EmUmAnoEvolucaoPercentual { get; set; }
        //    30 -ACOALT -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM ALTA N(03) 147 149
        public int AcoesNoIndiceEmAlta { get; set; }
        //    31 -ACOBAI -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM BAIXA N(03) 150 152
        public int AcoesNoIndiceEmBaixa { get; set; }
        //    32 -ACOEST -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE PERMANECERAM ESTÁVEIS N(03) 153 155
        public int AcoesNoIndiceEstaveis { get; set; }
        //    33 -ACOTOT -NÚMERO TOTAL DE AÇÕES PERTENCENTES AO ÍNDICE N(03) 156 158
        public int AcoesNoIndiceTotal { get; set; }
        //    34 -NNGIND -NÚMERO DE NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(06) 159 164
        public int NegociosComAcoesDoIndice { get; set; }
        //    35 -QTDIND -QUANTIDADE DE TÍTULOS NEGOCIADOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15) 165 179
        public Int64 QtdTitulosNegociadosIndice { get; set; }
        //    36 -VOLIND -VOLUME DOS NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15)V99 180 196
        public decimal VolumeNegociosDoIndice { get; set; }
        //    37 -IDCMDP -ÍNDICE DA MÉDIA PONDERADA N(06) 197 202
        public decimal IndiceMediaPonderada { get; set; }
        //    38 -RESERVA EM BRANCO X(148) 203 350 
        public string Reserva { get; set; }

        #endregion
    }
}
