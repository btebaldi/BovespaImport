using System;
using System.Text;
using System.Collections.Generic;

using System.Data;

namespace BovespaData.DataClass
{
    public class HistoricoDC
    {

        private System.Globalization.CultureInfo myCultureinfo = System.Globalization.CultureInfo.InvariantCulture;

        private string mstrConnectString;
        public string ConnectString
        {
            get { return mstrConnectString; }
            set { mstrConnectString = value; }
        }

        //private string mstrFilePath;
        //public string FlatFilePath
        //{
        //    get { return mstrFilePath; }
        //    set { mstrFilePath = value; }
        //}


        #region "Data Retrieval Methods"

        public Entidade.Historico.HistoricoFileState LoadFromFlatFile(string path)
        {
            Entidade.Historico.HistoricoFileState flatFile = new Entidade.Historico.HistoricoFileState();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {

                string tipoRegistro = line.Substring(0, 2);

                if (tipoRegistro == "00")
                {
                    flatFile.Header = ReadHeader(line);
                }
                else if (tipoRegistro == "01")
                {
                    AddRegistroToTable(line, flatFile.Cotacoes);
                }
                else if (tipoRegistro == "99")
                {
                    flatFile.Trailer = ReadTrailer(line);
                }
                else
                {
                    throw new Exception("Tipo de resgistro invalido. Programa nao consegue interpretar a linha do arquivo.");
                }
            }

            file.Close();

            ValidaImportacao(flatFile);

            return flatFile;

        }

        private BovespaData.DataClass.Entidade.Historico.CotacaoState ReadRegistro(string line)
        {
            throw new NotImplementedException();

            /// Tipo de registro fixo "01" N(02) 01 02
            BovespaData.DataClass.Entidade.Historico.CotacaoState registro = new BovespaData.DataClass.Entidade.Historico.CotacaoState();

            registro.TipoRegistro = 1;
            registro.DataPregao = DateTime.ParseExact(line.Substring(2, 8), "yyyyMMdd", myCultureinfo);
            registro.CodigoBDI = Convert.ToInt32(line.Substring(10, 2));
            registro.Ticker = line.Substring(12, 12).Trim();
            registro.TipoMercado = Convert.ToInt32(line.Substring(24, 3));
            registro.NomeResumido = line.Substring(27, 12).Trim();
            registro.EspecificacaoPapel = line.Substring(39, 10).Trim();
            registro.Prazo = line.Substring(49, 3).Trim();
            registro.Moeda = line.Substring(52, 4).Trim();
            registro.PrecoAbertura = Convert.ToDecimal(line.Substring(56, 11)) / 100;
            registro.PrecoMaximo = Convert.ToDecimal(line.Substring(69, 11)) / 100;
            registro.PrecoMinimo = Convert.ToDecimal(line.Substring(82, 11)) / 100;
            registro.PrecoMedio = Convert.ToDecimal(line.Substring(95, 11)) / 100;
            registro.PrecoFechamento = Convert.ToDecimal(line.Substring(108, 11)) / 100;
            registro.PrecoMelhorCompra = Convert.ToDecimal(line.Substring(121, 11)) / 100;
            registro.PrecoMelhorVenda = Convert.ToDecimal(line.Substring(134, 11)) / 100;
            registro.TotalNegocios = Convert.ToInt32(line.Substring(147, 5));
            registro.Quantidade = Convert.ToInt64(line.Substring(152, 18));
            registro.Volume = Convert.ToDecimal(line.Substring(170, 16)) / 100;
            registro.PrecoExercicio = Convert.ToDecimal(line.Substring(188, 11)) / 100;
            registro.IndicadorCorrecaoOpcao = Convert.ToInt32(line.Substring(201, 1));
            registro.DataVencimento = DateTime.ParseExact(line.Substring(202, 8), "yyyyMMdd", myCultureinfo);
            registro.FatorCotacao = Convert.ToInt32(line.Substring(210, 7));
            registro.PrecoExercicioPontos = Convert.ToInt32(line.Substring(217, 06));
            registro.CodISIN = line.Substring(230, 12).Trim();
            registro.DistribuicaoMES = Convert.ToInt32(line.Substring(242, 3));

            return registro;
        }

