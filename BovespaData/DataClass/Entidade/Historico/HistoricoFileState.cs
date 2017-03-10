using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.Historico
{
    public class HistoricoFileState
    {
        public string Path { get; set; }
        public HeaderState Header { get; set; }
        //public List<RegistroState> RegistroCollection { get; set; }
        public DataTable Cotacoes { get; set; }

        public TrailerState Trailer { get; set; }

        #region "Constructors"
        public HistoricoFileState()
        {
            Header = new HeaderState();
            //RegistroCollection = new List<RegistroState>();
            InitializeCotacoes();
            Trailer = new TrailerState();
        }
        #endregion


        private void InitializeCotacoes()
        {
            Cotacoes = new DataTable();

            DataClass.Entidade.Historico.CotacaoState entidadeRegistro = new Entidade.Historico.CotacaoState();

            Cotacoes.TableName = entidadeRegistro.Schema.ObjectName;

            Cotacoes.Columns.Add(entidadeRegistro.Schema.TipoRegistro, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.DataPregao, typeof(DateTime));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.CodigoBDI, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.Ticker, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.TipoMercado, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.NomeResumido, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.EspecificacaoPapel, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.Prazo, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.Moeda, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoAbertura, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoMaximo, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoMinimo, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoMedio, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoFechamento, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoMelhorCompra, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoMelhorVenda, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.TotalNegocios, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.Quantidade, typeof(long));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.Volume, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoExercicio, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.IndicadorCorrecaoOpcao, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.DataVencimento, typeof(DateTime));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.FatorCotacao, typeof(int));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.PrecoExercicioPontos, typeof(decimal));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.ISIN, typeof(String));
            Cotacoes.Columns.Add(entidadeRegistro.Schema.DistribuicaoMES, typeof(int));

        }
    }
}
