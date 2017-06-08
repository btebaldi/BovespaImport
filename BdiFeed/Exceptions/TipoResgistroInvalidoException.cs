using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.BdiFeed.Exceptions
{
    class BdiFeedTipoInvalidoException : ApplicationException
    {
        public BdiFeedTipoInvalidoException()
                : base()
        { }

        public BdiFeedTipoInvalidoException(string msg)
                : base(msg)
        { }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
