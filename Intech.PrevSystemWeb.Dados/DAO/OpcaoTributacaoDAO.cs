using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class OpcaoTributacaoDAO : BaseDAO<OpcaoTributacaoEntidade>
	{
		public virtual List<OpcaoTributacaoEntidade> BuscarTodas()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<OpcaoTributacaoEntidade>("SELECT SQ_OPCAO_TRIBUTACAO,  	   DS_OPCAO_TRIBUTACAO  FROM fi_opcao_tributacao  WHERE SQ_OPCAO_TRIBUTACAO <> 2", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<OpcaoTributacaoEntidade>("SELECT SQ_OPCAO_TRIBUTACAO, DS_OPCAO_TRIBUTACAO FROM FI_OPCAO_TRIBUTACAO WHERE SQ_OPCAO_TRIBUTACAO<>2", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

	}
}
