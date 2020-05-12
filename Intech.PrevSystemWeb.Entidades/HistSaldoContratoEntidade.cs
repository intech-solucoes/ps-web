using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_HIST_SALDO_CONTRATO")]
	public class HistSaldoContratoEntidade
	{
		[Key]
		public int SQ_HISTORICO { get; set; }
		public int SQ_CONTRATO { get; set; }
		public DateTime DT_VENCIMENTO { get; set; }
		public string IR_ORIGEM_PAGTO { get; set; }
		public DateTime? DT_PAGAMENTO { get; set; }
		public int? NR_PARCELA { get; set; }
		public decimal? VL_COBRANCA { get; set; }
		public decimal? VL_DESCONTO { get; set; }
		public decimal? VL_RECEBIDO { get; set; }
		public decimal? VL_SALDO { get; set; }
		public decimal? VL_AMORTIZADO { get; set; }
		public decimal? VL_CORRECAO { get; set; }
		public string IR_OPERACAO { get; set; }
		public decimal? VL_TAXA { get; set; }
		public DateTime? DT_OPERACAO { get; set; }
		public string codmov { get; set; }
		public string CODFORMA { get; set; }
		public decimal? VL_JUROS { get; set; }
		public decimal? VL_SALDO_ANTERIOR { get; set; }
	}
}
