using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Exceptions
{
    class FeedImportException : ApplicationException
    {
        public FeedImportException()
            : base()
        {
        }

        public FeedImportException(string msg)
            : base(msg)
        {
        }

        public FeedImportException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
