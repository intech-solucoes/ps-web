using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("fi_uf")]
	public class UFEntidade
	{
		[Key]
		public string CD_UF { get; set; }
		public string DS_UF { get; set; }
		public string NR_UF { get; set; }
		public DateTime? DT_CRIACAO { get; set; }
		public DateTime? DT_INSTALACAO { get; set; }
	}
}
