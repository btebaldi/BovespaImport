using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Exceptions
{
    class DownloadError404Exception : ApplicationException
    {
        public DownloadError404Exception()
                : base()
        { }

        public DownloadError404Exception(string msg)
                : base(msg)
        { }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