        private BovespaData.DataClass.Entidade.Historico.HeaderState ReadHeader(string line)
        {
            /// TIPO DE REGISTRO FIXO "00" N(02) 01 02

            BovespaData.DataClass.Entidade.Historico.HeaderState header = new BovespaData.DataClass.Entidade.Historico.HeaderState();

            header.TipoDeRegistro = 0;
            header.NomeDoArquivo = line.Substring(2, 13).Trim();
            header.CodigoOrigem = line.Substring(15, 8).Trim();
            header.DataDoArquivo = DateTime.ParseExact(line.Substring(23, 8), "yyyyMMdd", myCultureinfo);
            header.Reserva = line.Substring(31, 214).Trim();

            return header;
        }

        private BovespaData.DataClass.Entidade.Historico.TrailerState ReadTrailer(string line)
        {
            BovespaData.DataClass.Entidade.Historico.TrailerState trailer = new BovespaData.DataClass.Entidade.Historico.TrailerState();

            trailer.TipoDeRegistro = 99;
            trailer.NomeDoArquivo = line.Substring(2, 13).Trim();
            trailer.CodigoOrigem = line.Substring(15, 8).Trim();
            trailer.DataDoArquivo = DateTime.ParseExact(line.Substring(23, 8), "yyyyMMdd", myCultureinfo);
            trailer.TotalRegistros = Convert.ToInt32(line.Substring(31, 11));
            trailer.Reserva = line.Substring(42, 203).Trim();

            return trailer;
        }

        private void AddRegistroToTable(string line, DataTable table)
        {
            DataRow row;

            row = table.NewRow();

            BovespaData.DataClass.Entidade.Historico.CotacaoState reg = new BovespaData.DataClass.Entidade.Historico.CotacaoState();

            row[reg.Schema.TipoRegistro] = 1;
            row[reg.Schema.DataPregao] = DateTime.ParseExact(line.Substring(2, 8), "yyyyMMdd", myCultureinfo);
            row[reg.Schema.CodigoBDI] = Convert.ToInt32(line.Substring(10, 2));
            row[reg.Schema.Ticker] = line.Substring(12, 12).Trim();
            row[reg.Schema.TipoMercado] = Convert.ToInt32(line.Substring(24, 3));
            row[reg.Schema.NomeResumido] = line.Substring(27, 12).Trim();
            row[reg.Schema.EspecificacaoPapel] = line.Substring(39, 10).Trim();
            row[reg.Schema.Prazo] = line.Substring(49, 3).Trim();
            row[reg.Schema.Moeda] = line.Substring(52, 4).Trim();
            row[reg.Schema.PrecoAbertura] = Convert.ToDecimal(line.Substring(56, 13)) / 100;
            row[reg.Schema.PrecoMaximo] = Convert.ToDecimal(line.Substring(69, 13)) / 100;
            row[reg.Schema.PrecoMinimo] = Convert.ToDecimal(line.Substring(82, 13)) / 100;
            row[reg.Schema.PrecoMedio] = Convert.ToDecimal(line.Substring(95, 13)) / 100;
            row[reg.Schema.PrecoFechamento] = Convert.ToDecimal(line.Substring(108, 13)) / 100;
            row[reg.Schema.PrecoMelhorCompra] = Convert.ToDecimal(line.Substring(121, 13)) / 100;
            row[reg.Schema.PrecoMelhorVenda] = Convert.ToDecimal(line.Substring(134, 13)) / 100;
            row[reg.Schema.TotalNegocios] = Convert.ToInt32(line.Substring(147, 5));
            row[reg.Schema.Quantidade] = Convert.ToInt64(line.Substring(152, 18));
            row[reg.Schema.Volume] = Convert.ToDecimal(line.Substring(170, 18)) / 100;
            row[reg.Schema.PrecoExercicio] = Convert.ToDecimal(line.Substring(188, 13)) / 100;
            row[reg.Schema.IndicadorCorrecaoOpcao] = Convert.ToInt32(line.Substring(201, 1));
            row[reg.Schema.DataVencimento] = DateTime.ParseExact(line.Substring(202, 8), "yyyyMMdd", myCultureinfo);
            row[reg.Schema.FatorCotacao] = Convert.ToInt32(line.Substring(210, 7));
            row[reg.Schema.PrecoExercicioPontos] = Convert.ToDecimal(line.Substring(217, 13));
            row[reg.Schema.ISIN] = line.Substring(230, 12).Trim();
            row[reg.Schema.DistribuicaoMES] = Convert.ToInt32(line.Substring(242, 3));


            // add it to the base for final addition to the DB
            table.Rows.Add(row);
        }

