using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class DadosPessoaisProxy : DadosPessoaisDAO
    {
        public override DadosPessoaisEntidade BuscarPorCdPessoa(int CD_PESSOA)
        {
            var dadosPessoais = base.BuscarPorCdPessoa(CD_PESSOA);

            if (dadosPessoais == null)
                dadosPessoais = base.BuscarPensionistaPorCdPessoa(CD_PESSOA);

            return dadosPessoais;
        }
    }
}
