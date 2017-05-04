using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tebaldi.MobralWorker;

namespace Tebaldi.BdiFeed
{
    public class BdiHandler : Tebaldi.BdiFeed.DataClass.BdiDC
    {
        private BdiConfig bdiConfig;

        public BdiHandler(BdiConfig config)
        {
            bdiConfig = config;
            bdiConfig.validade();
        }

        public bool DownloadBdiFile()
        {
            bool status = false;
            try
            {
                Tebaldi.MobralWorker.MobralWorker.DownloadFile(bdiConfig.SourceFile.FileAddress, bdiConfig.SourceFile.SaveFileAs);
                status = true;
            }
            //catch (System.Net.WebException ex)
            //{
            //    // logger.Error("Download error", ex);
            //    if (ex.Status == System.Net.WebExceptionStatus.ProtocolError)
            //    {
            //        logger.Info("Status Code: " + ex.Message);
            //    }
            //}
            catch (Exception ex)
            {
                throw;
            }

            return status;
        }

        public bool DecompressBdiZip()
        {
            bool status = false;

            if (!bdiConfig.DownloadedFile.Exists)
            {
                throw new Exceptions.BdiFeedFileNotDownloadedException("Arquivo BDI não foi feito o download");
            }

            try
            {
                Tebaldi.MobralWorker.MobralWorker.GetFileFromZip(bdiConfig.DownloadedFile, bdiConfig.ZipFile.SearchForFile, bdiConfig.ZipFile.ExtracfileAs);
                status = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return status;
        }


        public Tebaldi.BdiFeed.DataClass.State.BdiFileState ReadBdiFile()
        {
            return this.ReadBdiFile(bdiConfig.ZipFile.ExtracfileAs);
        }


        public Tebaldi.BdiFeed.DataClass.State.BdiFileState ReadBdiFile(FileInfo file)
        {
            if (!file.Exists)
            { throw new Exceptions.BdiFileNotFoundException("Arquivo " + file.Name + "Não encontrado"); }

            return this.LoadFile(file);
        }

        public void Dispose()
        {
            if (bdiConfig.DownloadedFile.Exists)
            { bdiConfig.DownloadedFile.Delete(); }

            if (bdiConfig.SourceFile.SaveFileAs.Exists)
            { bdiConfig.SourceFile.SaveFileAs.Delete(); }

            if (bdiConfig.ZipFile.File.Exists)
            { bdiConfig.ZipFile.File.Delete(); }

            if (bdiConfig.ZipFile.ExtracfileAs.Exists)
            { bdiConfig.ZipFile.ExtracfileAs.Delete(); }
        }

        public void CheckDate(Tebaldi.BdiFeed.DataClass.State.BdiFileState bdiFile)
        {
            if (bdiFile.Header.DataDoPregao != bdiConfig.RequestedDate)
            {
                throw new Exceptions.BdiFeedException("Data do arquivo nao confere com a data requisitada.");
            }
        }
    }
}

