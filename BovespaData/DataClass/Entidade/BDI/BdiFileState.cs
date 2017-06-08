using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class BdiFileState
    {
        public HeaderState Header { get; set; }
        public List<IndiceState> Indices { get; set; }
        public List<CotacaoState> Cotacoes { get; set; }
        public List<ResumoBdiState> ResumoPorCodBdi { get; set; }
        public List<MaiorOscilacaoVistaState> MaiorOsilacaoAvista { get; set; }
        public List<MaiorOscilacaoIbovState> MaiorOsilacaoIbov { get; set; }
        public List<MaisNegociadasVistaState> MaisNegociadasAVista { get; set; }
        public List<MaisNegociadasState> MaisNegociadas { get; set; }
        public List<ResumoDiarioIopvState> Iopv { get; set; }
        public List<BdrState> BDR { get; set; }
        public TrailerState Trailer { get; set; }

        #region "Constructors"
        public BdiFileState()
        {
            //InitializeCotacoes();
            Header = new HeaderState();
            Indices = new List<IndiceState>();
            Cotacoes = new List<CotacaoState>();
            ResumoPorCodBdi = new List<ResumoBdiState>();
            MaiorOsilacaoAvista = new List<MaiorOscilacaoVistaState>();
            MaiorOsilacaoIbov = new List<MaiorOscilacaoIbovState>();
            MaisNegociadasAVista = new List<MaisNegociadasVistaState>();
            MaisNegociadas = new List<MaisNegociadasState>();
            Iopv = new List<ResumoDiarioIopvState>();
            BDR = new List<BdrState>();
            Trailer = new TrailerState();
        }
        #endregion

    }
}
