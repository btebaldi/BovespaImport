using CsvCommom;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tebaldi.MarketData.Models.State;
using FeedImport.DataClass.State;

namespace FeedImport
{
    class AnalistaQuandl : Business. ImportProcess
    {

        private string ConnectionString;


        public AnalistaQuandl()
            : base()
        {
            ConnectionString = ConfigCommon.AppConfig.GetConnectionString("TebaldiMktDataSql");

        }

        public void ImportaQuandlOntem()
        {
            ImportaQuandl(GetLastBussinessDate());
        }

        public void ImportaQuandl(DateTime date)
        {
            ImportaQuandlPeriodo(date, date);
        }

        public void ImportaQuandlPeriodo(DateTime inicio, DateTime fim)
        {
            Tebaldi.MarketData.FeedHandler handler = new Tebaldi.MarketData.FeedHandler(ConnectionString);

            FeedState feed = handler.GetFeed(2);

            //feed.SetUriQuery("?start_date=" + inicio.ToString("yyyy-MM-dd") + "&end_date=" + fim.ToString("yyyy-MM-dd"));


            QuandlConfig config = new QuandlConfig(feed);

            config.Stage = FeedImport.DataClass.State.ImportStagesEnum.InitialStage;

            if (config.ImportStatusOk)
            {
                //Log inicio de processo da data xxxx
            }

            if (config.ImportStatusOk)
            {
                DownloadQuandlFile(config);
            }

            DataTable tblHistoricoCotacao = Tebaldi.MarketData.HistoricoCotacaoHandler.GetDataTable();
            if (config.ImportStatusOk)
            { ProcessaArquivoCsv(config, tblHistoricoCotacao); }

            if (config.ImportStatusOk)
            { ImportCotacao(tblHistoricoCotacao); }

            if (config.ImportStatusOk)
            {
                //Log Fim de processo da data xxxx
            }
        }


        private static void ExecuteTransformations(List<FeedTransformationState> lstTransformations, DataTable tblHistoricoCotacao)
        {
            DataRow row = tblHistoricoCotacao.NewRow();
            foreach (FeedTransformationState transform in lstTransformations.OrderBy(t => t.ExecuteOrder))
            {
                if (row[transform.OriginalColumn] == Convert.ChangeType(transform.OriginalValue, tblHistoricoCotacao.Columns[transform.OriginalColumn].DataType))
                {
                    row[transform.NewColumn] = Convert.ChangeType(transform.NewValue, tblHistoricoCotacao.Columns[transform.NewColumn].DataType);
                }
            }

        }

        private void ProcessaArquivoCsv(QuandlConfig config, DataTable table)
        {
            try
            {
                using (CsvFileReader csvReader = new CsvFileReader())
                {
                    // Assign CSV data file path
                    csvReader.FileName = Path.Combine(config.DownloadPath, config.DownloadFileSaveName);

                    // Modify values of other input properties if necessary. For example:
                    if (config.Feed.Type == FeedTypeEnum.CsvNoHeader)
                    { csvReader.HeaderPresent = false; }
                    else
                    { csvReader.HeaderPresent = true; }
                    csvReader.Open();

                    while (!csvReader.Eof)
                    {
                        DataRow row = table.NewRow();

                        // Mapeamento das colunas organizadas por index
                        foreach (FeedMappingState columnMapping in config.Feed.ColumnMapping.Where(f => f.MappingType == FeedMappingTypeEnum.Index))
                        {
                            string value = csvReader.Fields[columnMapping.ColumnIndex].Value;

                            SetValueToColumn(value, row, columnMapping);
                        }

                        // Mapeamento das colunas organizadas por Nome
                        foreach (FeedMappingState columnMapping in config.Feed.ColumnMapping.Where(f => f.MappingType == FeedMappingTypeEnum.Name))
                        {
                            string value = csvReader.Fields[columnMapping.ColumnName].Value;

                            SetValueToColumn(value, row, columnMapping);
                        }

                        foreach (FeedMappingState columnMapping in config.Feed.ColumnMapping.Where(f => f.MappingType == FeedMappingTypeEnum.Static))
                        {
                            string value = columnMapping.StaticValue;
                            SetValueToColumn(value, row, columnMapping);
                        }

                        table.Rows.Add(row);
                        csvReader.Next();

                    }

                    csvReader.Close(); //Recommended but optional if within "using"
                }
            }
            catch
            {
                config.Stage = ImportStagesEnum.Error;
                // Log4Net
            }
        }

        private static void SetValueToColumn(string value, DataRow row, FeedMappingState columnMapping)
        {
            if (!String.IsNullOrEmpty(columnMapping.Destination))
            {
                if (String.IsNullOrEmpty(value))
                {
                    row[columnMapping.Destination] = DBNull.Value;
                }
                else
                {
                    if (columnMapping.Type == typeof(DateTime))
                    {
                        row[columnMapping.Destination] = DateTime.ParseExact(value, columnMapping.DateTimeParseMask, columnMapping.Culture);
                    }
                    else
                    {
                        row[columnMapping.Destination] = Convert.ChangeType(value, columnMapping.Type, columnMapping.Culture);
                    }
                }
            }
        }

        private void DownloadQuandlFile(QuandlConfig config)
        {
            config.Stage = ImportStagesEnum.FileDonloadStarted;
            try
            {
                // Donwload de arquivo
                MobralWorker.DownloadFile(config.Feed.Uri, config.DownloadFileSaveName, config.DownloadPath);
            }
            catch
            {
                //log4Net.erro
                config.Stage = ImportStagesEnum.Error;
            }

            config.Stage = ImportStagesEnum.FileDonloadEnded;

        }
    }



    class QuandlConfig : DataClass.State.IImportProcessConfig
    {


        readonly string _downloadFileSaveName;
        readonly string _downloadPath;

        public QuandlConfig(FeedState feed)
        {
            System.Collections.Specialized.NameValueCollection nvc = ConfigCommon.AppConfig.GetSection_NVC("Feed/CSV", true);
            _downloadPath = System.IO.Path.Combine(nvc["DownloadPath"], DateTime.Today.ToString("yyyy-MM-dd"));

            _downloadFileSaveName = nvc["SaveFileName"];
            _downloadFileSaveName = System.Text.RegularExpressions.Regex.Replace(_downloadFileSaveName, @"\[FeederName\]", feed.Name);
            _downloadFileSaveName = System.Text.RegularExpressions.Regex.Replace(_downloadFileSaveName, @"\[Date\]", DateTime.Now.ToString("yyyy-MM-dd"));
            _downloadFileSaveName = System.Text.RegularExpressions.Regex.Replace(_downloadFileSaveName, @"\[Time\]", DateTime.Now.ToString(@"HH\hmm\m"));


            _feed = feed;
            _lastStage = ImportStagesEnum.InitialStage;
            _stage = ImportStagesEnum.InitialStage;
        }


        public bool ImportStatusOk { get { return (this.Stage != ImportStagesEnum.Error); } }


        private ImportStagesEnum _stage;
        private ImportStagesEnum _lastStage;
        public ImportStagesEnum LastStage { get { return _lastStage; } }
        public ImportStagesEnum Stage
        {
            get
            {
                return _stage;
            }
            set
            {
                if (this.ImportStatusOk)
                {
                    _lastStage = _stage;
                    _stage = value;
                }
            }
        }

        private FeedState _feed;

        public FeedState Feed { get { return _feed; } }

        public string DownloadFileSaveName
        {
            get
            {
                return _downloadFileSaveName;
            }
        }

        public string DownloadPath { get { return _downloadPath; } }
    }

}
