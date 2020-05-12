using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("fi_cargo")]
	public class CargoEntidade
	{
		[Key]
		public int SQ_CARGO { get; set; }
		public int CD_PESSOA_PATR { get; set; }
		public string CD_CARGO { get; set; }
		public string DS_CARGO { get; set; }
		public DateTime? DT_INIC_VALIDADE { get; set; }
		public DateTime? DT_TERM_VALIDADE { get; set; }
		public int? SQ_CBOS { get; set; }
	}
}
