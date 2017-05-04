using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tebaldi.MobralWorker
{
    class MobralWorkerFileNotFoundException : ApplicationException
    {
        public MobralWorkerFileNotFoundException()
            : base()
        {
        }

        public MobralWorkerFileNotFoundException(string msg)
            : base(msg)
        {
        }

        public MobralWorkerFileNotFoundException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        public string MessageForWebDisplay
        {
            get { return base.Message.Replace(Environment.NewLine, "<br>"); }
        }
    }
}
