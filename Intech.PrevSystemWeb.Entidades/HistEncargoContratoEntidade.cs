using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_HIST_ENCARGO_CONTRATO")]
	public class HistEncargoContratoEntidade
	{
		[Key]
		public int SQ_HISTORICO { get; set; }
		public int? SQ_CONTRATO { get; set; }
		public int? SQ_TIPO_ENCARGO { get; set; }
		public DateTime DT_VENCIMENTO { get; set; }
		public decimal? VL_ENCARGO { get; set; }
		public decimal? TX_ENCARGO { get; set; }
		public decimal? VL_DEDUZIDO { get; set; }
		public DateTime? DT_RECEBIMENTO { get; set; }
	}
}
