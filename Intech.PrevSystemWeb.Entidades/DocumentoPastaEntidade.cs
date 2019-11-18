﻿using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("WEB_DOCUMENTO_PASTA")]
    public class DocumentoPastaEntidade
    {
		[Key]
		public decimal OID_DOCUMENTO_PASTA { get; set; }
		public string NOM_PASTA { get; set; }
		public decimal? OID_DOCUMENTO_PASTA_PAI { get; set; }
        
    }
}
