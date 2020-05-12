using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("fi_nacionalidade")]
	public class NacionalidadeEntidade
	{
		[Key]
		public int CD_NACIONALIDADE { get; set; }
		public string DS_NACIONALIDADE { get; set; }
	}
}
