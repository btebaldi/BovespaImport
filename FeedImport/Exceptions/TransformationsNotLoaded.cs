using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.FeedImport.Exceptions
{
    class TransformationsNotLoaded : ApplicationException
    {
        public TransformationsNotLoaded()
            : base()
        {
        }

        public TransformationsNotLoaded(string msg)
            : base(msg)
        {
        }

        public TransformationsNotLoaded(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
