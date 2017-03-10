using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class CotacaoState
    {
        //    01 -TIPREG -TIPO DE REGISTRO FIXO "02" N(02) 01 02
        public int TipoDeRegistro { get; set; }

        //    02 -CODBDI -CÓDIGO BDI UTILIZADO PARA CLASSIFICAR OS PAPÉIS NA EMISSÃO DO BOLETIM DIÁRIO DE INFORMAÇÕES VER TABELA ASSOCIADA NE001 X(02) 03 04
        public string CodBdi { get; set; }

        //    03 -DESBDI -DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
        public string DescricaoBDI { get; set; }

        //    04 -NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 35 46
        public string NomeResumido { get; set; }

        //    05 -ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 47 56
        public string EspecificacaoPapel { get; set; }

        //    06 -INDCAR -INDICADOR DE CARACTERÍSTICA DO PAPEL VER TABELA ASSOCIADA PA020 X(01) 57 57
        public string IndicadorCaracteristica { get; set; }

        //    07 -CODNEG -CÓDIGO DE NEGOCIAÇÃO X(12) 58 69
        public string Ticker { get; set; }

        //    08 -TPMERC -TIPO DE MERCADO CÓD. DO MERCADO EM QUE O PAPEL ESTÁ CADASTRADO VER TABELA ASSOCIADA PA003 N(03) 70 72
        public int TipoDeMercado { get; set; }

        //    09 – NOMERC – DESCRIÇÃO DO TIPO DE MERCADO X(15) 73 87
        public string DescTipoMercado { get; set; }

        //    10 – PRAZOT – PRAZO EM DIAS DO MERCADO A TERMO X(03) 88 90
        public int Prazo { get; set; }

        //    11 – PREABE – PREÇO DE ABERTURA DO PAPEL (PREÇO DO PRIMEIRO NEGÓCIO EFETUADO COM O PAPEL-MERCADO) N(09)V99 91 101
        public decimal PrecoAbertura { get; set; }

        //    12 – PREMAX – PREÇO MÁXIMO DO PAPELMERCADO NO PREGÃO N(09)V99 102 112
        public decimal PrecoMaximo { get; set; }

        //    13 – PREMIN – PREÇO MÍNIMO DO PAPELMERCADO NO PREGÃO N(09)V99 113 123
        public decimal PrecoMinimo { get; set; }

        //    14 – PREMED – PREÇO MÉDIO DO PAPELMERCADO NO PREGÃO N(09)V99 124 134
        public decimal PrecoMedio { get; set; }

        //    15 -PREULT -PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM O PAPEL-MERCADO N(09)V99 135 145
        public decimal PrecoFechamento { get; set; }

        //    16 -SINOSC -SINAL DA OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR VER TABELA ASSOCIADA PA019 X(01) 146 146
        public string SinalOscilacao { get; set; }

        //    17 -OSCILA -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 147 151
        public decimal Oscilacao { get; set; }

        //    18 -PREOFC -PREÇO DA MELHOR OFERTA DE COMPRA DO PAPEL-MERCADO N(09)V99 152 162
        public decimal PrecoMelhorCompra { get; set; }

        //    19 -PREOFV -PREÇO DA MELHOR OFERTA DE VENDA DO PAPEL-MERCADO N(09)V99 163 173
        public decimal PrecoMelhorVenda { get; set; }

        //    20 -TOTNEG -NEG. NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL-MERCADO NO PREGÃO CORRENTE N(05) 174 178
        public int TotalNegocios { get; set; }

        //    21 -QUATOT -QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPELMERCADO N(15) 179 193
        public long Quantidade { get; set; }

        //    22 -VOLTOT -VOLUME TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPEL-MERCADO N(15)V99 194 210
        public decimal Volume { get; set; }

        //    23 -PREEXE -PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DO CONTRATO PARA O MERCADO DE TERMO SECUNDÁRIO N(09)V99 211 221
        public decimal PrecoExercicio { get; set; }

        //    24 -DATVEN -DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO AAAAMMDD N(08) 222 229 
        public DateTime DataVencimento { get; set; }

        //    25 -INDOPC -INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(01) 230 230
        public int IndicadorCorrecaoOpcao { get; set; }

        //    26 -NOMIND -DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 231 245
        public string DescIndicadorCorrecao { get; set; }

        //    27 -FATCOT -FATOR DE COTAÇÃO DO PAPEL VER TABELA ASSOCIADA EM021 N(07) 246 252
        public int FatorCotacao { get; set; }

        //    28 -PTOEXE -PREÇO DE EXERCÍCIO EM PONTOS PARA OPÇÕES REFERENCIADAS EM DÓLAR OU VALOR DE CONTRATO EM PONTOS PARA TERMO SECUNDÁRIO PARA OS REFERENCIADOS EM DOLAR, CADA PONTO EQUIVALE AO VALOR, NA MOEDA CORRENTE, DE UM CENTÉSIMO DA TAXA MÉDIA DO DÓLAR COMERCIAL. INTERBANCÁRIO DE FECHAMENTO DO DIA ANTERIOR, OU SEJA, 1 PONTO = 1/100 US$ N(07)V(06) 253 265
        public decimal PrecoExercicioPontos { get; set; }

        //    29 -CODISI -CÓDIGO DO PAPEL NO SISTEMA ISIN CÓDIGO DO PAPEL NO SISTEMA ISIN X(12) 266 277
        public string CodISIN { get; set; }

        //    30 -DISMES -NÚMERO DE DISTRIBUIÇÃO DO PAPEL NÚMERO DE SEQüÊNCIA DO PAPEL CORRESPONDENTE AO ESTADO DE DIREITO VIGENTE N(03) 278 280
        public int DistribuicaoMES { get; set; }

        //    31 -ESTILO – ESTILO ADOTADO PARA O EXERCÍCIO DE OPÇÕES DE COMPRA/VENDA VER TABELA ASSOCIADA PA015 N(01) 281 281 32 -NOMEST -DESCRIÇÃO DO ESTILO X(15) 282 296
        public string EstiloOpc { get; set; }

        //    33 -ICOATV -INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(03) 297 299
        public int IndicadorCorrecaoOpcao2 { get; set; }

        //    34 – OSCPRE -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 300 306
        public decimal Oscilacao2 { get; set; }

        //    35 -RESERVA EM BRANCO X(44) 307 350 
        public string Reserva { get; set; }
    }

}
