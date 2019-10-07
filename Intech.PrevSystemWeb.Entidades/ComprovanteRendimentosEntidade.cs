using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_COMPROVANTE_RENDIMENTOS")]
    public class ComprovanteRendimentosEntidade
    {
		[Key]
		public int SQ_DECLARACAO { get; set; }
		public int? SQ_EXERCICIO { get; set; }
		public int? SQ_ITEM_DECLARACAO { get; set; }
		public int? SQ_CODIGO { get; set; }
		public int? CD_PESSOA { get; set; }
		public decimal? VL_DECLARACAO { get; set; }
		public string ID_FONTE_GERADORA { get; set; }
		[Write(false)] public decimal? VL_COMPLEMENTAR { get; set; }
		[Write(false)] public string ANO_CALENDARIO { get; set; }
		[Write(false)] public string ANO_EXERCICIO { get; set; }
		[Write(false)] public string CD_RECEITA { get; set; }
		[Write(false)] public string DS_RECEITA { get; set; }
		[Write(false)] public string NR_ITEM_DECLARACAO { get; set; }
		[Write(false)] public string DS_ITEM_DECLARACAO { get; set; }
		[Write(false)] public int NR_POSICAO_COLUNA { get; set; }
		[Write(false)] public string DS_ANO_CALENDARIO { get; set; }
        
    }
}