        private void ValidaImportacao(BovespaData.DataClass.Entidade.Historico.HistoricoFileState myFile)
        {
            // Soma mais dois registros pois Header e trailer contam.
            if (myFile.Cotacoes.Rows.Count + 2 != myFile.Trailer.TotalRegistros)
            {
                throw new Exception("Total de registros inconsistente com informacao");
            }
        }

        #endregion

        #region "Data Modification Methods"


        //public virtual void Validate(NotaState item)
        //{
        //}

        public void Save(BovespaData.DataClass.Entidade.Historico.HistoricoFileState file)
        {
            //DataLayerBulkInsert.SqlServerBulkInsert(mstrConnectString, file.Cotacoes);
        }

        //public int Save(NotaState nota)
        //{
        //    List<NotaState> lst = new List<NotaState>();
        //    lst.Add(nota);
        //    return Save(lst);
        //}

        /*
        private DataTable PopulateDataTable(List<Entidades.RegistroState> lstRegistro)
        {
            //DataTable table = new DataTable();

            //DataClass.Entidades.RegistroState entidadeRegistro = new Entidades.RegistroState();

            //table.TableName = entidadeRegistro.Schema.ObjectName;

            //table.Columns.Add(entidadeRegistro.Schema.TipoRegistro, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.DataPregao, typeof(DateTime));
            //table.Columns.Add(entidadeRegistro.Schema.CodigoBDI, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.Ticker, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.TipoMercado, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.NomeResumido, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.EspecificacaoPapel, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.Prazo, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.Moeda, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoAbertura, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoMaximo, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoMinimo, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoMedio, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoFechamento, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoMelhorCompra, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoMelhorVenda, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.TotalNegocios, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.Quantidade, typeof(long));
            //table.Columns.Add(entidadeRegistro.Schema.Volume, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoExercicio, typeof(decimal));
            //table.Columns.Add(entidadeRegistro.Schema.IndicadorCorrecaoOpcao, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.DataVencimento, typeof(DateTime));
            //table.Columns.Add(entidadeRegistro.Schema.FatorCotacao, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.PrecoExercicioPontos, typeof(int));
            //table.Columns.Add(entidadeRegistro.Schema.ISIN, typeof(String));
            //table.Columns.Add(entidadeRegistro.Schema.DistribuicaoMES, typeof(int));


            foreach (Entidades.RegistroState registro in lstRegistro)
            {

                DataRow row;

                row = table.NewRow();

                row[0] = registro.TipoRegistro;
                row[1] = registro.DataPregao;
                row[2] = registro.CodigoBDI;
                row[3] = registro.Ticker;
                row[4] = registro.TipoMercado;
                row[5] = registro.NomeResumido;
                row[6] = registro.EspecificacaoPapel;
                row[7] = registro.Prazo;
                row[8] = registro.Moeda;
                row[9] = registro.PrecoAbertura;
                row[10] = registro.PrecoMaximo;
                row[11] = registro.PrecoMinimo;
                row[12] = registro.PrecoMedio;
                row[13] = registro.PrecoFechamento;
                row[14] = registro.PrecoMelhorCompra;
                row[15] = registro.PrecoMelhorVenda;
                row[16] = registro.TotalNegocios;
                row[17] = registro.Quantidade;
                row[18] = registro.Volume;
                row[19] = registro.PrecoExercicio;
                row[20] = registro.IndicadorCorrecaoOpcao;
                row[21] = registro.DataVencimento;
                row[22] = registro.FatorCotacao;
                row[23] = registro.PrecoExercicioPontos;
                row[24] = registro.CodISIN;
                row[25] = registro.DistribuicaoMES;


                // add it to the base for final addition to the DB
                table.Rows.Add(row);
            }

            return table;
        }
         */


