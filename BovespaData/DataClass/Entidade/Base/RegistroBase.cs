using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Base
{
    public abstract class RegistroBase
    {
        /// <summary>
        /// Tipo de registro - fixo em um número
        /// </summary>
        public int TipoDeRegistro { get; set; }
    }
}
