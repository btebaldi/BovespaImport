using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedImport
{
    class BovespaConsoleException : ApplicationException
    {
        public BovespaConsoleException()
            : base()
        {
        }

        public BovespaConsoleException(string msg)
            : base(msg)
        {
        }

        public BovespaConsoleException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
