using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed
{
    public class BdiConfig
    {
        public DateTime RequestedDate { get; set; }

        public SourceFileInfo SourceFile { get; set; }

        public FileInfo DownloadedFile { get { return SourceFile.SaveFileAs; } }

        public CompressedFileInfo ZipFile { get; set; }

        public BdiConfig(DateTime date, SourceFileInfo sourceInfo, CompressedFileInfo zipFileInfo)
        {
            RequestedDate = date;
            SourceFile = sourceInfo;
            ZipFile = zipFileInfo;
        }

        public void validade()
        {

            //throw new BdiFeedNotImplementedException("Metodo nao implementado");
        }
    }


    public class SourceFileInfo
    {
        public Uri SiteAddress { get; }
        public Uri FileAddress { get; }
        public FileInfo SaveFileAs { get; set; }

        public SourceFileInfo(string siteAddress, string file, FileInfo saveFileAs)
        {
            SiteAddress = new Uri(siteAddress);
            FileAddress = new Uri(SiteAddress, file);
            SaveFileAs = saveFileAs;
        }
    }

    public class CompressedFileInfo
    {
        public FileInfo File { get; set; }
        public string SearchForFile { get; set; }
        public FileInfo ExtracfileAs { get; set; }
    }
}

