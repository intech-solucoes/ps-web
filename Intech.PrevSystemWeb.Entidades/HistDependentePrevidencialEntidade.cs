using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_HIST_DEPENDENTE_PREVIDENCIAL")]
	public class HistDependentePrevidencialEntidade
	{
		[Key]
		public int SQ_DEPENDENTE { get; set; }
		public int CD_PESSOA { get; set; }
		public int CD_PESSOA_DEP { get; set; }
		public int SQ_PLANO_PREVIDENCIAL { get; set; }
		public DateTime? DT_INCLUSAO { get; set; }
		public decimal? VLR_PERC_PARTICIPACAO { get; set; }
		[Write(false)] public string NO_PESSOA { get; set; }
		[Write(false)] public DateTime DT_NASCIMENTO { get; set; }
		[Write(false)] public string DS_GRAU_PARENTESCO { get; set; }
		[Write(false)] public string NR_CPF { get; set; }
	}
}
