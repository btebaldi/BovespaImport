using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.Exceptions
{
    class BdiFileNotFoundException : ApplicationException
    {
        public BdiFileNotFoundException()
                : base()
        { }

        public BdiFileNotFoundException(string msg)
                : base(msg)
        { }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
