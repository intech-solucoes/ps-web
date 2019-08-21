using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_CONTRATO_TRABALHO")]
    public class DadosPessoaisEntidade
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
		public int? SQ_MIGRACAO { get; set; }
		[Write(false)] public string NO_PESSOA { get; set; }
		[Write(false)] public string IR_SEXO { get; set; }
		[Write(false)] public string DS_SEXO { get; set; }
		[Write(false)] public DateTime? DT_NASCIMENTO { get; set; }
		[Write(false)] public string NR_CPF { get; set; }
		[Write(false)] public string SIGLA_EMPRESA { get; set; }
		[Write(false)] public string NR_CEP { get; set; }
		[Write(false)] public string DS_ENDERECO { get; set; }
		[Write(false)] public string NR_ENDERECO { get; set; }
		[Write(false)] public string DS_COMPLEMENTO { get; set; }
		[Write(false)] public string NO_BAIRRO { get; set; }
		[Write(false)] public string NR_FONE { get; set; }
		[Write(false)] public string NR_CELULAR { get; set; }
		[Write(false)] public string NO_EMAIL { get; set; }
		[Write(false)] public string NO_EMPRESA { get; set; }
		[Write(false)] public string NO_MAE { get; set; }
		[Write(false)] public string NO_PAI { get; set; }
		[Write(false)] public string NO_NATURALIDADE { get; set; }
		[Write(false)] public string EE_POLITICAMENTE_EXPOSTO { get; set; }
		[Write(false)] public string EE_US_PERSON { get; set; }
		[Write(false)] public string CD_ESTADO_CIVIL { get; set; }
		[Write(false)] public string DS_ESTADO_CIVIL { get; set; }
		[Write(false)] public string CD_GRAU_INSTRUCAO { get; set; }
		[Write(false)] public string DS_GRAU_INSTRUCAO { get; set; }
		[Write(false)] public int? SQ_PAIS_NACIONALIDADE { get; set; }
		[Write(false)] public string NO_PAIS_NACIONALIDADE { get; set; }
		[Write(false)] public string CD_BANCO { get; set; }
		[Write(false)] public string NO_BANCO { get; set; }
		[Write(false)] public string CD_AGENCIA { get; set; }
		[Write(false)] public string DV_AGENCIA { get; set; }
		[Write(false)] public string NR_CC { get; set; }
		[Write(false)] public string DV_CC { get; set; }
		[Write(false)] public int? SQ_ENDERECO { get; set; }
		[Write(false)] public string CD_TIPO_ENDERECO { get; set; }
		[Write(false)] public string DS_TIPO_ENDERECO { get; set; }
		[Write(false)] public string CD_MUNICIPIO { get; set; }
		[Write(false)] public string DS_MUNICIPIO { get; set; }
		[Write(false)] public string CD_UF { get; set; }
		[Write(false)] public int? SQ_TIPO_LOGRADOURO { get; set; }
		[Write(false)] public string NO_TIPO_LOGRADOURO { get; set; }
        
    }
}
