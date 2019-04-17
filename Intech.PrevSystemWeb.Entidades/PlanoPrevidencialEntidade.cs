using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_PLANO_PREVIDENCIAL")]
    public class PlanoPrevidencialEntidade
    {
		[Key]
		public int SQ_PLANO_PREVIDENCIAL { get; set; }
		public int CD_PESSOA_ENTID { get; set; }
		public string DS_PLANO_PREVIDENCIAL { get; set; }
		public int? QT_MIN_PARCELA_RESGATE { get; set; }
		public int? QT_MAX_PARCELA_RESGATE { get; set; }
		public int? SQ_PLANO_CONTABIL { get; set; }
		public int? NR_MES_BASE_REAJUSTE { get; set; }
		public string NR_CODIGO_CNPB { get; set; }
		public DateTime? DT_HOMOLOGACAO { get; set; }
		public string DS_HOMOLOGACAO { get; set; }
		public DateTime? DT_INIC_VIGENCIA { get; set; }
		public DateTime? DT_TERM_VIGENCIA { get; set; }
		public string IR_SITUACAO { get; set; }
		public int? SQ_TIPO_REGIME { get; set; }
		public string CD_INDICE_VALORIZACAO { get; set; }
		public string IR_TIPO_PLANO { get; set; }
		public int? SQ_EVENTO_PORTABILIDADE { get; set; }
		public string IR_DIFERENCA { get; set; }
		public decimal? VL_DIFERENCA { get; set; }
		public int? SQ_ESPECIE_EMPRESTIMO { get; set; }
		public int? SQ_ESPECIE_PREVIDENCIA { get; set; }
		public string CD_INDICE_REAJUSTE { get; set; }
		public decimal? VL_TX_MULTA { get; set; }
		public decimal? VL_TX_JUROS { get; set; }
		public string CD_MOEDA_CORR_MONET { get; set; }
		public string IR_TIPO_JUROS { get; set; }
		public string IR_TIPO_CORRECAO { get; set; }
		public string CD_INDICE_CORRECAO { get; set; }
		public int? SQ_ESPECIE_ATUARIAL { get; set; }
		public int? SQ_FUNDO_DESLIG { get; set; }
		public int? SQ_FUNDO_APORTE { get; set; }
		public int? SQ_CONTA_DESLIG { get; set; }
		public int? SQ_CONTA_APORTE { get; set; }
		public int? SQ_BOLETO { get; set; }
		public string IR_NATUREZA { get; set; }
        
    }
}
