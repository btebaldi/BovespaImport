using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary1
{
    public class Reader
    {
        private FileInfo mFilePath;

        public string FilePath
        {
            get { return mFilePath.FullName; }
        }


        #region "Data Retrieval Methods"
        public DataSet GetProducts()
        {
            List<BovespaData.DataClasses.Entidades.RegistroState> lstRegistro = new List<BovespaData.DataClasses.Entidades.RegistroState>();


            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(mFilePath.FullName);
            while ((line = file.ReadLine()) != null)
            {
                BovespaData.DataClasses.Entidades.RegistroState registro = new BovespaData.DataClasses.Entidades.RegistroState();

                registro.CodigoBDI = line.Substring(1, 1);
                //Console.WriteLine(line);
                //counter++;
            }

            file.Close();

            // Suspend the screen.
            // Console.ReadLine();



            DataSet ds = new DataSet();
            string strSQL;

            strSQL = "SELECT * FROM " + (new DataClasses.Entidades.RegistroState.RegistroStruct()).ObjectName;

            // Use the DataLayer to Build DataTable
            ds = DataLayer.GetDataSet(strSQL, mstrConnectString);

            return ds;
        }
        /*
        public DataSet GetProduct(Entidades.RegistroState registro)
        {
            DataSet ds = null;
            string strSQL;

            // ToDo: Selecao de registro unico
            strSQL = "SELECT * FROM " + registro.Schema.ObjectName;
            strSQL += " WHERE ";
            strSQL += registro.Schema.DataPregao + " = '" + registro.DataPregao.ToString() + "'";
            strSQL += " AND ";
            strSQL += registro.Schema.Ticker + " = '" + registro.Ticker.ToString() + "'";

            ds = DataLayer.GetDataSet(strSQL, mstrConnectString);

            return ds;
        }

        public bool Load(Entidades.RegistroState registro)
        {
            DataSet ds;
            DataRow dr;
            bool boolRet = false;

            ds = GetProduct(registro);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    boolRet = true;

                    dr = ds.Tables[0].Rows[0];

                    // ToDo: Load do registro

                    //registro. = Convert.ToInt32(dr[prod.Schema.ProductId]);
                    //prod.ProductName = dr[prod.Schema.ProductName].ToString();
                    //prod.Introduced = dr[prod.Schema.Introduced].ToString();
                    //prod.Cost = Convert.ToDecimal(dr[prod.Schema.Cost]);
                    //prod.Price = Convert.ToDecimal(dr[prod.Schema.Price]);
                    //prod.Discontinued = Convert.ToBoolean(dr[prod.Schema.Discontinued]);
                }
            }
            return boolRet;
        }
        */
        #endregion


    }
}

