using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("WEB_DOCUMENTO")]
	public class DocumentoEntidade
	{
		[Write(false)] public int? SQ_PLANO_PREVIDENCIAL { get; set; }
	}
}
