using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("WEB_DOCUMENTO_PLANO")]
    public class DocumentoPlanoEntidade
    {
		[Key]
		public decimal OID_DOCUMENTO_PLANO { get; set; }
		public decimal OID_DOCUMENTO { get; set; }
		public int SQ_PLANO_PREVIDENCIAL { get; set; }
        
    }
}
