#region Usings
using Intech.PrevSystemWeb.Entidades;
using Intech.PrevSystemWeb.Entidades.Extensoes;
using Intech.PrevSystemWeb.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystemWeb.Negocio.Calculos.IRRF
{
    public class CalculoIRRFProgressivo : BaseCalculoIRRF
    {
        public List<IRRFFaixaCalculoEntidade> FaixaCalculo { get; set; }

        public IRRFEntidade Buscar(int cdPessoa, int sqContratoTrabalho)
        {
            var valorEmReaisAbatimento = 0M;

            FaixaCalculo = new IRRFFaixaCalculoProxy().BuscarUltima().ToList();

            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCdPessoa(cdPessoa);
            var dependentes = new DependenteProxy().BuscarDependentePorContratoDtValidadeIRRF(sqContratoTrabalho, DateTime.Now).ToList();

            // Busca quantidade máxima de dependentes permitida
            var qntDependentes = Math.Min(dependentes.Count, IRRF.QT_MAXIMO_DEP.Value);
            valorEmReaisAbatimento += qntDependentes * IRRF.VL_ABATIMENTO_DEP.Value;

            if (dadosPessoais.Idade() > IRRF.QT_ANOS_IDADE)
                valorEmReaisAbatimento += IRRF.VL_ABATIMENTO_IDADE.Value;

            return IRRF;
        }
    }
}