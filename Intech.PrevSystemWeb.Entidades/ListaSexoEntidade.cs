using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("fi_sexo")]
	public class ListaSexoEntidade
	{
		[Key]
		public string IR_SEXO { get; set; }
		public string DS_SEXO { get; set; }
	}
}
