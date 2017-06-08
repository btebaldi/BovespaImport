using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace FeedImport
{
    class FeedExecuter
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.Business.FeedExecuter.cs");

        public void ImportBdiFromRemoteSite(DateTime date)
        {
            bool tudoOk = true;

            //Log inicio de processo da data xxxx
            logger.Info("Import de arquivo remoto BDI Inicializado. Data processada: " + date.ToString("yyyy-MM-dd"));

            FeedImport.Business.BdiImport importHandler = new Business.BdiImport();

            FeedImport.Config.BdiConfig bdiConfig = new FeedImport.Config.BdiConfig(date);
            logger.Debug("Configuracoes BDI carregadas.");

            tudoOk = importHandler.DownloadBdiFile(bdiConfig);

            if (tudoOk && bdiConfig.SourceFile.IsSourceFileZipped)
            { importHandler.DecompressBdiZip(bdiConfig); }

            if (tudoOk)
            {
                DataTable tblHistoricoCotacao = importHandler.ProcessaArquivoBdi(bdiConfig);
                importHandler.ImportCotacao(tblHistoricoCotacao);
            }

            logger.Info("Import de arquivo remoto BDI Finalizado. Data processada: " + date.ToString("yyyy-MM-dd"));
            //Log Fim de processo da data xxxx
        }

    }
}
