using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_IRRF_FAIXA_REGRESSIVO")]
    public class IRRFFaixaRegressivoEntidade
    {
		[Key]
		public int SQ_FAIXA { get; set; }
		public DateTime DT_INIC_VALIDADE { get; set; }
		public int? QT_FAIXA_INICIAL { get; set; }
		public int? QT_FAIXA_FINAL { get; set; }
		public decimal? VL_ALIQUOTA { get; set; }
        
    }
}
