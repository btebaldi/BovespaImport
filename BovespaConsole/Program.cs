using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Reflection;

namespace FeedImport
{
    class Program
    {
        static void Main(string[] args)
        {
            bool working = true;
            FeedExecuter worker = new FeedExecuter();

            DateTime dataImportacao;

            while (working)
            {

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Qual a data do arquivo BDI a ser importada? (yyyy-MM-dd)");
                    System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", provider, System.Globalization.DateTimeStyles.None, out dataImportacao))
                    { break; }
                    else
                    {
                        Console.WriteLine("Entre a data no formato yyyy-MM-dd");
                    }

                }// end of while 


                worker.ImportBdiFromRemoteSite(dataImportacao);


                Console.WriteLine("Importar outra data? [y/n]");
                string consoleImput = Console.ReadLine().ToUpper();
                if (consoleImput == "N")
                { working = false; }
                else if (consoleImput != "Y")
                {
                    Console.WriteLine("Resposta nao entendida. Saindo.");
                    working = false;
                }

            }
            //var d = DateTime.ParseExact("19072016", "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);


            //ImportBdi peaoBdi = new ImportBdi();

            //DateTime ini = new DateTime(2016, 07, 15);
            //peaoBdi.ImportaBdiPeriodo(ini, DateTime.Today);
            //peaoBdi.ImportaBdiOntem();


            //AnalistaQuandl peaoQuandl = new AnalistaQuandl();
            //peaoQuandl.ImportaQuandlOntem();

            //string strConn = @"Data Source=(LocalDb)\v11.0;Initial Catalog=Bovespa;Integrated Security=True";
            //string strConn = "Data Source=<machinename>\Sqlexpress;Initial Catalog=Bovespa;Integrated Security=True";

            //Uri b = new Uri("http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/bdi0710.zip");
            //Uri c = new Uri("http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/bdi0708.zip");

            //            "http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/bdi0706.zip"


            //BovespaData.BusinessClass.MobralWorker.DownloadFile("http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/bdi0709.zip", "bdi_2016-07-09.zip");
            //BovespaData.BusinessClass.MobralWorker.Decompress("bdi_2016-07-06.zip", "");



            //peao.DownloadFile();
            //peao.Decompress();


            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2010.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2011.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2012.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2013.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2014.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2015.txt");
            //bovespaHandler.Save(bovespaFile);

            //bovespaFile = bovespaHandler.LoadFromFlatFile(@"C:\Users\Tebaldi\Documents\COTAHIST_A2016.txt");
            //bovespaHandler.Save(bovespaFile);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
