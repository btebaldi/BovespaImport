using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass.State.BdiFile
{
    public class MaisNegociadasState
    {
        /// <summary>
        /// 01 - TIPREG - TIPO DE REGISTRO FIXO "07" N(02) 01 02
        /// </summary>
        public int TipoDeRegistro { get; set; }

        /// <summary>
        /// 14 - CODMEG - CÓDIGO DE NEGOCIACAO X(12) 124 135
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// 04 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 26 37
        /// </summary>
        public string NomeResumido { get; set; }

        /// <summary>
        /// 05 - ESPECI - ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 38 47
        /// </summary>
        public string EspecificacaoPapel { get; set; }

        /// <summary>
        /// 11 - QUATOT - QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 87 101
        /// </summary>
        public long Quantidade { get; set; }

        /// <summary>
        /// 12 - VOLTOT - VOLUME GERAL NO PREGÃO DESTE PAPEL MERCADO N(15)V99 102 118 
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 02 - TPMERC - TIPO DE MERCADO N(03) 03 05
        /// </summary>
        public string tipoMercado { get; set; }

        /// <summary>
        /// 03 - NOMERC - DESCRIÇÃO DO TIPO DE MERCADO X(20) 06 25
        /// </summary>
        public string DescTipoMercado { get; set; }

        /// <summary>
        /// 06 - INDOPC - INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE N(02) 48 49
        /// </summary>
        public int IndicadorCorrecaoOpcao { get; set; }

        /// <summary>
        /// 07 - NOMIND - DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 50 64
        /// </summary>
        public string DescIndicadorCorrecao { get; set; }

        /// <summary>
        /// 08 - PREEXE - PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DE CONTRATO PARA OS MERCADOS DE TERMO SECUNDÁRIO N(09)V99 65 75
        /// </summary>
        public decimal PrecoExercicio { get; set; }

        /// <summary>
        /// 09 - DATVEN - DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO = "AAAAMMDD" N(08) 76 83
        /// </summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// 10 - PRAZOT - PRAZO EM DIAS DO MERCADO A TERMO N(03) 84 86
        /// </summary>
        public int Prazo { get; set; }

        /// <summary>
        /// 13 - PARTIC - PARTICIPAÇÃO DO VOLUME DO PAPEL NO VOLUME TOTAL DO MERCADO N(03)V99 119 123
        /// </summary>
        public decimal ParticiapacaoNoVolume { get; set; }

        /// <summary>
        /// 15 - ICOATV - INDICADOR DE CORREÇÃO DE PREÇOS DE ATIVOS VER TABELA ASSOCIADA PA004 N(03) 136 138
        /// </summary>
        public string IndicadorCorrecaoAtivo { get; set; }

        /// <summary>
        /// 16 - RESERVA EM BRANCO X(212) 139 350
        /// </summary>
        public string Reserva { get; set; }
    }
}