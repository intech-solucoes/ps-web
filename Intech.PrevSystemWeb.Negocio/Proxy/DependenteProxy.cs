using System;
using System.Collections.Generic;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class DependenteProxy : DependenteDAO
    {
        public override IEnumerable<DependenteEntidade> BuscarPorContratoTrabalho(int SQ_CONTRATO_TRABALHO)
        {
            var dependentes = base.BuscarPorContratoTrabalho(SQ_CONTRATO_TRABALHO);

            foreach(var dep in dependentes)
            {
                if(!string.IsNullOrEmpty(dep.NR_CPF))
                    dep.NR_CPF = dep.NR_CPF.PadLeft(11, '0').AplicarMascara(Mascaras.CPF);
            }

            return dependentes;
        }
    }
}