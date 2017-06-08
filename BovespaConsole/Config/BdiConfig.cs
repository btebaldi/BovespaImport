using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedImport.Config
{
    class BdiConfig
    {


        public FileInfo BdiFile;

        public Source SourceFile { get; set; }
        public DirectoryInfo WorkingDir { get; set; }
        public FileInfo DownloadedFile { get; set; }

        public CompressedFile ZipFile;

        public BdiConfig(DateTime date)
        {
            string pattern = @"\{\*\}";
            string _remoteFileMask;
            string _remoteFileDateTimePattern;
            string _remoteFileName;

            string _workPath;
            string _downloadFileMask;
            string _downloadFileDateTimePattern;

            string _unzipFileMask;
            string _unzipFileDateTimePattern;

            // REMOTE INITIALIZATION
            _remoteFileMask = "bdi{*}.zip";
            _remoteFileDateTimePattern = "MMdd";
            _remoteFileName = System.Text.RegularExpressions.Regex.Replace(_remoteFileMask, pattern, date.ToString(_remoteFileDateTimePattern));

            SourceFile = new Source(@"http://bvmf.bmfbovespa.com.br/fechamento-pregao/bdi/", _remoteFileName);

            SourceFile.IsSourceFileZipped = true;

            // DOWNLOADED FILE INITIALIZATION
            _workPath = @"C:\Users\Tebaldi\Downloads";
            _downloadFileMask = "{*}_BDIN.Zip";
            _downloadFileDateTimePattern = "yyyy-MM-dd";

            WorkingDir = new DirectoryInfo(_workPath);
            DownloadedFile = new FileInfo(Path.Combine(WorkingDir.FullName, System.Text.RegularExpressions.Regex.Replace(_downloadFileMask, pattern, date.ToString(_downloadFileDateTimePattern))));

            // Unzip INITIALIZATION
            _unzipFileMask = "{*}_BDIN.txt";
            _unzipFileDateTimePattern = "yyyy-MM-dd";

            //UnzipFile.UnzipDirectory = DownloadDir;
            ZipFile = new CompressedFile();
            ZipFile.SearchForFile = "BDIN";
            ZipFile.SaveFileAs = new FileInfo(Path.Combine(WorkingDir.FullName, System.Text.RegularExpressions.Regex.Replace(_unzipFileMask, pattern, date.ToString(_unzipFileDateTimePattern))));

            //test = new Uri(RemoteSiteAddr, RemoteFileName);
            /*
            // Notice the path-like syntax.
            System.Collections.Specialized.NameValueCollection nvc = ConfigCommon.AppConfig.GetSection_NVC("BovespaData/BoletimDiarioIformacao", true);

            _siteAddr = new Uri(nvc["SitePath"]);
            _fileMask = nvc["FileMask"];
            _dateTimePattern = nvc["DateTimePattern"];

            _downloadPath = System.IO.Path.Combine(nvc["DownloadPath"], date.ToString("yyyy-MM-dd"));

            _bdiFile = nvc["BdiFile"];

            //_zipExtractPath = nvc["ZipExtractPath"];
            */

            InitializeBdiFile();
        }

        private void InitializeBdiFile()
        {
            if (SourceFile.IsSourceFileZipped)
            {
                BdiFile = ZipFile.SaveFileAs;
            }
            else
            {
                BdiFile = DownloadedFile;
            }

        }
    }

    class Source
    {
        public Source(string siteAddress, string file)
        {
            SiteAddress = new Uri(siteAddress);
            FileName = file;

            FileAddress = new Uri(SiteAddress, FileName);
        }

        public Uri SiteAddress { get; }
        public string FileName { get; }
        public Uri FileAddress { get; }

        public bool IsSourceFileZipped { get; set; }
    }

    class CompressedFile
    {
        //public DirectoryInfo UnzipDirectory { get; set; }
        public string SearchForFile { get; set; }
        public FileInfo SaveFileAs { get; set; }
    }
}