        //public virtual void Validate(Entidades.RegistroState registro)
        //{
        //    string strMsg = string.Empty;


        //    // ToDo: revisar validacoes
        //    if (registro.TipoRegistro != 1)
        //    { strMsg += "Registro nao valido. Registro deve ser 1. Porque? porque a bovespa quis!!!" + Environment.NewLine; }

        //    if (registro.DataPregao == null)
        //    { strMsg += "Data de pregao invalida." + Environment.NewLine; }

        //    if (registro.CodigoBDI == null)
        //    { strMsg += "Data de pregao invalida." + Environment.NewLine; }

        //    if (registro.Ticker.Trim() == string.Empty)
        //    { strMsg += "Ticker invalido." + Environment.NewLine; }

        //    if (registro.TipoMercado == null)
        //    { strMsg += "Tipo de mercado vazio." + Environment.NewLine; }

        //    if (registro.NomeResumido.Trim() == string.Empty)
        //    { strMsg += "Nome resumido esta vazio." + Environment.NewLine; }

        //    if (registro.EspecificacaoPapel.Trim() == string.Empty)
        //    { strMsg += "Especificacao do papal nao pode ser nula." + Environment.NewLine; }

        //    if (registro.Prazo.Trim() == string.Empty)
        //    { strMsg += "Prazo nulo." + Environment.NewLine; }

        //    if (registro.Moeda.Trim() == string.Empty)
        //    { strMsg += "Moeda vazia." + Environment.NewLine; }

        //    if (registro.PrecoAbertura == null)
        //    { strMsg += "Preco de Abertura vazio." + Environment.NewLine; }

        //    if (registro.PrecoMaximo == null)
        //    { strMsg += "Preco maximo vazio." + Environment.NewLine; }

        //    if (registro.PrecoMinimo == null)
        //    { strMsg += "Preco minimo vazio." + Environment.NewLine; }

        //    if (registro.PrecoMedio == null)
        //    { strMsg += "Preco medio vazio." + Environment.NewLine; }

        //    if (registro.PrecoFechamento == null)
        //    { strMsg += "Preco de fechamento vazio." + Environment.NewLine; }

        //    if (registro.PrecoMelhorCompra == null)
        //    { strMsg += "Preco da melhor oferta de compra vazio." + Environment.NewLine; }

        //    if (registro.PrecoMelhorVenda == null)
        //    { strMsg += "Preco da melhor oferta de venda vazio." + Environment.NewLine; }

        //    if (registro.TotalNegocios == null)
        //    { strMsg += "Total de negocios." + Environment.NewLine; }

        //    if (registro.Quantidade == null)
        //    { strMsg += "Quantidade total de titulos negociados vazio." + Environment.NewLine; }

        //    if (registro.Volume == null)
        //    { strMsg += "Volume negociado vazio." + Environment.NewLine; }

        //    if (registro.PrecoExercicio == null)
        //    { strMsg += "Preco de exercicio vazio." + Environment.NewLine; }

        //    if (registro.IndicadorCorrecaoOpcao == null)
        //    { strMsg += "Indicador de correcao de opcao vazio." + Environment.NewLine; }

        //    if (registro.DataVencimento == null)
        //    { strMsg += "Data de vencimento vazia." + Environment.NewLine; }

        //    if ((registro.FatorCotacao != 1) && (registro.FatorCotacao != 1000))
        //    { strMsg += "Fator de cotacao invalido." + Environment.NewLine; }

        //    if (registro.PrecoExercicioPontos == null)
        //    { strMsg += "Preco de exercicio em pontos vazio." + Environment.NewLine; }

        //    if (registro.CodISIN.Trim() != string.Empty)
        //    { strMsg += "Codigo ISIN vazio." + Environment.NewLine; }

