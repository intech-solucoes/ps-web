using System;
using System.Collections.Generic;

namespace Intech.PrevSystemWeb.Entidades.Outras
{
    public class ContrachequeEntidade
    {
        public List<FichaFinancAssistidoEntidade> Rubricas { get; set; }

        public List<FichaFinancAssistidoEntidade> Proventos { get; set; }
        public List<FichaFinancAssistidoEntidade> Descontos { get; set; }

        public ResumoContrachequeEntidade Resumo { get; set; }
    }

    public class ResumoContrachequeEntidade
    {
        public DateTime Referencia { get; set; }
        public DateTime DataCredito { get; set; }

        public decimal Bruto { get; set; }
        public decimal Descontos { get; set; }
        public decimal Liquido => Bruto - Math.Abs(Descontos);
    }
}