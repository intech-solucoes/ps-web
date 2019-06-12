using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class ContratoEmprestimoProxy : ContratoEmprestimoDAO
    {
        public override IEnumerable<ContratoEmprestimoEntidade> BuscarPorCdPessoa(int CD_PESSOA)
        {
            var contratos = base.BuscarPorCdPessoa(CD_PESSOA);

            foreach(var contrato in contratos)
            {
                contrato.VL_IOF = new HistEncargoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO).VL_ENCARGO.Value;
            }

            return contratos;
        }

        public override ContratoEmprestimoEntidade BuscarPorSqContrato(int SQ_CONTRATO)
        {
            var contrato = base.BuscarPorSqContrato(SQ_CONTRATO);

            contrato.VL_IOF = new HistEncargoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO).VL_ENCARGO.Value;
            contrato.Prestacoes = new HistSaldoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO).ToList();

            return contrato;
        }
    }
}