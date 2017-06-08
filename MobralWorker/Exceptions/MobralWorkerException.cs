using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.MobralWorker
{
    class MobralWorkerException : ApplicationException
    {
        public MobralWorkerException()
            : base()
        {
        }

        public MobralWorkerException(string msg)
            : base(msg)
        {
        }

        public MobralWorkerException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
