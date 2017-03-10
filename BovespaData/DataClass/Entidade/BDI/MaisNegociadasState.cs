using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class MaisNegociadasState : Base.NegociadasBase
    {
        //01 - TIPREG -TIPO DE REGISTRO FIXO "07" N(02) 01 02
        //02 - TPMERC -TIPO DE MERCADO N(03) 03 05
        //03 - NOMERC – DESCRIÇÃO DO TIPO DE MERCADO X(20) 06 25
        //04 - NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 26 37
        //05 - ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 38 47
        //06 – INDOPC – INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE N(02) 48 49
        //07 – NOMIND – DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 50 64
        //08 – PREEXE – PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DE CONTRATO PARA OS MERCADOS DE TERMO SECUNDÁRIO N(09)V99 65 75
        //09 – DATVEN – DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO = "AAAAMMDD" N(08) 76 83
        //10 – PRAZOT – PRAZO EM DIAS DO MERCADO A TERMO N(03) 84 86
        //11 - QUATOT -QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 87 101
        //12 - VOLTOT -VOLUME GERAL NO PREGÃO DESTE PAPEL MERCADO N(15)V99 102 118 
        //13 - PARTIC – PARTICIPAÇÃO DO VOLUME DO PAPEL NO VOLUME TOTAL DO MERCADO N(03)V99 119 123
        //14 – CODMEG -CÓDIGO DE NEGOCIACAO X(12) 124 135
        //15 - ICOATV -INDICADOR DE CORREÇÃO DE PREÇOS DE ATIVOS VER TABELA ASSOCIADA PA004 N(03) 136 138
        //16 - RESERVA EM BRANCO X(212) 139 350

        public string tipoMercado { get; set; }

        public string DescTipoMercado { get; set; }

        public int IndicadorCorrecaoOpcao { get; set; }

        public string DescIndicadorCorrecao { get; set; }

        public decimal PrecoExercicio { get; set; }

        public DateTime DataVencimento { get; set; }

        public int Prazo { get; set; }

        public decimal ParticiapacaoNoVolume { get; set; }

        public string IndicadorCorrecaoAtivo { get; set; }

        public string Reserva { get; set; }
    }
}