using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BovespaData.DataClass;

namespace BovespaData.BusinessClass
{
    public class Historico : HistoricoDC
    {
        #region "Constructors"
        public Historico(string ConnectString)
        //public Bovespa(string ConnectString, string path)
        {
            //if (!System.IO.File.Exists(path))
            //{
            //    throw new BovespaDataException("Arquivo nao encontrado");
            //}
            base.ConnectString = ConnectString;
        }
        #endregion

    }
}
