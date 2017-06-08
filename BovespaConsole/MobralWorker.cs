using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;
using System.Data;
using CsvCommom;


namespace FeedImport
{
    public static class MobralWorker
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("FeedImport.MobralWorker.cs");

        #region "Constructors"
        //public MobralWorker(string ConnectString)
        //public Bovespa(string ConnectString, string path)
        //{
        //if (!System.IO.File.Exists(path))
        //{
        //    throw new BovespaDataException("Arquivo nao encontrado");
        //}
        //base.ConnectString = ConnectString;
        //}
        #endregion

        public static void GetFileFromZip(FileInfo zipFile, string fileInZip, FileInfo saveFileAs)
        {
            logger.Debug("DecompressZipFile iniciado");
            //https://msdn.microsoft.com/en-us/library/ms404280%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            //http://bvmf.bmfbovespa.com.br/fechamento-pregao/download/Layout_BDIN_20110708.pdf

            //ZipFile.ExtractToDirectory(zipPath, extractPath);

            bool fileFound = false;

            //if (!Directory.Exists(extractPath))
            //{
            //    Directory.CreateDirectory(extractPath);
            //}

            ////System.IO.Directory.Exists(extractPath)
            using (ZipArchive archive = ZipFile.OpenRead(zipFile.FullName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Equals(fileInZip, StringComparison.OrdinalIgnoreCase))
                    {
                        if (fileFound)
                        { throw new BovespaConsoleException("Encontrado mais de um arquivo com o nome " + fileInZip + " no zip " + zipFile.Name); }

                        entry.ExtractToFile(saveFileAs.FullName, true);
                        fileFound = true;
                    }
                }
            }

            if (!fileFound)
            {
                logger.Warn("O arquivo " + fileInZip + " nao foi encontrado no zip '" + zipFile.Name);
            }
            //FileInfo fileToDecompress = new FileInfo(zipPath2);

            //using (FileStream originalFileStream = fileToDecompress.OpenRead())
            //{
            //    string currentFileName = fileToDecompress.FullName;
            //    string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

            //    using (FileStream decompressedFileStream = File.Create(newFileName))
            //    {
            //        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
            //        {
            //            decompressionStream.CopyTo(decompressedFileStream);
            //            Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
            //        }
            //    }
            //}

            logger.Debug("DecompressZipFile finalizado");

        }


        internal static void DownloadFile(Uri url, string saveFileName, string saveDirectory)
        {
            FileInfo file = new FileInfo(Path.Combine(saveDirectory, saveFileName));
            DownloadFile(url, file);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void DownloadFile(Uri url, FileInfo saveAsFile)
        {
            if (!saveAsFile.Directory.Exists)
            { Directory.CreateDirectory(saveAsFile.Directory.FullName); }

            using (var client = new WebClient())
            {
                //FileInfo file = new FileInfo(Path.Combine(saveDirectory, saveFileName));
                client.DownloadFile(url, saveAsFile.FullName);
            }
        }


        internal static bool GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            System.Security.AccessControl.DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule("everyone", System.Security.AccessControl.FileSystemRights.FullControl,
                                                             System.Security.AccessControl.InheritanceFlags.ObjectInherit | System.Security.AccessControl.InheritanceFlags.ContainerInherit,
                                                             System.Security.AccessControl.PropagationFlags.NoPropagateInherit, System.Security.AccessControl.AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            return true;
        }

        internal static string Encode(string str)
        {
            return WebUtility.UrlEncode(str);
        }

        internal static string Decode(string str)
        {
            return WebUtility.UrlDecode(str);
        }

        //    DownloadDadosDiarios
        //{}

        //    DownloadDadosDividendos
        //{}





    }
}
