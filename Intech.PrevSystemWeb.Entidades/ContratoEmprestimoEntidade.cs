using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_CONTRATO_EMPRESTIMO")]
    public class ContratoEmprestimoEntidade
    {
		[Key]
		public int SQ_CONTRATO { get; set; }
		public int? CD_PESSOA { get; set; }
		public int? SQ_AUTORIZACAO { get; set; }
		public int? SQ_MOT_INDEFERIMENTO { get; set; }
		public int? SQ_NATUREZA { get; set; }
		public int? CD_FORMA_PAG { get; set; }
		public int? CD_FINALIDADE { get; set; }
		public string IR_OPCAO_COBRANCA { get; set; }
		public int? SQ_SITUACAO { get; set; }
		public DateTime? DT_SOLICITACAO { get; set; }
		public DateTime? DT_CREDITO { get; set; }
		public decimal? VL_SOLICITADO { get; set; }
		public decimal? VL_LIQUIDO { get; set; }
		public decimal? VL_PRESTACAO { get; set; }
		public decimal? VL_JUROS_AD { get; set; }
		public DateTime? DT_QUITACAO { get; set; }
		public int? SQ_MOT_QUITACAO { get; set; }
		public int? SQ_CONTRATO_QUITACAO { get; set; }
		public decimal? VL_SALDO_QUITACAO { get; set; }
		public decimal? VL_MARGEM_CALCULADA { get; set; }
		public int? QT_PRAZO { get; set; }
		public int? QT_PARCELA_PAGA { get; set; }
		public int? NR_CONTRATO { get; set; }
		public int? NR_ANO_CONTRATO { get; set; }
		public int? SQ_CONTRATO_TRABALHO { get; set; }
		public int? SQ_PLANO_PREVIDENCIAL { get; set; }
		public string IR_TIPO_TABELA { get; set; }
		public int? SQ_CONTA_BANCARIA { get; set; }
		public decimal? VL_CORRECAO { get; set; }
		public decimal? VL_MARGEM_INFORMADA { get; set; }
		public decimal? VL_LIMITE_MAXIMO { get; set; }
		public string CODEMPR { get; set; }
		public string CODLIQ { get; set; }
		public string IDENTEMPR { get; set; }
		public int? CODPES { get; set; }
		public int? SEQ_CONTRATO { get; set; }
		public int? USR_CODIGO { get; set; }
		public DateTime? DT_REQUERIMENTO { get; set; }
		[Write(false)] public string NO_PESSOA { get; set; }
		[Write(false)] public string NR_CPF { get; set; }
		[Write(false)] public string NO_EMPRESA { get; set; }
		[Write(false)] public string NR_REGISTRO { get; set; }
		[Write(false)] public string DS_PLANO_PREVIDENCIAL { get; set; }
		[Write(false)] public string DS_NATUREZA { get; set; }
		[Write(false)] public string DS_SITUACAO { get; set; }
		[Write(false)] public string DS_MOT_QUITACAO { get; set; }
		[Write(false)] public decimal? VL_IOF { get; set; }
		[Write(false)] public List<HistSaldoContratoEntidade> Prestacoes { get; set; }
        
    }
}
