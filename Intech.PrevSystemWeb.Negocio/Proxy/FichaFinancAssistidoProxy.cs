#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;
using Intech.PrevSystemWeb.Entidades.Dominios; 
#endregion

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class FichaFinancAssistidoProxy : FichaFinancAssistidoDAO
    {
        public override IEnumerable<FichaFinancAssistidoEntidade> BuscarDatasPorProcesso(int SQ_PROCESSO, DateTime dtReferencia)
        {
            var datas = base.BuscarDatasPorProcesso(SQ_PROCESSO, dtReferencia).ToList();

            datas.ForEach(data =>
            {
                var rubricasData = base.BuscarPorProcessoDataCompetencia(SQ_PROCESSO, data.DT_COMPETENCIA);

                data.DS_COMPETENCIA = data.DT_COMPETENCIA.ToString("MM/yyyy");
                data.VAL_BRUTO = rubricasData.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO).Sum(x => x.VL_CALCULO);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.DESCONTO).Sum(x => x.VL_CALCULO);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            });

            return datas;
        }

        public dynamic BuscarRubricasPorProcessoCompetencia(int SQ_PROCESSO, DateTime dtCompetencia)
        {
            var rubricas = base.BuscarPorProcessoDataCompetencia(SQ_PROCESSO, dtCompetencia);

            var proventos = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.PROVENTO).ToList();
            var descontos = rubricas.Where(x => x.IR_LANCAMENTO == DMN_LANCAMENTO_FICHA.DESCONTO).ToList();

            foreach (var rubrica in descontos)
                rubrica.VL_CALCULO *= -1;

            var bruto = proventos.Sum(x => x.VL_CALCULO);
            var valDescontos = descontos.Sum(x => x.VL_CALCULO);
            var liquido = bruto - Math.Abs(valDescontos.Value);

            return new {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new
                {
                    Competencia = dtCompetencia,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido
                }
            };
        }
    }
}