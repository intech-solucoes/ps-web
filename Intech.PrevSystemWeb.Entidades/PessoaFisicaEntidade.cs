using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_PESSOA_FISICA")]
    public class PessoaFisicaEntidade
    {
		public int CD_PESSOA { get; set; }
		public int? CD_ESTADO_CIVIL { get; set; }
		public int? CD_GRAU_INSTRUCAO { get; set; }
		public int? CD_SIT_FAMILIAR { get; set; }
		public int? CD_OCUPACAO { get; set; }
		public int? CD_TIPO_RACA_COR { get; set; }
		public string IR_SEXO { get; set; }
		public string CD_UF { get; set; }
		public int? CD_NACIONALIDADE { get; set; }
		public string NR_CPF { get; set; }
		public DateTime? DT_NASCIMENTO { get; set; }
		public string NO_MAE { get; set; }
		public string NO_PAI { get; set; }
		public int? SQ_DEFICIENCIA { get; set; }
		public string NO_NATURALIDADE { get; set; }
		public string EE_POLITICAMENTE_EXPOSTO { get; set; }
		public DateTime? DT_COMPROVACAO { get; set; }
		public DateTime? DT_NATURALIZACAO { get; set; }
		public string DS_GRUPO_SANGUINEO { get; set; }
		public string NR_CARTAO_SAUDE { get; set; }
		public DateTime? dt_recadastramento { get; set; }
		public int? SQ_PAIS_NASCIMENTO { get; set; }
		public int? SQ_PAIS_NACIONALIDADE { get; set; }
		public string CD_MUNICIPIO { get; set; }
		public string EE_DEF_MOTORA { get; set; }
		public string EE_DEF_VISUAL { get; set; }
		public string EE_DEF_AUDITIVA { get; set; }
		public string EE_REABILITADO { get; set; }
		public string DS_OBSERVACAO_DEF_MOT { get; set; }
		public string NR_NIF { get; set; }
		public string NR_PAIS_NIF { get; set; }
		public string NR_PAIS_NACIONALIDADE { get; set; }
		public string EE_US_PERSON { get; set; }
		[Write(false)] public string NO_PESSOA { get; set; }
        
    }
}
