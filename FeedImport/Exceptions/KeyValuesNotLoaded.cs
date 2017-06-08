using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Exceptions
{
    class KeyValuesNotLoaded : ApplicationException
    {
        public KeyValuesNotLoaded()
            : base()
        {
        }

        public KeyValuesNotLoaded(string msg)
            : base(msg)
        {
        }

        public KeyValuesNotLoaded(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
