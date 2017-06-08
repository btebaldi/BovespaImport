using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdiFeed
{
    public class Class1
    {
    }

    class ImportBdi
    {

        public ImportBdi()
            : base()
        {

        }


        public void ImportaBdiOntem()
        {
            //ImportaBdi(GetLastBussinessDate());
        }

        public void ImportaBdiPeriodo(DateTime inicio, DateTime fim)
        {
            while (inicio <= fim)
            {
                //ImportaBdi(inicio);
                //inicio = inicio.AddDays(1);
            }
        }

        

            
       
        

        private bool DecompressBdiZip(BdiConfig bdiConfig)
        {
            bool statusOk = true;
            //try
            //{
            //    // Unzip File
            //    MobralWorker.Decompress(bdiConfig.DownloadPath, bdiConfig.ZipFileName, bdiConfig.BdiFileName);
            //}
            //catch
            //{
            //    statusOk = false;
            //}

            return statusOk;
        }

        private bool DownloadBdiFile(BdiConfig bdiConfig)
        {
            bool statusOk = true;
            //try
            //{    // Donwload de arquivo
            //    MobralWorker.DownloadFile(bdiConfig.SitePathAndFile, bdiConfig.ZipFileName, bdiConfig.DownloadPath);
            //}
            //catch
            //{
            //    //log4Net.erro
            //    statusOk = false;
            //}

            return statusOk;
        }

        /*
        private void GetCotacoes(DataTable table, BovespaData.BusinessClass.Bdi bdiHandler)
        {
            string[] a = { "GFSA3", "ALPA4", "ABEV3", "BTOW3", "FIBR3", "BBDC3", "BBDC4", "BRAP4", "BRKM5", "HYPE3", "CCRO3", "CESP6", "CGAS5", "CMIG4", "MMXM3", "CPFE3", "CPLE6", "CSAN3", "CSNA3", "CTAX4", "MRVE3", "CYRE3", "DASA3", "TAEE11", "ECOR3", "ELET3", "ELET6", "ELPL4", "EMAE4", "EMBR3", "ENBR3", "EQTL3", "OGXP3", "IGTA3", "GETI4", "GGBR4", "GOAU4", "GOLL4", "GRND3", "ITUB4", "ITSA4", "KLBN4", "LAME4", "LIGT3", "LREN3", "JBSS3", "MAGG3", "PCAR4", "LOGN3", "PETR4", "PMAM3", "POMO4", "BRFS3", "PSSA3", "COCE5", "RAPT4", "RENT3", "NATU3", "RSID3", "TIMP3", "SULA11", "SBSP3", "SANB11", "TBLE3", "VIVT4", "UGPA3", "PDGR3", "OIBR3", "OIBR4", "TOTS3", "TRPL4", "MDIA3", "USIM5", "VALE5", "CIEL3", "IUAN", "WSON33", "WEGE3", "BVMF3", "GPIV33" };

            table.Columns.Add("Var", typeof(System.Decimal));
            table.Columns.Add("Var2", typeof(System.Decimal));

            foreach (string a1 in a)
            {
                try
                {
                    BovespaData.DataClass.Entidade.BDI.CotacaoState cotacao = bdiHandler.BdiInfo.Cotacoes.Single(c => c.Ticker == a1);

                    DataRow row = table.NewRow();

                    row["EXT_ID"] = cotacao.Ticker;
                    row["FeedId"] = "BDI.Cotacao";
                    row["AtivoId"] = 0;
                    row["DataPregao"] = bdiHandler.DataPregao;
                    row["NomeResumido"] = cotacao.NomeResumido;
                    row["EspecPapel"] = cotacao.EspecificacaoPapel;
                    row["Ticker"] = cotacao.Ticker;
                    row["TipoMercado"] = cotacao.TipoDeMercado;
                    row["PrecoAbertura"] = cotacao.PrecoAbertura;
                    row["PrecoMaximo"] = cotacao.PrecoMaximo;
                    row["PrecoMedio"] = cotacao.PrecoMedio;
                    row["PrecoMinimo"] = cotacao.PrecoMinimo;
                    row["PrecoFechamento"] = cotacao.PrecoFechamento;
                    row["Quantidade"] = cotacao.Quantidade;
                    row["TotalNegocios"] = cotacao.TotalNegocios;
                    row["Volume"] = cotacao.Volume;
                    row["ISIN"] = cotacao.CodISIN;

                    if (cotacao.SinalOscilacao == "+")
                    {
                        row["Var"] = cotacao.Oscilacao / 100;
                        row["Var2"] = cotacao.Oscilacao2;
                    }
                    else
                    {
                        row["Var"] = -cotacao.Oscilacao / 100;
                        row["Var2"] = -cotacao.Oscilacao2;

                    }

                    table.Rows.Add(row);
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "Sequence contains no matching element")
                    { }
                    else
                    { throw; }
                }
                catch (Exception ex)
                {
                    //ToDo: Log4Net

                }

            }
        }
        */
        //private void GetIndices(DataTable table, List<Tebaldi.MarketData.Models.State.AtivoCotacaoState> lstAtivosSelecionados, BovespaData.BusinessClass.Bdi bdiHandler)
        //{
        //    foreach (Tebaldi.MarketData.Models.State.AtivoCotacaoState ativoSelecionado in lstAtivosSelecionados)
        //    {
        //        try
        //        {
        //            BovespaData.DataClass.Entidade.BDI.IndiceState indice = bdiHandler.BdiInfo.Indices.Single(i => i.NomeIndice == ativoSelecionado.EXT_ID);

        //            DataRow row = table.NewRow();

        //            row["EXT_ID"] = indice.NomeIndice;
        //            row["ID"] = ativoSelecionado.ID;
        //            row["FeedId"] = "Bdi.Indice";
        //            row["DataPregao"] = bdiHandler.DataPregao;
        //            row["Ticker"] = indice.NomeIndice;
        //            row["TipoMercado"] = DBNull.Value;
        //            row["NomeResumido"] = indice.NomeIndice;
        //            row["EspecPapel"] = "Indice";
        //            row["PrecoAbertura"] = indice.IndiceAbertura;
        //            row["PrecoMaximo"] = indice.AnoIndiceMaximo;
        //            row["PrecoMinimo"] = indice.AnoIndiceMinimo;
        //            row["PrecoMedio"] = indice.IndiceMedia;
        //            row["PrecoFechamento"] = indice.IndiceFechamento;
        //            row["TotalNegocios"] = DBNull.Value;
        //            row["Quantidade"] = DBNull.Value;
        //            row["Volume"] = DBNull.Value;
        //            row["ISIN"] = "";

        //            table.Rows.Add(row);

        //        }
        //        catch (Exception ex)
        //        {
        //            //ToDo: Log4Net
        //        }
        //    }
        //}




    }
}
