using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData
{
    [Serializable]
    public class BovespaDataException : ApplicationException
    {
        public BovespaDataException()
            : base()
        {
        }

        public BovespaDataException(string msg)
            : base(msg)
        {
        }

        public BovespaDataException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
