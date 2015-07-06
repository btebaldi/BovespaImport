using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClasses.Entidades
{
    public class FlatFileState
    {
        public HeaderState Header { get; set; }
        public List<RegistroState> RegistroCollection { get; set; }
        public TrailerState Trailer { get; set; }

        #region "Constructors"
        public FlatFileState()
        {
            Header = new HeaderState();
            RegistroCollection = new List<RegistroState>();
            Trailer = new TrailerState();
        }
        #endregion

    }
}
