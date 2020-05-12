using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_PATROCINADORA")]
	public class PatrocinadoraEntidade
	{
		public int CD_PESSOA_PATR { get; set; }
		public int CD_PESSOA_ENTID { get; set; }
		public int? SQ_REGRA_REAJUSTE { get; set; }
		public string CD_MOEDA_CORRECAO { get; set; }
		public string CD_PATROCINADORA { get; set; }
		public string CD_AGRUP_CONTABIL { get; set; }
		public string CD_IND_POUP { get; set; }
		public string CD_IND_FUND { get; set; }
		public string IR_CALCULO_CONTRIBUICAO { get; set; }
		public string IR_CALCULO_SRC { get; set; }
		public int? QT_MESES_FICHA { get; set; }
		public decimal? PC_DIF_CONTRIB { get; set; }
		public decimal? TX_ADMINISTRACAO { get; set; }
		public decimal? VL_FOLHA_PAGTO { get; set; }
		public string EE_RECIPROCIDADE { get; set; }
		[Write(false)] public string NO_PESSOA { get; set; }
	}
}
