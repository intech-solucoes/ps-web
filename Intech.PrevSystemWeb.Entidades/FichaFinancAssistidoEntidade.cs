using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_FICHA_FINANC_ASSISTIDO")]
    public class FichaFinancAssistidoEntidade
    {
		[Key]
		public int SQ_FICHA { get; set; }
		public int SQ_PROCESSO { get; set; }
		public int CD_PESSOA_RECEB { get; set; }
		public int? SQ_RUBRICA { get; set; }
		public int? SQ_CRONOGRAMA { get; set; }
		public DateTime DT_COMPETENCIA { get; set; }
		public decimal? VL_CALCULO { get; set; }
		public decimal? VL_COTAS { get; set; }
		public decimal? VL_BASE_CALCULO { get; set; }
		public int? QT_PRAZO { get; set; }
		public int? NR_PARCELA { get; set; }
		public int? QT_PARCELA { get; set; }
		public string IR_LANCAMENTO { get; set; }
		[Write(false)] public string DS_RUBRICA { get; set; }
		[Write(false)] public string DS_LANCAMENTO { get; set; }
		[Write(false)] public string DS_COMPETENCIA { get; set; }
		[Write(false)] public decimal? VAL_BRUTO { get; set; }
		[Write(false)] public decimal? VAL_DESCONTOS { get; set; }
		[Write(false)] public decimal? VAL_LIQUIDO { get; set; }
        
    }
}
