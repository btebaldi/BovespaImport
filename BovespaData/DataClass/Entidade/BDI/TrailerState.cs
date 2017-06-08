using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class TrailerState : Base.TrailerBase
    {
        //01 -TIPO DE REGISTRO FIXO "99" N(02) 01 02
        //02 -NOME DO ARQUIVOVER DEFINIÇÃO ABAIXO X(08) 03 10
        //CÓDIGO DO ARQUIVO FIXO "BDIN" X(04) 03 06
        //CÓDIGO DO USUÁRIO FIXO "9999" N(04) 07 10
        //03 -CÓDIGO DA ORIGEM FIXO "BOVESPA" X(08) 11 18
        //04 -CÓDIGO DO DESTINO FIXO "9999" N(04) 19 22
        //05 -DATA DA GERAÇÃO DO ARQUIVO FORMATO AAAAMMDD N(08) 23 30
        //06 -TOTAL DE REGISTROS INCLUIR TAMBÉM OS REGISTROS HEADER E TRAILER N(09) 31 39 
        //07 -RESERVA EM BRANCO X(311) 40 350
        public string CodigoDestino { get; set; }

        public string Reserva { get; set; }
    }
}
