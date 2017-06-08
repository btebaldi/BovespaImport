using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdiFeed
{
    class Config
    {
    }

    class BdiConfig
    {
        /*
        private Uri _siteAddr;
        public Uri SiteAddr { get { return _siteAddr; } }

        string _fileMask;
        string _dateTimePattern;
        string _zipFileName;

        public string RemoteFileName { get; set; }

        string _downloadPath;
        public string DownloadPath { get { return _downloadPath; } }
        public Uri SitePathAndFile { get { return new Uri(SiteAddr, ZipFileName); } }

        string _bdiFile;
        public string BdiFileName { get { return _bdiFile; } }

        public BdiConfig(DateTime date)
        {
            string pattern = @"\{\*\}";

            // Notice the path-like syntax.
            System.Collections.Specialized.NameValueCollection nvc = ConfigCommon.AppConfig.GetSection_NVC("BovespaData/BoletimDiarioIformacao", true);

            _siteAddr = new Uri(nvc["SitePath"]);
            _fileMask = nvc["FileMask"];
            _dateTimePattern = nvc["DateTimePattern"];

            _downloadPath = System.IO.Path.Combine(nvc["DownloadPath"], date.ToString("yyyy-MM-dd"));

            _bdiFile = nvc["BdiFile"];
            _zipFileName = System.Text.RegularExpressions.Regex.Replace(_fileMask, pattern, date.ToString(_dateTimePattern));

            //_zipExtractPath = nvc["ZipExtractPath"];

        }
        */
    }
}
