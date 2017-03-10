using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BovespaData.DataClass;


namespace BovespaData.BusinessClass
{
    public class Bdi : DataClass.BdiDC
    {
        public Bdi()
        {  }

        public BovespaData.DataClass.Entidade.BDI.BdiFileState Load(string file)
        {
            return LoadFile(file);
        }

        public void ValidaArquivo(DataClass.Entidade.BDI.BdiFileState bdiInfo)
        {
            if (bdiInfo == null)
            {
                throw new BovespaDataException("Arquivo BDI nao inicializado.");
            }
            else
            {
                int totalRegistros = bdiInfo.Indices.Count + bdiInfo.Cotacoes.Count + bdiInfo.ResumoPorCodBdi.Count
                    + bdiInfo.MaiorOsilacaoAvista.Count + bdiInfo.MaiorOsilacaoIbov.Count
                    + bdiInfo.MaisNegociadasAVista.Count + bdiInfo.MaisNegociadas.Count
                    + bdiInfo.Iopv.Count + bdiInfo.BDR.Count;

                totalRegistros += 2; // Contagem de Header e trailer
                if (totalRegistros != bdiInfo.Trailer.TotalRegistros)
                {
                    throw new BovespaDataException("Total de registros inconsistente com informacao");
                }
            }
        }
    }
}
