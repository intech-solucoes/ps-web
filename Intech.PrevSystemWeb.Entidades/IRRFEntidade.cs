using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_IRRF")]
	public class IRRFEntidade
	{
		public DateTime DT_INIC_VALIDADE { get; set; }
		public decimal? QT_MAXIMO_DEP { get; set; }
		public decimal? QT_ANOS_IDADE { get; set; }
		public decimal? VL_ABATIMENTO_DEP { get; set; }
		public decimal? VL_ABATIMENTO_IDADE { get; set; }
		public decimal? VL_RETENCAO_MINIMA { get; set; }
		public decimal? PC_RESIDENTE_EXTERIOR { get; set; }
		public decimal? VL_DEDUCAO { get; set; }
	}
}
