using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("fi_estado_civil")]
	public class EstadoCivilEntidade
	{
		[Key]
		public int CD_ESTADO_CIVIL { get; set; }
		public string DS_ESTADO_CIVIL { get; set; }
		public int? CD_ESOCIAL { get; set; }
		public string IC_ESTADO_CIVIL { get; set; }
	}
}
