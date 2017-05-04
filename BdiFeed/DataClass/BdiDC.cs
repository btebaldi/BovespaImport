using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.DataClass
{
    public class BdiDC
    {
        private System.Globalization.CultureInfo fileCultureinfo = System.Globalization.CultureInfo.InvariantCulture;

        #region "Data Retrieval Methods"

        protected State.BdiFileState LoadFile(FileInfo file)
        {
            State.BdiFileState flatFile = new State.BdiFileState();

            //Registro - 00 - Header
            //Registro - 01 - Resumo Diário dos Índices
            //Registro - 02 - Resumo Diário de Negociações por Papel - Mercado
            //Registro - 03 - Resumo Diário de Negociações por Código de BDI
            //Registro - 04 - Maiores Oscilações no Mercado a Vista
            //Registro - 05 - Maiores Oscilações das ações do Ibovespa
            //Registro - 06 - As mais Negociadas no Mercado a Vista
            //Registro - 07 - As Mais Negociadas
            //Registro - 08 - Resumo Diário dos IOPVs
            //Registro - 09 - BDRs Não Patrocinados – Valor de Referência
            //Registro - 99 - Trailer

            if (!file.Exists)
            { throw new Exceptions.BdiFileNotFoundException("Arquivo BDI nao existe (" + file.FullName + ")"); }


            // Read the file and display it line by line.
            System.IO.StreamReader fileReader = new System.IO.StreamReader(file.FullName);
            string line = "";
            while ((line = fileReader.ReadLine()) != null)
            {
                string tipoRegistro = line.Substring(0, 2);

                if (tipoRegistro == "00")
                {
                    flatFile.Header = ReadHeader(line);
                }
                else if (tipoRegistro == "01")
                {
                    flatFile.Indices.Add(ReadIndice(line));
                }
                else if (tipoRegistro == "02")
                {
                    flatFile.Cotacoes.Add(ReadCotacao(line));
                }
                else if (tipoRegistro == "03")
                {
                    flatFile.ResumoPorCodBdi.Add(ReadResumoPorCodBdi(line));
                }
                else if (tipoRegistro == "04")
                {
                    flatFile.MaiorOsilacaoAvista.Add(ReadMaiorOscilacaoAvista(line));
                }
                else if (tipoRegistro == "05")
                {
                    flatFile.MaiorOsilacaoIbov.Add(ReadMaiorOscilacaoIbov(line));
                }
                else if (tipoRegistro == "06")
                {
                    flatFile.MaisNegociadasAVista.Add(ReadMaisNegociadasAVista(line));
                }
                else if (tipoRegistro == "07")
                {
                    flatFile.MaisNegociadas.Add(ReadMaisNegociadas(line));
                }
                else if (tipoRegistro == "08")
                {
                    flatFile.Iopv.Add(ReadIopv(line));
                }
                else if (tipoRegistro == "09")
                {
                    flatFile.BDR.Add(ReadBdr(line));
                }
                else if (tipoRegistro == "99")
                {
                    flatFile.Trailer = ReadTrailer(line);
                }
                else
                {
                    throw new Exceptions.BdiFeedTipoInvalidoException("Tipo de resgistro invalido. Programa nao consegue interpretar a linha do arquivo. \nfile: " + file.FullName + "\n line:" + line);
                }
            }

            fileReader.Close();

            return flatFile;

        }

        private State.BdiFile.HeaderState ReadHeader(string line)
        {
            // 01 -TIPO DE REGISTRO FIXO "00" N(02) 01 02
            // 02 -NOME DO ARQUIVO VER DEFINIÇÃO ABAIXO X(08) 03 10
            // CÓDIGO DO ARQUIVO FIXO "BDIN" X(04) 03 06
            // CÓDIGO DO USUÁRIO FIXO "9999" N(04) 07 10
            // 03 - CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
            // 04 - CÓDIGO DO DESTINO FIXO "9999" N(04) 19 22
            // 05 - DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
            // 06 - DATA DO PREGÃO FORMATO AAAAMMDD N(08) 31 38
            // 07 - HORA DE GERAÇÃO FORMATO HHMM N(04) 39 42
            // 08 - RESERVA EM BRANCO X(308) 43 350 

            State.BdiFile.HeaderState header = new State.BdiFile.HeaderState();

            header.TipoDeRegistro = 0;
            header.NomeDoArquivo = line.Substring(2, 8).Trim();
            header.CodOrigem = line.Substring(10, 8).Trim();
            header.CodDestino = line.Substring(18, 4).Trim();
            header.DataGeracaoDoArquivo = new DateTime(
                Convert.ToInt32(line.Substring(22, 4)),
                Convert.ToInt32(line.Substring(26, 2)),
                Convert.ToInt32(line.Substring(28, 2)),
                Convert.ToInt32(line.Substring(38, 2)),
                Convert.ToInt32(line.Substring(40, 2)),
                00
                );
            header.DataDoPregao = DateTime.ParseExact(line.Substring(30, 8), "yyyyMMdd", fileCultureinfo);

            header.Reserva = line.Substring(42, 308).Trim();

            return header;
        }

        private State.BdiFile.IndiceState ReadIndice(string line)
        {
            State.BdiFile.IndiceState indice = new State.BdiFile.IndiceState();

            //    01 -TIPREG -TIPO DE REGISTRO FIXO "01" N(02) 01 02
            indice.TipoDeRegistro = 1;

            //    02 -IDENTI -IDENTIFICAÇÃO DO ÍNDICE VER TABELA ASSOCIADA IN001 N(02) 03 04
            indice.IdentificaIndice = Convert.ToInt32(line.Substring(2, 2).Trim());

            //    03 -NOMIND -NOME DO ÍNDICE X(30) 05 34
            indice.NomeIndice = line.Substring(4, 30).Trim();

            //    04 -IDCABE – ÍNDICE DE ABERTURA DO PREGÃO N(06) 35 40
            indice.IndiceAbertura = Convert.ToDecimal(line.Substring(34, 6).Trim());

            //    05 -IDCMIN -ÍNDICE MÍNIMO DO PREGÃO N(06) 41 46
            indice.IndiceMinimo = Convert.ToDecimal(line.Substring(40, 6).Trim());

            //    06 -IDCMAX -ÍNDICE MÁXIMO DO PREGÃO N(06) 47 52
            indice.IndiceMaximo = Convert.ToDecimal(line.Substring(46, 6).Trim());

            //    07 -IDCMED -ÍNDICE DA MÉDIA ARITMÉTICA DOS ÍNDICES DO PREGÃO N(06) 53 58
            indice.IndiceMedia = Convert.ToDecimal(line.Substring(52, 6).Trim());

            //    08 -IDCLIQ -ÍNDICE PARA LIQUIDAÇÃO SOMENTE PARA O ÍNDICE "01" N(06) 59 64
            indice.IndideLiquidacao = Convert.ToDecimal(line.Substring(59, 6).Trim());

            //    09 – IDMAXA – ÍNDICE MÁXIMO DO ANO N(06) 65 70
            indice.AnoIndiceMaximo = Convert.ToDecimal(line.Substring(64, 6).Trim());

            //    10 -DATMAX -DATA DO ÍNDICE MÁXIMO DO ANO FORMATO AAAAMMDD N(08) 71 78
            indice.AnoDataIndiceMax = DateTime.ParseExact(line.Substring(70, 8), "yyyyMMdd", fileCultureinfo);

            //    11 -IDMINA -ÍNDICE MÍNIMO DO ANO N(06) 79 84
            indice.AnoIndiceMinimo = Convert.ToDecimal(line.Substring(78, 6).Trim());

            //    12 -DATMIN -DATA ÍNDICE MÍNIMO DO ANO FORMATO AAAAMMDD N(08) 85 92
            indice.AnoDataIndiceMin = DateTime.ParseExact(line.Substring(84, 8), "yyyyMMdd", fileCultureinfo);

            //    13 -IDCFEC -ÍNDICE DE FECHAMENTO N(06) 93 98
            indice.IndiceFechamento = Convert.ToDecimal(line.Substring(92, 6).Trim());

            //    14 -SINEVO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 99 99 
            indice.SinalEvolucaoPercentual = line.Substring(98, 1).Trim();

            //    15 -EVOIND -EVOLUÇÃO PERCENTUAL DO ÍNDICE DE FECHAMENTO N(03)V99 100 104
            indice.EvolucaoPercentualDeFechamento = Convert.ToDecimal(line.Substring(99, 5).Trim()) / 100;

            //    16 -SINONT -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM VER TABELA ASSOCIADA PA019 X(01) 105 105
            indice.OntemSinalEvolucao = line.Substring(104, 1).Trim();

            //    17 -EVONTE -EVOLUÇÃO PERCENTUAL DO ÍNDICE DE ONTEM N(03)V99 106 110
            indice.OntemEvolucaoPercentual = Convert.ToDecimal(line.Substring(105, 5).Trim()) / 100;

            //    18 -SINSEM -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA VER TABELA ASSOCIADA PA019 X(01) 111 111
            indice.NaSemanaSinalEvolucao = line.Substring(110, 1).Trim();

            //    19 -EVOSEM -EVOLUÇÃO PERCENTUAL DO ÍNDICE NA SEMANA N(03)V99 112 116
            indice.NaSemanaEvolucaoPercentual = Convert.ToDecimal(line.Substring(111, 5).Trim()) / 100;

            //    20 -SI1SEM -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA VER TABELA ASSOCIADA PA019 X(01) 117 117
            indice.EmUmaSemanaSinalEvolucao = line.Substring(116, 1).Trim();

            //    21 -EV1SEM -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UMA SEMANA N(03)V99 118 122
            indice.EmUmaSemanaEvolucaoPercentual = Convert.ToDecimal(line.Substring(117, 5).Trim()) / 100;

            //    22 -SINMES -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS VER TABELA ASSOCIADA PA019 X(01) 123 123
            indice.NoMesSinalEvolucao = line.Substring(122, 1).Trim();

            //    23 -EVOMES -EVOLUÇÃO PERCENTUAL DO ÍNDICE NO MÊS N(03)V99 124 128
            indice.NoMesEvolucaoPercentual = Convert.ToDecimal(line.Substring(123, 5).Trim()) / 100;

            //    24 -SI1MES -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS VER TABELA ASSOCIADA PA019 X(01) 129 129
            indice.EmUmMesSinalEvolucao = line.Substring(128, 1).Trim();

            //    25 -EV1MES -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM MÊS N(03)V99 130 134
            indice.EmUmMesEvolucaoPercentual = Convert.ToDecimal(line.Substring(129, 5).Trim()) / 100;

            //    26 -SINANO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO VER TABELA ASSOCIADA PA019 X(01) 135 135
            indice.NoAnoSinalEvolucao = line.Substring(134, 1).Trim();

            //    27 -EVOANO -EVOLUÇÃO PERCENTUAL DO ÍNDICE NO ANO N(03)V99 136 140
            indice.NoAnoEvolucaoPercentual = Convert.ToDecimal(line.Substring(135, 5).Trim()) / 100;

            //    28 -SI1ANO -SINAL DA EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO VER TABELA ASSOCIADA PA019 X(01) 141 141
            indice.EmUmAnoSinalEvolucao = line.Substring(140, 1).Trim();

            //    29 -EV1ANO -EVOLUÇÃO PERCENTUAL DO ÍNDICE EM UM ANO N(03)V99 142 146
            indice.EmUmAnoEvolucaoPercentual = Convert.ToDecimal(line.Substring(141, 5).Trim()) / 100;

            //    30 -ACOALT -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM ALTA N(03) 147 149
            indice.AcoesNoIndiceEmAlta = Convert.ToInt32(line.Substring(146, 3).Trim());

            //    31 -ACOBAI -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE TIVERAM BAIXA N(03) 150 152
            indice.AcoesNoIndiceEmBaixa = Convert.ToInt32(line.Substring(149, 3).Trim());

            //    32 -ACOEST -NÚMERO DE AÇÕES PERTENCENTES AO ÍNDICE QUE PERMANECERAM ESTÁVEIS N(03) 153 155
            indice.AcoesNoIndiceEstaveis = Convert.ToInt32(line.Substring(152, 3).Trim());

            //    33 -ACOTOT -NÚMERO TOTAL DE AÇÕES PERTENCENTES AO ÍNDICE N(03) 156 158
            indice.AcoesNoIndiceTotal = Convert.ToInt32(line.Substring(155, 3).Trim());

            //    34 -NNGIND -NÚMERO DE NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(06) 159 164
            indice.NegociosComAcoesDoIndice = Convert.ToInt32(line.Substring(158, 6).Trim());

            //    35 -QTDIND -QUANTIDADE DE TÍTULOS NEGOCIADOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15) 165 179
            indice.QtdTitulosNegociadosIndice = Convert.ToInt64(line.Substring(164, 15).Trim());

            //    36 -VOLIND -VOLUME DOS NEGÓCIOS COM AÇÕES PERTENCENTES AO ÍNDICE N(15)V99 180 196
            indice.VolumeNegociosDoIndice = Convert.ToDecimal(line.Substring(179, 17).Trim()) / 100;

            //    37 -IDCMDP -ÍNDICE DA MÉDIA PONDERADA N(06) 197 202
            indice.IndiceMediaPonderada = Convert.ToDecimal(line.Substring(196, 6).Trim());

            //    38 -RESERVA EM BRANCO X(148) 203 350 
            indice.Reserva = line.Substring(202, 148).Trim();

            return indice;
        }

        private State.BdiFile.CotacaoState ReadCotacao(string line)
        {
            State.BdiFile.CotacaoState cotacao = new State.BdiFile.CotacaoState();

            cotacao.TipoDeRegistro = 2;

            //    02 -CODBDI -CÓDIGO BDI UTILIZADO PARA CLASSIFICAR OS PAPÉIS NA EMISSÃO DO BOLETIM DIÁRIO DE INFORMAÇÕES VER TABELA ASSOCIADA NE001 X(02) 03 04
            cotacao.CodBdi = line.Substring(2, 3).Trim();
            //    03 -DESBDI -DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
            cotacao.DescricaoBDI = line.Substring(4, 30).Trim();
            //    04 -NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 35 46
            cotacao.NomeResumido = line.Substring(34, 12).Trim();
            //    05 -ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 47 56
            cotacao.EspecificacaoPapel = line.Substring(46, 10).Trim();
            //    06 -INDCAR -INDICADOR DE CARACTERÍSTICA DO PAPEL VER TABELA ASSOCIADA PA020 X(01) 57 57
            cotacao.IndicadorCaracteristica = line.Substring(56, 1).Trim();
            //    07 -CODNEG -CÓDIGO DE NEGOCIAÇÃO X(12) 58 69
            cotacao.Ticker = line.Substring(57, 12).Trim();
            //    08 -TPMERC -TIPO DE MERCADO CÓD. DO MERCADO EM QUE O PAPEL ESTÁ CADASTRADO VER TABELA ASSOCIADA PA003 N(03) 70 72
            cotacao.TipoDeMercado = Convert.ToInt32(line.Substring(69, 3).Trim());
            //    09 – NOMERC – DESCRIÇÃO DO TIPO DE MERCADO X(15) 73 87
            cotacao.DescTipoMercado = line.Substring(72, 14).Trim();
            //    10 – PRAZOT – PRAZO EM DIAS DO MERCADO A TERMO X(03) 88 90
            cotacao.Prazo = Convert.ToInt32(line.Substring(87, 3).Trim());
            //    11 – PREABE – PREÇO DE ABERTURA DO PAPEL (PREÇO DO PRIMEIRO NEGÓCIO EFETUADO COM O PAPEL-MERCADO) N(09)V99 91 101
            cotacao.PrecoAbertura = Convert.ToDecimal(line.Substring(90, 11).Trim()) / 100;
            //    12 – PREMAX – PREÇO MÁXIMO DO PAPELMERCADO NO PREGÃO N(09)V99 102 112
            cotacao.PrecoMaximo = Convert.ToDecimal(line.Substring(101, 11).Trim()) / 100;
            //    13 – PREMIN – PREÇO MÍNIMO DO PAPELMERCADO NO PREGÃO N(09)V99 113 123
            cotacao.PrecoMinimo = Convert.ToDecimal(line.Substring(112, 11).Trim()) / 100;
            //    14 – PREMED – PREÇO MÉDIO DO PAPELMERCADO NO PREGÃO N(09)V99 124 134
            cotacao.PrecoMedio = Convert.ToDecimal(line.Substring(123, 11).Trim()) / 100;
            //    15 -PREULT -PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM O PAPEL-MERCADO N(09)V99 135 145
            cotacao.PrecoFechamento = Convert.ToDecimal(line.Substring(134, 11).Trim()) / 100;
            //    16 -SINOSC -SINAL DA OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR VER TABELA ASSOCIADA PA019 X(01) 146 146
            cotacao.SinalOscilacao = line.Substring(145, 1).Trim();

            //    17 -OSCILA -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 147 151
            cotacao.Oscilacao = Convert.ToDecimal(line.Substring(146, 5).Trim()) / 100;

            //    18 -PREOFC -PREÇO DA MELHOR OFERTA DE COMPRA DO PAPEL-MERCADO N(09)V99 152 162
            cotacao.PrecoMelhorCompra = Convert.ToDecimal(line.Substring(151, 11).Trim()) / 100;

            //    19 -PREOFV -PREÇO DA MELHOR OFERTA DE VENDA DO PAPEL-MERCADO N(09)V99 163 173
            cotacao.PrecoMelhorVenda = Convert.ToDecimal(line.Substring(162, 11).Trim()) / 100;

            //    20 -TOTNEG -NEG. NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL-MERCADO NO PREGÃO CORRENTE N(05) 174 178
            cotacao.TotalNegocios = Convert.ToInt32(line.Substring(173, 5).Trim());

            //    21 -QUATOT -QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPELMERCADO N(15) 179 193
            cotacao.Quantidade = Convert.ToInt64(line.Substring(178, 15).Trim());

            //    22 -VOLTOT -VOLUME TOTAL DE TÍTULOS NEGOCIADOS NESTE PAPEL-MERCADO N(15)V99 194 210
            cotacao.Volume = Convert.ToDecimal(line.Substring(193, 17).Trim()) / 100;

            //    23 -PREEXE -PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DO CONTRATO PARA O MERCADO DE TERMO SECUNDÁRIO N(09)V99 211 221
            cotacao.PrecoExercicio = Convert.ToDecimal(line.Substring(210, 11).Trim()) / 100;

            //    24 -DATVEN -DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO AAAAMMDD N(08) 222 229 
            if (line.Substring(221, 08).Trim() == "00000000")
            { cotacao.DataVencimento = new DateTime(9999, 12, 31); }
            else
            { cotacao.DataVencimento = DateTime.ParseExact(line.Substring(221, 08).Trim(), "yyyyMMdd", fileCultureinfo); }

            //    25 -INDOPC -INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(01) 230 230
            cotacao.IndicadorCorrecaoOpcao = Convert.ToInt32(line.Substring(229, 1).Trim());

            //    26 -NOMIND -DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 231 245
            cotacao.DescIndicadorCorrecao = line.Substring(230, 15).Trim();

            //    27 -FATCOT -FATOR DE COTAÇÃO DO PAPEL VER TABELA ASSOCIADA EM021 N(07) 246 252
            cotacao.FatorCotacao = Convert.ToInt32(line.Substring(245, 7).Trim());

            //    28 -PTOEXE -PREÇO DE EXERCÍCIO EM PONTOS PARA OPÇÕES REFERENCIADAS EM DÓLAR OU VALOR DE CONTRATO EM PONTOS PARA TERMO SECUNDÁRIO PARA OS REFERENCIADOS EM DOLAR, CADA PONTO EQUIVALE AO VALOR, NA MOEDA CORRENTE, DE UM CENTÉSIMO DA TAXA MÉDIA DO DÓLAR COMERCIAL. INTERBANCÁRIO DE FECHAMENTO DO DIA ANTERIOR, OU SEJA, 1 PONTO = 1/100 US$ N(07)V(06) 253 265
            cotacao.PrecoExercicioPontos = Convert.ToDecimal(line.Substring(252, 13).Trim()) / 1000000;

            //    29 -CODISI -CÓDIGO DO PAPEL NO SISTEMA ISIN CÓDIGO DO PAPEL NO SISTEMA ISIN X(12) 266 277
            cotacao.CodISIN = line.Substring(265, 12).Trim();

            //    30 -DISMES -NÚMERO DE DISTRIBUIÇÃO DO PAPEL NÚMERO DE SEQüÊNCIA DO PAPEL CORRESPONDENTE AO ESTADO DE DIREITO VIGENTE N(03) 278 280
            cotacao.DistribuicaoMES = Convert.ToInt32(line.Substring(277, 3).Trim());

            //    31 -ESTILO – ESTILO ADOTADO PARA O EXERCÍCIO DE OPÇÕES DE COMPRA/VENDA VER TABELA ASSOCIADA PA015 N(01) 281 281 32 -NOMEST -DESCRIÇÃO DO ESTILO X(15) 282 296
            cotacao.EstiloOpc = line.Substring(281, 15).Trim();

            //    33 -ICOATV -INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE VER TABELA ASSOCIADA PA004 N(03) 297 299
            cotacao.IndicadorCorrecaoOpcao2 = Convert.ToInt32(line.Substring(296, 3).Trim());

            //    34 – OSCPRE -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 300 306
            cotacao.Oscilacao2 = Convert.ToDecimal(line.Substring(299, 7).Trim()) / 100;

            //    35 -RESERVA EM BRANCO X(44) 307 350 
            cotacao.Reserva = line.Substring(306, 44).Trim();

            return cotacao;
        }

        private State.BdiFile.ResumoBdiState ReadResumoPorCodBdi(string line)
        {
            State.BdiFile.ResumoBdiState resumoPorCodBdi = new State.BdiFile.ResumoBdiState();

            //01 - TIPREG - TIPO DE REGISTRO FIXO "03" N(02) 01 02
            resumoPorCodBdi.TipoDeRegistro = 3;

            //02 - CODBDI - CÓDIGO BDI VER TABELA ASSOCIADA NE001 N(02) 03 04
            resumoPorCodBdi.CodBdi = Convert.ToInt32(line.Substring(2, 2).Trim());

            //03 - DESBDI - DESCRIÇÃO DO CÓDIGO DE BDI X(30) 05 34
            resumoPorCodBdi.DescricaoBdi = line.Substring(4, 30).Trim();

            //04 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(05) 35 39
            resumoPorCodBdi.TotalNegocios = Convert.ToInt32(line.Substring(34, 5).Trim());

            //05 - QUATOT - QUANTIDADE TOTAL DE TÍTULOS NEGOCIADOS N(15) 40 54
            resumoPorCodBdi.Quantidade = Convert.ToInt64(line.Substring(39, 15).Trim());

            //06 - VOLTOT - VOLUME GERAL TRANSACIONADO NO PREGÃO CORRENTE N(15)V99 55 71
            resumoPorCodBdi.Volume = Convert.ToDecimal(line.Substring(54, 17).Trim()) / 100;

            //07 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS NO PREGÃO CORRENTE N(09) 72 80
            resumoPorCodBdi.TotalNegocios2 = Convert.ToInt32(line.Substring(71, 9).Trim());

            //08 - RESERVA EM BRANCO X(270) 81 350
            resumoPorCodBdi.Reserva = line.Substring(4, 30).Trim();

            return resumoPorCodBdi;
        }

        private State.BdiFile.MaiorOscilacaoVistaState ReadMaiorOscilacaoAvista(string line)
        {
            State.BdiFile.MaiorOscilacaoVistaState maiorOscilaAvista = new State.BdiFile.MaiorOscilacaoVistaState();

            //01 -TIPREG -TIPO DE REGISTRO FIXO "04" N(02) 01 02
            maiorOscilaAvista.TipoDeRegistro = 4;

            //02 -INDOSC -INDICA SE É OSCILAÇÃO POSITIVA OU NEGATIVA "A" = ALTA (POSITIVA) "B" = BAIXA (NEGATIVA) X(01) 03 03 
            maiorOscilaAvista.IndicacaoOscilacao = line.Substring(2, 1).Trim();

            //03 -NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 04 15
            maiorOscilaAvista.NomeResumido = line.Substring(3, 12).Trim();

            //04 -ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 16 25
            maiorOscilaAvista.EspecificacaoPapel = line.Substring(15, 10).Trim();

            //05 -PREULT -PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM PAPEL-MERCADO DURANTE O PREGÃO CORRENTE N(09)V99 26 36
            maiorOscilaAvista.PrecoFechamento = Convert.ToDecimal(line.Substring(25, 11).Trim()) / 100;

            //06 -TOTNEG -NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL-MERCADO NO PREGÃO CORRENTE N(05) 37 41
            maiorOscilaAvista.TotalNegocios = Convert.ToInt32(line.Substring(36, 5).Trim());

            //07 -OSCPRE -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 42 46
            maiorOscilaAvista.Oscilacao = Convert.ToDecimal(line.Substring(41, 5).Trim()) / 100;

            //08 – CODMEG – CÓDIGO DE NEGOCIAÇÃO X(12) 47 58
            maiorOscilaAvista.Ticker = line.Substring(46, 12).Trim();

            //09 – OSCILA -OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 59 65
            maiorOscilaAvista.Oscilacao2 = Convert.ToDecimal(line.Substring(58, 7).Trim()) / 100;

            //10 -RESERVA EM BRANCO X(285) 66 350
            maiorOscilaAvista.Reserva = line.Substring(65, 284).Trim();

            return maiorOscilaAvista;
        }

        private State.BdiFile.MaiorOscilacaoIbovState ReadMaiorOscilacaoIbov(string line)
        {
            State.BdiFile.MaiorOscilacaoIbovState maiorOscilaIbov = new State.BdiFile.MaiorOscilacaoIbovState();

            //01 - TIPREG - TIPO DE REGISTRO FIXO "05" N(02) 01 02
            maiorOscilaIbov.TipoDeRegistro = 5;

            //02 - INDOSC - INDICA SE É OSCILAÇÃO POSITIVA OU NEGATIVA "A" = ALTA (POSITIVA) "B" = BAIXA (NEGATIVA) X(01) 03 03
            maiorOscilaIbov.IndicacaoOscilacao = line.Substring(2, 1).Trim();

            //03 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 04 15
            maiorOscilaIbov.NomeResumido = line.Substring(3, 12).Trim();

            //04 - ESPECI - ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 16 25
            maiorOscilaIbov.EspecificacaoPapel = line.Substring(15, 10).Trim();

            //05 - PREULT - PREÇO DO ÚLTIMO NEGÓCIO EFETUADO COM PAPEL-MERCADO DURANTE O PREGÃO CORRENTE N(09)V99 26 36
            maiorOscilaIbov.PrecoFechamento = Convert.ToDecimal(line.Substring(25, 11).Trim()) / 100;

            //06 - TOTNEG - NÚMERO DE NEGÓCIOS EFETUADOS COM O PAPEL-MERCADO NO PREGÃO CORRENTE N(05) 37 41 
            maiorOscilaIbov.TotalNegocios = Convert.ToInt32(line.Substring(36, 5).Trim());

            //07 - OSCPRE - OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(03)V99 42 46
            maiorOscilaIbov.Oscilacao = Convert.ToDecimal(line.Substring(41, 5).Trim()) / 100;

            //08 - CODMEG – CÓDIGO DE NEGOCIAÇÃO X(12) 47 58
            maiorOscilaIbov.Ticker = line.Substring(46, 12).Trim();

            //09 - OSCILA - OSCILAÇÃO DO PREÇO DO PAPEL-MERCADO EM RELAÇÃO AO PREGÃO ANTERIOR N(05)V99 59 65 
            maiorOscilaIbov.Oscilacao2 = Convert.ToDecimal(line.Substring(58, 7).Trim()) / 100;

            //10 - RESERVA EM BRANCO X(285) 66 350
            maiorOscilaIbov.Reserva = line.Substring(65, 284).Trim();

            return maiorOscilaIbov;
        }

        private State.BdiFile.MaisNegociadasVistaState ReadMaisNegociadasAVista(string line)
        {
            State.BdiFile.MaisNegociadasVistaState maisNegocVista = new State.BdiFile.MaisNegociadasVistaState();

            //01 - TIPREG -TIPO DE REGISTRO FIXO "06" N(02) 01 02
            maisNegocVista.TipoDeRegistro = 6;

            //02 - NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 03 14
            maisNegocVista.NomeResumido = line.Substring(2, 12).Trim();

            //03 - ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 15 24
            maisNegocVista.EspecificacaoPapel = line.Substring(14, 10).Trim();

            //04 - QUATOT -QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 25 39
            maisNegocVista.Quantidade = Convert.ToInt64(line.Substring(24, 15).Trim());

            //05 - VOLTOT -VOLUME GERAL NO PREGÃO DESTE PAPEL -MERCADO N(15)V99 40 56
            maisNegocVista.Volume = Convert.ToDecimal(line.Substring(39, 17).Trim());

            //06 – CODMEG – CÓDIGO DE NEGOCIAÇÃO X(12) 57 68
            maisNegocVista.Ticker = line.Substring(56, 12).Trim();

            //07 - RESERVA EM BRANCO X(282) 69 350
            maisNegocVista.Reserva = line.Substring(68, 282).Trim();

            return maisNegocVista;
        }

        private State.BdiFile.MaisNegociadasState ReadMaisNegociadas(string line)
        {
            State.BdiFile.MaisNegociadasState maisNegoc = new State.BdiFile.MaisNegociadasState();

            //01 - TIPREG -TIPO DE REGISTRO FIXO "07" N(02) 01 02
            maisNegoc.TipoDeRegistro = 7;

            //02 - TPMERC -TIPO DE MERCADO N(03) 03 05
            maisNegoc.tipoMercado = line.Substring(2, 3).Trim();

            //03 - NOMERC – DESCRIÇÃO DO TIPO DE MERCADO X(20) 06 25
            maisNegoc.DescTipoMercado = line.Substring(5, 20).Trim();

            //04 - NOMRES -NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 26 37
            maisNegoc.NomeResumido = line.Substring(25, 12).Trim();

            //05 - ESPECI -ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 38 47
            maisNegoc.EspecificacaoPapel = line.Substring(37, 10).Trim();

            //06 – INDOPC – INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE N(02) 48 49
            maisNegoc.IndicadorCorrecaoOpcao = Convert.ToInt32(line.Substring(47, 2).Trim());

            //07 – NOMIND – DESCRIÇÃO DO INDICADOR DE CORREÇÃO DE PREÇOS DE EXERCÍCIOS OU VALORES DE CONTRATO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO, RESPECTIVAMENTE X(15) 50 64
            maisNegoc.DescIndicadorCorrecao = line.Substring(49, 15).Trim();

            //08 – PREEXE – PREÇO DE EXERCÍCIO PARA O MERCADO DE OPÇÕES OU VALOR DE CONTRATO PARA OS MERCADOS DE TERMO SECUNDÁRIO N(09)V99 65 75
            maisNegoc.PrecoExercicio = Convert.ToDecimal(line.Substring(65, 11).Trim()) / 100;

            //09 – DATVEN – DATA DO VENCIMENTO PARA OS MERCADOS DE OPÇÕES, TERMO SECUNDÁRIO OU FUTURO FORMATO = "AAAAMMDD" N(08) 76 83
            if (line.Substring(75, 08).Trim() == "00000000")
            { maisNegoc.DataVencimento = new DateTime(9999, 12, 31); }
            else
            { maisNegoc.DataVencimento = DateTime.ParseExact(line.Substring(75, 08).Trim(), "yyyyMMdd", fileCultureinfo); }

            //10 – PRAZOT – PRAZO EM DIAS DO MERCADO A TERMO N(03) 84 86
            maisNegoc.Prazo = Convert.ToInt32(line.Substring(85, 3).Trim());

            //11 - QUATOT -QUANTIDADE DE TÍTULOS NEGOCIADOS NO PREGÃO N(15) 87 101
            maisNegoc.Quantidade = Convert.ToInt64(line.Substring(86, 15).Trim());

            //12 - VOLTOT -VOLUME GERAL NO PREGÃO DESTE PAPEL MERCADO N(15)V99 102 118 
            maisNegoc.Volume = Convert.ToDecimal(line.Substring(101, 17).Trim()) / 100;

            //13 - PARTIC – PARTICIPAÇÃO DO VOLUME DO PAPEL NO VOLUME TOTAL DO MERCADO N(03)V99 119 123
            maisNegoc.ParticiapacaoNoVolume = Convert.ToDecimal(line.Substring(118, 5).Trim()) / 100;

            //14 – CODMEG -CÓDIGO DE NEGOCIACAO X(12) 124 135
            maisNegoc.Ticker = line.Substring(123, 12).Trim();

            //15 - ICOATV -INDICADOR DE CORREÇÃO DE PREÇOS DE ATIVOS VER TABELA ASSOCIADA PA004 N(03) 136 138
            maisNegoc.IndicadorCorrecaoAtivo = line.Substring(135, 3).Trim();

            //16 - RESERVA EM BRANCO X(212) 139 350
            maisNegoc.Reserva = line.Substring(138, 212).Trim();

            return maisNegoc;
        }

        private State.BdiFile.ResumoDiarioIopvState ReadIopv(string line)
        {
            State.BdiFile.ResumoDiarioIopvState iopv = new State.BdiFile.ResumoDiarioIopvState();

            //01 -TIPREG -TIPO DE REGISTRO FIXO "08" N(02) 01 02
            iopv.TipoDeRegistro = 8;

            //02 -IDENTI -IDENTIFICAÇÃO DO IOPV N(02) 03 04
            iopv.Identificacao = line.Substring(2, 2).Trim();

            //03 -SIGLA -SIGLA DO IOPV X(04) 05 08
            iopv.Sigla = line.Substring(4, 4).Trim();

            //04 -NOMRES -NOME RESUMIDO DO IOPV X(12) 09 20
            iopv.NomeResumido = line.Substring(8, 12).Trim();

            //05 -NOMIND -NOME DO IOPV X(30) 21 50
            iopv.NomeIopv = line.Substring(20, 30).Trim();

            //06 -IDCABE – IOPV DE ABERTURA DO PREGÃO N(05)V99 51 57
            iopv.IopvAbertura = Convert.ToDecimal(line.Substring(50, 7).Trim()) / 100;

            //07 -IDCMIN -IOPV MÍNIMO DO PREGÃO N(05)V99 58 64
            iopv.IopvMinimo = Convert.ToDecimal(line.Substring(57, 7).Trim()) / 100;

            //08 -IDCMAX – IOPV MÁXIMO DO PREGÃO N(05)V99 65 71
            iopv.IopvMaximo = Convert.ToDecimal(line.Substring(64, 7).Trim()) / 100;

            //09 -IDCMED -IOPV DA MEDIA ARITMETICA DOS IOPVs DO PREGAO N(05)V99 72 78
            iopv.IopvMedia = Convert.ToDecimal(line.Substring(71, 7).Trim()) / 100;

            //10 -IDCFEC – IOPV DE FECHAMENTO N(05)V99 79 85
            iopv.IopvFechamento = Convert.ToDecimal(line.Substring(78, 7).Trim()) / 100;

            //11 -SINEVO -SINAL DA EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 86 86
            iopv.SinalEvoluvao = line.Substring(85, 1).Trim();

            //12 -EVOIND -EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO N(03)V99 87 91
            iopv.Evolucao = Convert.ToDecimal(line.Substring(86, 5).Trim()) / 100;

            //13 -RESERVA EM BRANCO X(259) 92 350
            iopv.Reserva = line.Substring(91, 259).Trim();

            return iopv;
        }

        private State.BdiFile.BdrState ReadBdr(string line)
        {
            State.BdiFile.BdrState bdr = new State.BdiFile.BdrState();

            bdr.TipoDeRegistro = 9;

            //02 - CODNEG – CÓDIGO DE NEGOCIAÇÃO N(15) 03 14
            bdr.Ticker = line.Substring(2, 15).Trim();

            //03 - NOMRES - NOME RESUMIDO DA EMPRESA EMISSORA DO PAPEL X(12) 15 26
            bdr.NomeResumido = line.Substring(2, 15).Trim();

            //04 –ESPECI – ESPECIFICAÇÃO DO PAPEL PARA PAPÉIS PERTENCENTES AO NOVO MERCADO, NAS POSIÇÕES 9 E 10 ESTÁ INDICADO: N1, N2 OU NM. X(10) 27 36
            bdr.EspecificacaoPapel = line.Substring(2, 15).Trim();

            //05 –VALREF – VALOR DE REFERÊNCIA N(09)V99 37 47
            bdr.PrecoReferencia = Convert.ToDecimal(line.Substring(36, 11).Trim()) / 100;

            //06 -RESERVA EM BRANCO X(303) 48 350
            bdr.Reserva = line.Substring(47, 303).Trim();

            return bdr;
        }

        private State.BdiFile.TrailerState ReadTrailer(string line)
        {
            State.BdiFile.TrailerState trailer = new State.BdiFile.TrailerState();

            trailer.TipoDeRegistro = 99;

            //02 -NOME DO ARQUIVO VER DEFINIÇÃO ABAIXO X(08) 03 10 
            trailer.NomeDoArquivo = line.Substring(2, 8).Trim();


            //03 -CODIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
            trailer.CodigoOrigem = line.Substring(10, 8).Trim();

            //04 -CODIGO DO DESTINO FIXO "9999" N(04) 19 22
            trailer.CodigoDestino = line.Substring(18, 4).Trim();

            //05 -DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
            trailer.DataDoArquivo = DateTime.ParseExact(line.Substring(22, 8), "yyyyMMdd", fileCultureinfo);

            //06 -TOTAL DE REGISTROS INCLUIR TAMBÉM OS REGISTROS HEADER E TRAILER N(09) 31 39 
            trailer.TotalRegistros = Convert.ToInt32(line.Substring(30, 9));

            //07 -RESERVA EM BRANCO X(311) 40 350
            trailer.Reserva = line.Substring(39, 311).Trim();

            return trailer;
        }

        #endregion

    }
}
