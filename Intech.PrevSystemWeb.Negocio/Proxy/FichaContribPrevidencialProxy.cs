using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;
using Intech.PrevSystemWeb.Entidades.Outras;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class FichaContribPrevidencialProxy : FichaContribPrevidencialDAO
    {
        public List<SaldoEntidade> BuscarSaldoPorContratoPlano(int sqContratoTrabalho, int sqPlanoPrevidencial, int fundoPatronal, int fundoIndividual)
        {
            var contribuicoesPatronais = base.BuscarPorContratoPlanoFundo(sqContratoTrabalho, sqPlanoPrevidencial, fundoPatronal).ToList();
            var contribuicoesIndividuais = base.BuscarPorContratoPlanoFundo(sqContratoTrabalho, sqPlanoPrevidencial, fundoIndividual).ToList();

            var plano = new PlanoPrevidencialProxy().BuscarPorPlano(sqPlanoPrevidencial);

            if (string.IsNullOrEmpty(plano.CD_INDICE_VALORIZACAO))
                throw new Exception("Índice cota não cadastrado");

            var valorIndiceQuota = new IndiceProxy().BuscarUltimoPorCdIndice(plano.CD_INDICE_VALORIZACAO).VL_INDICE;

            var listaSaldos = new List<SaldoEntidade>();

            var saldoPatronal = MontarSaldo(contribuicoesPatronais, valorIndiceQuota.Value);
            var saldoIndividual = MontarSaldo(contribuicoesIndividuais, valorIndiceQuota.Value);
            var total = saldoPatronal + saldoIndividual;

            total.DS_TIPO_FUNDO = "TOTAL";

            listaSaldos.Add(saldoIndividual);
            listaSaldos.Add(saldoPatronal);
            listaSaldos.Add(total);

            return listaSaldos;
        }

        public SaldoEntidade MontarSaldo(List<FichaContribPrevidencialEntidade> contribuicoes, decimal valorIndice)
        {
            var saldo = new SaldoEntidade
            {
                DS_TIPO_FUNDO = contribuicoes.First().DS_TIPO_FUNDO,
                VL_CONTRIBUICAO = contribuicoes.Sum(x => x.VL_CONTRIBUICAO).Value,
                QT_COTA_CONTRIBUICAO = contribuicoes.Sum(x => x.QT_COTA_CONTRIBUICAO).Value
            };

            saldo.VL_ATUALIZADO = saldo.QT_COTA_CONTRIBUICAO * valorIndice;

            if (contribuicoes.First().IR_OPERACAO == "C")
                saldo.VL_RENDIMENTO = saldo.VL_ATUALIZADO - saldo.VL_CONTRIBUICAO;
            else
                saldo.VL_RENDIMENTO = saldo.VL_ATUALIZADO - (saldo.VL_CONTRIBUICAO * -1);

            return saldo;
        }
    }
}
