using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("FI_ENDERECO_PESSOA")]
    public class EnderecoPessoaEntidade
    {
		[Key]
		public int SQ_ENDERECO { get; set; }
		public int CD_PESSOA { get; set; }
		public int? CD_TIPO_ENDERECO { get; set; }
		public string CD_MUNICIPIO { get; set; }
		public string CD_UF { get; set; }
		public string NR_CEP { get; set; }
		public string DS_ENDERECO { get; set; }
		public string NR_ENDERECO { get; set; }
		public string DS_COMPLEMENTO { get; set; }
		public string NO_BAIRRO { get; set; }
		public string NR_FONE { get; set; }
		public string NR_RAMAL { get; set; }
		public string NR_CELULAR { get; set; }
		public string NR_FAX { get; set; }
		public string NO_EMAIL { get; set; }
		public string NO_PAGINA_WEB { get; set; }
		public string IR_RECEB_CORR { get; set; }
		public int? SQ_LOCALIDADE { get; set; }
		public int? SQ_BAIRRO { get; set; }
		public int? SQ_TIPO_LOGRADOURO { get; set; }
		public string EE_RESIDENCIA_PROPRIA { get; set; }
		public string EE_RECURSO_FGTS { get; set; }
		public int? SQ_PAIS { get; set; }
		public string NR_PAIS { get; set; }
		public string IR_CORRESPONDENCIA { get; set; }
        
    }
}
