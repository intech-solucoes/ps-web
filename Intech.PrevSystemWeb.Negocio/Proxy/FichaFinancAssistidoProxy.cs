#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;
using Intech.PrevSystemWeb.Entidades.Dominios;
using Intech.PrevSystemWeb.Entidades.Outras;
#endregion

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class FichaFinancAssistidoProxy : FichaFinancAssistidoDAO
    {
        public override List<FichaFinancAssistidoEntidade> BuscarDatasPorProcesso(int SQ_PROCESSO)
        {
            var datas = base.BuscarDatasPorProcesso(SQ_PROCESSO).ToList();

            datas.ForEach(data =>
            {
                var rubricasData = base.BuscarPorProcessoReferencia(SQ_PROCESSO, data.DT_REFERENCIA);

                data.DS_COMPETENCIA = data.DT_REFERENCIA.ToString("MM/yyyy");
                data.VAL_BRUTO = rubricasData.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO).Sum(x => x.VL_CALCULO);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.DESCONTO).Sum(x => x.VL_CALCULO);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            });

            return datas;
        }

        public ContrachequeEntidade BuscarRubricasPorProcessoReferencia(int SQ_PROCESSO, DateTime dtReferencia)
        {
            var rubricas = base.BuscarPorProcessoReferencia(SQ_PROCESSO, dtReferencia);

            var proventos = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO).ToList();
            var descontos = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.DESCONTO).ToList();

            foreach (var rubrica in descontos)
                rubrica.VL_CALCULO *= -1;

            var bruto = proventos.Sum(x => x.VL_CALCULO);
            var valDescontos = descontos.Sum(x => x.VL_CALCULO);

            return new ContrachequeEntidade
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new ResumoContrachequeEntidade
                {
                    Referencia = dtReferencia,
                    Bruto = bruto.Value,
                    Descontos = valDescontos.Value
                }
            };
        }

        public ContrachequeEntidade BuscarRelatorioContracheque(int SQ_PROCESSO, DateTime dtReferencia)
        {
            var rubricas = base.BuscarPorProcessoReferencia(SQ_PROCESSO, dtReferencia).ToList();

            foreach(var rubrica in rubricas)
            {
                if (rubrica.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO)
                {
                    rubrica.VAL_PROVENTO = rubrica.VL_CALCULO;
                    rubrica.VAL_DESCONTO = null;
                }
                else
                {
                    rubrica.VAL_PROVENTO = null;
                    rubrica.VAL_DESCONTO = rubrica.VL_CALCULO;
                }

                rubrica.DS_LANCAMENTO = rubrica.DT_REFERENCIA.ToString("MM/yyyy");
            }

            return new ContrachequeEntidade
            {
                Rubricas = rubricas,
                Resumo = new ResumoContrachequeEntidade
                {
                    Referencia = dtReferencia,
                    DataCredito = rubricas.First().DT_CREDITO,
                    Bruto = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO).Sum(x => x.VL_CALCULO).Value,
                    Descontos = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.DESCONTO).Sum(x => x.VL_CALCULO).Value
                }
            };
        }
    }
}