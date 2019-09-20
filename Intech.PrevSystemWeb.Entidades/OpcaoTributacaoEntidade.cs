using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("fi_opcao_tributacao")]
    public class OpcaoTributacaoEntidade
    {
		[Key]
		public int SQ_OPCAO_TRIBUTACAO { get; set; }
		public string DS_OPCAO_TRIBUTACAO { get; set; }
		public int QT_CARENCIA { get; set; }
		public decimal VL_ALIQUOTA { get; set; }
		public int? SQ_RUBRICA_IRPF { get; set; }
        
    }
}
