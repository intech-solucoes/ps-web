using Intech.PrevSystemWeb.Entidades;
using Intech.PrevSystemWeb.Negocio.Proxy;

namespace Intech.PrevSystemWeb.Negocio.Calculos.IRRF
{
    public abstract class BaseCalculoIRRF
    {
        public IRRFEntidade IRRF { get; set; }

        public BaseCalculoIRRF()
        {
            IRRF = new IRRFProxy().BuscarUltima();
        }
    }
}
