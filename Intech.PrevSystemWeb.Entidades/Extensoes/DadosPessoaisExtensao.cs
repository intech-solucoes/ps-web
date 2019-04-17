using Intech.Lib.Util.Date;
using System;

namespace Intech.PrevSystemWeb.Entidades.Extensoes
{
    public static class DadosPessoaisExtensao
    {
        public static int IdadeEm(this DadosPessoaisEntidade dados, DateTime data) => new Intervalo(data, dados.DT_NASCIMENTO.Value, new CalculoAnosMesesDiasAlgoritmo2()).Anos;
        public static int Idade(this DadosPessoaisEntidade dados) => dados.IdadeEm(DateTime.Now);
    }
}
