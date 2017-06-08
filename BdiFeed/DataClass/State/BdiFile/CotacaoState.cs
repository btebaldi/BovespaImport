using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class CotacaoState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "02" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 02 - CODBDI - CÓDIGO BDI UTILIZADO PARA CLASSIFICAR OS PAPÉIS NA EMISSÃO DO BOLETIM DIÁRIO DE INFORMAÇÕES VER TABELA ASSOCIADA NE001 X(02) 03 04
        /// </summary>
        public string CodBdi { get; set; }

        /// <summary>
        /// 03 - DESBDI - DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
        /// </summary>
        public string DescricaoBDI { get; set; }

        /// <summary>
        /// 04 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 35 46
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// 05 - ESPECI - ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 47 56
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// 06 - INDCAR - INDICADOR DE CARACTERÍSTICA DO PAPEL VER TABELA ASSOCIADA PA020 X(01) 57 57
        /// </summary>
        public string IndicadorCaracteristica { get; set; }

        /// <summary>
        /// 07 - CODNEG - CÓDIGO DE NEGOCIAÇÃO X(12) 58 69
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// 08 - TPMERC - TIPO DE MERCADO CÓD. DO MERCADO EM QUE O PAPEL ESTÁ CADASTRADO VER TABELA ASSOCIADA PA003 N(03) 70 72
        /// </summary>
        public int TipoDeMercado { get; set; }

        /// <summary>
        /// 09 - NOMERC - DESCRIÇÃO DO TIPO DE MERCADO X(15) 73 87
        /// </summary>
        public string DescTipoMercado { get; set; }

        /// <summary>
        /// 10 - PRAZOT - PRAZO EM DIAS DO MERCADO A TERMO X(03) 88 90
        /// </summary>
        public int Prazo { get; set; }

        /// <summary>
        /// 11 - PREABE - PREÇO DE ABERTURA DO PAPEL (PREÇO DO PRIMEIRO NEGÓCIO EFETUADO COM O PAPEL - MERCADO) N(09)V99 91 101
        /// </summary>
        public decimal PrecoAbertura { get; set; }

        /// <summary>
        /// 12 - PREMAX - PREÇO MÁXIMO DO PAPELMERCADO NO PREGÃO N(09)V99 102 112
        /// </summary>
        public decimal PrecoMaximo { get; set; }

        /// <summary>
        /// 13 - PREMIN - PREÇO MÍNIMO DO PAPELMERCADO NO PREGÃO N(09)V99 113 123
        /// </summary>
        public decimal PrecoMinimo { get; set; }

        /// <summary>
        /// 14 - PREMED - PREÇO MÉDIO DO PAPELMERCADO NO PREGÃO N(09)V99 124 134
        /// </summary>
        public decimal PrecoMedio { get; set; }

        /// <summary>
        /// 15 - PREULT - PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM O PAPEL - MERCADO N(09)V99 135 145
        /// </summary>
        public decimal PrecoFechamento { get; set; }

        /// <summary>
        /// 16 - SINOSC - SINAL DA OSCILAÇÃO DO PREÇO DO PAPEL - MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR VER TABELA ASSOCIADA PA019 X(01) 146 146
        /// </summary>
        public string SinalOscilacao { get; set; }

        /// <summary>
        /// 17 - OSCILA - OSCILAÇÃO DO PREÇO DO PAPEL - MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 147 151
        /// </summary>
        public decimal Oscilacao { get; set; }

        /// <summary>
        /// 18 - PREOFC - PREÇO DA MELHOR OFERTA DE COMPRA DO PAPEL - MERCADO N(09)V99 152 162
        /// </summary>
        public decimal PrecoMelhorCompra { get; set; }

        /// <summary>
        /// 19 - PREOFV - PREÇO DA MELHOR OFERTA DE VENDA DO PAPEL - MERCADO N(09)V99 163 173
        /// </summary>
        public decimal PrecoMelhorVenda { get; set; }

        /// <summary>
        /// 20 - TOTNEG - NEG. NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL - MERCADO NO PREGÃO CORRENTE N(05) 174 178
        /// </summary>
        public int TotalNegocios { get; set; }

        /// <summary>
        /// 21 - QUATOT - QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPELMERCADO N(15) 179 193
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// 22 - VOLTOT - VOLUME TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPEL - MERCADO N(15)V99 194 210
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 23 - PREEXE - PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DO CONTRATO PARA O MERCADO DE TERMO SECUNDÁRIO N(09)V99 211 221
        /// </summary>
        public decimal PrecoExercicio { get; set; }

        /// <summary>
        /// 24 - DATVEN - DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO AAAAMMDD N(08) 222 229 
        /// </summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// 25 - INDOPC - INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(01) 230 230
        /// </summary>
        public int IndicadorCorrecaoOpcao { get; set; }

        /// <summary>
        /// 26 - NOMIND - DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 231 245
        /// </summary>
        public string DescIndicadorCorrecao { get; set; }

        /// <summary>
        /// 27 - FATCOT - FATOR DE COTAÇÃO DO PAPEL VER TABELA ASSOCIADA EM021 N(07) 246 252
        /// </summary>
        public int FatorCotacao { get; set; }

        /// <summary>
        /// 28 - PTOEXE - PREÇO DE EXERCÍCIO EM PONTOS PARA OPÇÕES REFERENCIADAS EM DÓLAR OU VALOR DE CONTRATO EM PONTOS PARA TERMO SECUNDÁRIO PARA OS REFERENCIADOS EM DOLAR, CADA PONTO EQUIVALE AO VALOR, NA MOEDA CORRENTE, DE UM CENTÉSIMO DA TAXA MÉDIA DO DÓLAR COMERCIAL. INTERBANCÁRIO DE FECHAMENTO DO DIA ANTERIOR, OU SEJA, 1 PONTO = 1/100 US$ N(07)V(06) 253 265
        /// </summary>
        public decimal PrecoExercicioPontos { get; set; }

        /// <summary>
        /// 29 - CODISI - CÓDIGO DO PAPEL NO SISTEMA ISIN CÓDIGO DO PAPEL NO SISTEMA ISIN X(12) 266 277
        /// </summary>
        public string CodISIN { get; set; }

        /// <summary>
        /// 30 - DISMES - NÚMERO DE DISTRIBUIÇÃO DO PAPEL NÚMERO DE SEQüÊNCIA DO PAPEL CORRESPONDENTE AO ESTADO DE DIREITO VIGENTE N(03) 278 280
        /// </summary>
        public int DistribuicaoMES { get; set; }

        /// <summary>
        /// 31 - ESTILO - ESTILO ADOTADO PARA O EXERCÍCIO DE OPÇÕES DE COMPRA/VENDA VER TABELA ASSOCIADA PA015 N(01) 281 281 32 - NOMEST - DESCRIÇÃO DO ESTILO X(15) 282 296
        /// </summary>
        public string EstiloOpc { get; set; }

        /// <summary>
        /// 33 - ICOATV - INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(03) 297 299
        /// </summary>
        public int IndicadorCorrecaoOpcao2 { get; set; }

        /// <summary>
        /// 34 - OSCPRE - OSCILAÇÃO DO PREÇO DO PAPEL - MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 300 306
        /// </summary>
        public decimal Oscilacao2 { get; set; }

        /// <summary>
        /// 35 - RESERVA EM BRANCO X(44) 307 350 
        /// </summary>
        public string Reserva { get; set; }
    }

}