        //    if (registro.DistribuicaoMES == null)
        //    { strMsg += "Numero de distribuicao do papel vazio." + Environment.NewLine; }


        //    if (strMsg != string.Empty)
        //    {
        //        throw new BovespaDataException(strMsg);
        //    }
        //}

        //public int Insert(Entidades.RegistroState registro)
        //{
        //    IDbCommand cmd;
        //    string strSQL;

        //    //Check Business Rules
        //    Validate(registro);

        //    // ToDo: Metodo de insercao da bovespa
        //    strSQL = "INSERT INTO " + registro.Schema.ObjectName + " ( ";
        //    //strSQL += "sProductName, dtIntroduced, cCost, cPrice, bDiscontinued) ";
        //    //strSQL += "VALUES(@sProductName, @dtIntroduced, @cCost, @cPrice, @bDiscontinued) ";

        //    cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        //    FillInParameters(registro, cmd);

        //    return DataLayer.ExecuteSQL(cmd, true);
        //}

        //public int Update(Entidades.RegistroState registro)
        //{
        //    // ToDo: Update

        //    //IDbCommand cmd;
        //    //string strSQL;

        //    //// Check Business Rules
        //    //Validate(prod);

        //    //strSQL = "UPDATE tblProducts ";
        //    //strSQL += "SET sProductName = @sProductName,";
        //    //strSQL += " dtIntroduced = @dtIntroduced, ";
        //    //strSQL += " cCost = @cCost, ";
        //    //strSQL += " cPrice = @cPrice, ";
        //    //strSQL += " bDiscontinued = @bDiscontinued ";
        //    //strSQL += " WHERE iProduct_id = @iProduct_id ";

        //    //cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        //    //FillInParameters(prod, cmd);

        //    //return DataLayer.ExecuteSQL(cmd, true);
        //    return 0;
        //}

        //public int Delete(Entidades.RegistroState registro)
        //{
        //    //ToDo: Delete
        //    //IDbCommand cmd;
        //    //string strSQL;

        //    //strSQL = "DELETE FROM tblProducts ";
        //    //strSQL += " WHERE iProduct_id = @iProduct_id ";

        //    //cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        //    //FillInParameters(prod, cmd);

        //    //return DataLayer.ExecuteSQL(cmd, true);
        //    return 0;
        //}

        //protected void FillInParameters(Entidades.RegistroState registro, IDbCommand cmd)
        //{
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TipoRegistro, DbType.String, registro.TipoRegistro));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DataPregao, DbType.String, registro.DataPregao));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.CodigoBDI, DbType.String, registro.CodigoBDI));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Ticker, DbType.String, registro.Ticker));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TipoMercado, DbType.String, registro.TipoMercado));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.NomeResumido, DbType.String, registro.NomeResumido));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.EspecificacaoPapel, DbType.String, registro.EspecificacaoPapel));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Prazo, DbType.String, registro.Prazo));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Moeda, DbType.String, registro.Moeda));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoAbertura, DbType.String, registro.PrecoAbertura));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMaximo, DbType.String, registro.PrecoMaximo));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMinimo, DbType.String, registro.PrecoMinimo));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMedio, DbType.String, registro.PrecoMedio));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoFechamento, DbType.String, registro.PrecoFechamento));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMelhorCompra, DbType.String, registro.PrecoMelhorCompra));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMelhorVenda, DbType.String, registro.PrecoMelhorVenda));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TotalNegocios, DbType.String, registro.TotalNegocios));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Quantidade, DbType.String, registro.Quantidade));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Volume, DbType.String, registro.Volume));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoExercicio, DbType.String, registro.PrecoExercicio));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.IndicadorCorrecaoOpcao, DbType.String, registro.IndicadorCorrecaoOpcao));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DataVencimento, DbType.String, registro.DataVencimento));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.FatorCotacao, DbType.String, registro.FatorCotacao));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoExercicioPontos, DbType.String, registro.PrecoExercicioPontos));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.ISIN, DbType.String, registro.CodISIN));
        //    cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DistribuicaoMES, DbType.String, registro.DistribuicaoMES));
        //}
        #endregion

    }
}