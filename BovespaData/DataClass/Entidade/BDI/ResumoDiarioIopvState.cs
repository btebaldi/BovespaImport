using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaData.DataClass.Entidade.BDI
{
    public class ResumoDiarioIopvState : Base.RegistroBase
    {
        //01 -TIPREG -TIPO DE REGISTRO FIXO "08" N(02) 01 02
        //02 -IDENTI -IDENTIFICAÇÃO DO IOPV N(02) 03 04
        //03 -SIGLA -SIGLA DO IOPV X(04) 05 08
        //04 -NOMRES -NOME RESUMIDO DO IOPV X(12) 09 20
        //05 -NOMIND -NOME DO IOPV X(30) 21 50
        //06 -IDCABE – IOPV DE ABERTURA DO PREGÃO N(05)V99 51 57
        //07 -IDCMIN -IOPV MÍNIMO DO PREGÃO N(05)V99 58 64
        //08 -IDCMAX – IOPV MÁXIMO DO PREGÃO N(05)V99 65 71
        //09 -IDCMED -IOPV DA MÉDIA ARITMÉTICA DOS IOPV‟s DO PREGÃO N(05)V99 72 78
        //10 -IDCFEC – IOPV DE FECHAMENTO N(05)V99 79 85
        //11 -SINEVO -SINAL DA EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO VER TABELA ASSOCIADA PA019 X(01) 86 86
        //12 -EVOIND -EVOLUÇÃO PERCENTUAL DO IOPV DE FECHAMENTO N(03)V99 87 91
        //13 -RESERVA EM BRANCO X(259) 92 350

        public string Identificacao { get; set; }

        public string Sigla { get; set; }

        public string NomeResumido { get; set; }

        public string NomeIopv { get; set; }

        public decimal IopvAbertura { get; set; }

        public decimal IopvMinimo { get; set; }

        public decimal IopvMaximo { get; set; }

        public decimal IopvMedia { get; set; }

        public decimal IopvFechamento { get; set; }

        public decimal Evolucao { get; set; }

        public string SinalEvoluvao { get; set; }

        public string Reserva { get; set; }
    }
}
