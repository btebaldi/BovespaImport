using System;
using System.Text;
using System.Collections.Generic;

using DataCommon;
using System.Data;

namespace BovespaData.DataClasses
{
    public class FlatFileDataClass
    {
        //private string mstrConnectString;

        //public string ConnectString
        //{
        //    get { return mstrConnectString; }
        //    set { mstrConnectString = value; }
        //}

        #region "Data Retrieval Methods"

        public Entidades.FlatFileState LoadFromFlatFile(string path)
        {
            Entidades.FlatFileState flatFile = new Entidades.FlatFileState();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {

                string tipoRegistro = line.Substring(0, 2);

                if (tipoRegistro == "00")
                {
                    flatFile.Header.TipoDeRegistro = Convert.ToInt32(tipoRegistro);
                    flatFile.Header.NomeDoArquivo = line.Substring(2, 13);
                    flatFile.Header.CodigoOrigem = line.Substring(15, 8);
                    flatFile.Header.DataDoArquivo = DateTime.ParseExact(line.Substring(23, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    flatFile.Header.Reserva = line.Substring(31, 214);
                }
                else if (tipoRegistro == "01") {
                    Entidades.RegistroState registro = new Entidades.RegistroState();
                }
                else if (tipoRegistro == "99")
                {
                    flatFile.Trailer.TipoDeRegistro = Convert.ToInt32(tipoRegistro);
                    flatFile.Trailer.NomeDoArquivo = line.Substring(2, 13);
                    flatFile.Trailer.CodigoOrigem = line.Substring(15, 8);
                    flatFile.Trailer.DataDoArquivo = DateTime.ParseExact(line.Substring(23, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    flatFile.Trailer.TotalRegistros = Convert.ToInt32(line.Substring(31, 11));
                    flatFile.Trailer.Reserva = line.Substring(42, 203);
                }


                //Console.WriteLine(line);
                //counter++;
            }

            file.Close();

            return flatFile;

        }
        #endregion

        //#region "Data Modification Methods"
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
        //#endregion

    }
}