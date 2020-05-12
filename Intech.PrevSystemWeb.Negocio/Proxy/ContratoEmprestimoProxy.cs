#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades; 
#endregion

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class ContratoEmprestimoProxy : ContratoEmprestimoDAO
    {
        public override List<ContratoEmprestimoEntidade> BuscarPorCdPessoa(int CD_PESSOA)
        {
            var contratos = base.BuscarPorCdPessoa(CD_PESSOA);

            foreach(var contrato in contratos)
            {
                var encargos = new HistEncargoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO);
                if (encargos == null)
                    contrato.VL_IOF = 0;
                else
                    contrato.VL_IOF = encargos.VL_ENCARGO.Value;
            }

            return contratos;
        }

        public override ContratoEmprestimoEntidade BuscarPorSqContrato(int SQ_CONTRATO)
        {
            var contrato = base.BuscarPorSqContrato(SQ_CONTRATO);

            var encargos = new HistEncargoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO);
            if (encargos == null)
                contrato.VL_IOF = 0;
            else
                contrato.VL_IOF = encargos.VL_ENCARGO.Value;

            contrato.Prestacoes = new HistSaldoContratoProxy().BuscarPorSqContrato(contrato.SQ_CONTRATO).ToList();

            return contrato;
        }
    }
}