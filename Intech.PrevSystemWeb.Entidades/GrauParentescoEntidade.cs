using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("fi_grau_parentesco")]
    public class GrauParentescoEntidade
    {
		[Key]
		public int CD_GRAU_PARENTESCO { get; set; }
		public string DS_GRAU_PARENTESCO { get; set; }
		public string IR_NATUREZA_FAMILIAR { get; set; }
		public int QT_ANOS_VALIDADE { get; set; }
		public int? QT_PRAZO_CARENCIA { get; set; }
		public string IR_TIPO_VALIDADE { get; set; }
		public string IR_TIPO_CARENCIA { get; set; }
		public string IR_INVALIDEZ { get; set; }
		public string CD_GRAU_SIB { get; set; }
		public string CD_GRAU_EFOLHA { get; set; }
		public string EE_BENEFICIARIO { get; set; }
		public string EE_DESIGNADO { get; set; }
        
    }
}
