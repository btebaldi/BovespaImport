using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.Exceptions
{
    class BdiFeedException : ApplicationException
    {
        public BdiFeedException()
                : base()
        { }

        public BdiFeedException(string msg)
                : base(msg)
        { }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
