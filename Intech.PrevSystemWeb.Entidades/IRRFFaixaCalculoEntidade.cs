using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_IRRF_FAIXA_CALCULO")]
    public class IRRFFaixaCalculoEntidade
    {
		[Key]
		public int SQ_FAIXA_IRRF { get; set; }
		public DateTime DT_INIC_VALIDADE { get; set; }
		public decimal VL_BASE_CALCULO { get; set; }
		public decimal? PC_ALIQUOTA { get; set; }
		public decimal? VL_DEDUCAO { get; set; }
        
    }
}
