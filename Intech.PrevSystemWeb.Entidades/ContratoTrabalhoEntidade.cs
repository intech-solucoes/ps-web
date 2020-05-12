﻿using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
	[Table("FI_CONTRATO_TRABALHO")]
	public class ContratoTrabalhoEntidade
	{
		[Key]
		public int SQ_CONTRATO_TRABALHO { get; set; }
		public int CD_PESSOA { get; set; }
		public int CD_PESSOA_PATR { get; set; }
		public int? CD_PESSOA_REPR { get; set; }
		public int? SQ_MOTIVO_DEMISSAO { get; set; }
		public string NR_REGISTRO { get; set; }
		public int? SQ_GRUPO_RISCO { get; set; }
		public int SQ_MOTIVO_ADMISSAO { get; set; }
		public int SQ_TIPO_ADMISSAO { get; set; }
		public int SQ_TIPO_FUNCIONARIO { get; set; }
		public DateTime? DT_ADMISSAO { get; set; }
		public DateTime? DT_APOSENTADORIA { get; set; }
		public DateTime? DT_DEMISSAO { get; set; }
		public string EE_APOSENTADO { get; set; }
		public int? SQ_SITUACAO { get; set; }
		public DateTime? DT_SITUACAO { get; set; }
		public int? IR_TIPO_ADMISSAO { get; set; }
		public int? IR_INDICATIVO_ADMISSAO { get; set; }
		public string EE_PRIMEIRO_EMPREGO { get; set; }
		public int? IR_TIPO_REGIME_TRABALHISTA { get; set; }
		public int? IR_TIPO_REGIME_PREVIDENCIARIO { get; set; }
		public int? IR_NATUREZA_ATIVIDADE { get; set; }
		public int? SQ_CATEGORIA_TRABALHADOR { get; set; }
		public int? IR_TIPO_CONTRATO { get; set; }
		public int? IR_EXPOSICAO_AGENTE_NOCIVO { get; set; }
	}
}
