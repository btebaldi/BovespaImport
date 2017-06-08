using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
//using System.Data;
using System.Net;


namespace Tebaldi.MobralWorker
{
    public static class MobralWorker
    {

        public static void GetFileFromZip(FileInfo zipFile, string fileInZip, FileInfo extractFileAs)
        {
            //https://msdn.microsoft.com/en-us/library/ms404280%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            //http://bvmf.bmfbovespa.com.br/fechamento-pregao/download/Layout_BDIN_20110708.pdf


            if (!zipFile.Exists)
            { throw new MobralWorkerException("Arquivo zip não existe (" + zipFile.FullName + ")"); }


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
                        { throw new MobralWorkerException("Encontrado mais de um arquivo com o nome " + fileInZip + " no zip " + zipFile.Name); }

                        entry.ExtractToFile(extractFileAs.FullName, true);
                        fileFound = true;
                    }
                }
            }

            if (!fileFound)
            {
                throw new MobralWorkerFileNotFoundException("O arquivo " + fileInZip + " nao foi encontrado no zip '" + zipFile.Name);
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

        }


        public static void DownloadFile(Uri url, string saveFileName, string saveDirectory)
        {
            FileInfo file = new FileInfo(Path.Combine(saveDirectory, saveFileName));
            DownloadFile(url, file);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DownloadFile(Uri url, FileInfo saveAsFile)
        {
            if (!saveAsFile.Directory.Exists)
            { Directory.CreateDirectory(saveAsFile.Directory.FullName); }

            using (var client = new WebClient())
            {
                //FileInfo file = new FileInfo(Path.Combine(saveDirectory, saveFileName));
                client.DownloadFile(url, saveAsFile.FullName);
            }
        }

        internal static string Encode(string str)
        {
            return WebUtility.UrlEncode(str);
        }

        internal static string Decode(string str)
        {
            return WebUtility.UrlDecode(str);
        }
    }
}
