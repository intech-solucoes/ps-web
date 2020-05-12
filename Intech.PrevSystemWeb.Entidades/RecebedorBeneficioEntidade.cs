using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_RECEBEDOR_BENEFICIO")]
	public class RecebedorBeneficioEntidade
	{
		public int SQ_PROCESSO { get; set; }
		public int CD_PESSOA_RECEB { get; set; }
		public int? SQ_QUALIDADE { get; set; }
		public string IR_SITUACAO { get; set; }
		public int? SQ_GRUPO_FAMILIAR { get; set; }
		public decimal? PC_RATEIO { get; set; }
		public string IR_CONTRACHEQUE { get; set; }
		public string NR_PROCESSO_INSS { get; set; }
		public DateTime? DT_TERM_RGPS { get; set; }
	}
}