/*
class RegistroDataClass
{


    #region "Data Modification Methods"
    public virtual void Validate(Entidades.RegistroState registro)
    {
        string strMsg = string.Empty;


        // ToDo: revisar validacoes
        if (registro.TipoRegistro != 1)
        { strMsg += "Registro nao valido. Registro deve ser 1. Porque? porque a bovespa quis!!!" + Environment.NewLine; }

        if (registro.DataPregao == null)
        { strMsg += "Data de pregao invalida." + Environment.NewLine; }

        if (registro.CodigoBDI == null)
        { strMsg += "Data de pregao invalida." + Environment.NewLine; }

        if (registro.Ticker.Trim() == string.Empty)
        { strMsg += "Ticker invalido." + Environment.NewLine; }

        if (registro.TipoMercado == null)
        { strMsg += "Tipo de mercado vazio." + Environment.NewLine; }

        if (registro.NomeResumido.Trim() == string.Empty)
        { strMsg += "Nome resumido esta vazio." + Environment.NewLine; }

        if (registro.EspecificacaoPapel.Trim() == string.Empty)
        { strMsg += "Especificacao do papal nao pode ser nula." + Environment.NewLine; }

        if (registro.Prazo.Trim() == string.Empty)
        { strMsg += "Prazo nulo." + Environment.NewLine; }

        if (registro.Moeda.Trim() == string.Empty)
        { strMsg += "Moeda vazia." + Environment.NewLine; }

        if (registro.PrecoAbertura == null)
        { strMsg += "Preco de Abertura vazio." + Environment.NewLine; }

        if (registro.PrecoMaximo == null)
        { strMsg += "Preco maximo vazio." + Environment.NewLine; }

        if (registro.PrecoMinimo == null)
        { strMsg += "Preco minimo vazio." + Environment.NewLine; }

        if (registro.PrecoMedio == null)
        { strMsg += "Preco medio vazio." + Environment.NewLine; }

        if (registro.PrecoFechamento == null)
        { strMsg += "Preco de fechamento vazio." + Environment.NewLine; }

        if (registro.PrecoMelhorCompra == null)
        { strMsg += "Preco da melhor oferta de compra vazio." + Environment.NewLine; }

        if (registro.PrecoMelhorVenda == null)
        { strMsg += "Preco da melhor oferta de venda vazio." + Environment.NewLine; }

        if (registro.TotalNegocios == null)
        { strMsg += "Total de negocios." + Environment.NewLine; }

        if (registro.Quantidade == null)
        { strMsg += "Quantidade total de titulos negociados vazio." + Environment.NewLine; }

        if (registro.Volume == null)
        { strMsg += "Volume negociado vazio." + Environment.NewLine; }

        if (registro.PrecoExercicio == null)
        { strMsg += "Preco de exercicio vazio." + Environment.NewLine; }

        if (registro.IndicadorCorrecaoOpcao == null)
        { strMsg += "Indicador de correcao de opcao vazio." + Environment.NewLine; }

        if (registro.DataVencimento == null)
        { strMsg += "Data de vencimento vazia." + Environment.NewLine; }

        if ((registro.FatorCotacao != 1) && (registro.FatorCotacao != 1000))
        { strMsg += "Fator de cotacao invalido." + Environment.NewLine; }

        if (registro.PrecoExercicioPontos == null)
        { strMsg += "Preco de exercicio em pontos vazio." + Environment.NewLine; }

        if (registro.CodISIN.Trim() != string.Empty)
        { strMsg += "Codigo ISIN vazio." + Environment.NewLine; }

        if (registro.DistribuicaoMES == null)
        { strMsg += "Numero de distribuicao do papel vazio." + Environment.NewLine; }


        if (strMsg != string.Empty)
        {
            throw new BovespaDataException(strMsg);
        }
    }

    public int Insert(Entidades.RegistroState registro)
    {
        IDbCommand cmd;
        string strSQL;

        //Check Business Rules
        Validate(registro);

        // ToDo: Metodo de insercao da bovespa
        strSQL = "INSERT INTO " + registro.Schema.ObjectName + " ( ";
        //strSQL += "sProductName, dtIntroduced, cCost, cPrice, bDiscontinued) ";
        //strSQL += "VALUES(@sProductName, @dtIntroduced, @cCost, @cPrice, @bDiscontinued) ";

        cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        FillInParameters(registro, cmd);

        return DataLayer.ExecuteSQL(cmd, true);
    }

    public int Update(Entidades.RegistroState registro)
    {
        // ToDo: Update

        //IDbCommand cmd;
        //string strSQL;

        //// Check Business Rules
        //Validate(prod);

        //strSQL = "UPDATE tblProducts ";
        //strSQL += "SET sProductName = @sProductName,";
        //strSQL += " dtIntroduced = @dtIntroduced, ";
        //strSQL += " cCost = @cCost, ";
        //strSQL += " cPrice = @cPrice, ";
        //strSQL += " bDiscontinued = @bDiscontinued ";
        //strSQL += " WHERE iProduct_id = @iProduct_id ";

        //cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        //FillInParameters(prod, cmd);

        //return DataLayer.ExecuteSQL(cmd, true);
        return 0;
    }

    public int Delete(Entidades.RegistroState registro)
    {
        //ToDo: Delete
        //IDbCommand cmd;
        //string strSQL;

        //strSQL = "DELETE FROM tblProducts ";
        //strSQL += " WHERE iProduct_id = @iProduct_id ";

        //cmd = DataLayer.CreateCommand(strSQL, mstrConnectString);

        //FillInParameters(prod, cmd);

        //return DataLayer.ExecuteSQL(cmd, true);
        return 0;
    }

    protected void FillInParameters(Entidades.RegistroState registro, IDbCommand cmd)
    {
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TipoRegistro, DbType.String, registro.TipoRegistro));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DataPregao, DbType.String, registro.DataPregao));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.CodigoBDI, DbType.String, registro.CodigoBDI));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Ticker, DbType.String, registro.Ticker));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TipoMercado, DbType.String, registro.TipoMercado));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.NomeResumido, DbType.String, registro.NomeResumido));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.EspecificacaoPapel, DbType.String, registro.EspecificacaoPapel));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Prazo, DbType.String, registro.Prazo));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Moeda, DbType.String, registro.Moeda));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoAbertura, DbType.String, registro.PrecoAbertura));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMaximo, DbType.String, registro.PrecoMaximo));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMinimo, DbType.String, registro.PrecoMinimo));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMedio, DbType.String, registro.PrecoMedio));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoFechamento, DbType.String, registro.PrecoFechamento));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMelhorCompra, DbType.String, registro.PrecoMelhorCompra));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoMelhorVenda, DbType.String, registro.PrecoMelhorVenda));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.TotalNegocios, DbType.String, registro.TotalNegocios));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Quantidade, DbType.String, registro.Quantidade));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.Volume, DbType.String, registro.Volume));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoExercicio, DbType.String, registro.PrecoExercicio));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.IndicadorCorrecaoOpcao, DbType.String, registro.IndicadorCorrecaoOpcao));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DataVencimento, DbType.String, registro.DataVencimento));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.FatorCotacao, DbType.String, registro.FatorCotacao));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.PrecoExercicioPontos, DbType.String, registro.PrecoExercicioPontos));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.CodISIN, DbType.String, registro.CodISIN));
        cmd.Parameters.Add(DataLayer.CreateParameter("@" + registro.Schema.DistribuicaoMES, DbType.String, registro.DistribuicaoMES));
    }
    #endregion

}

*/