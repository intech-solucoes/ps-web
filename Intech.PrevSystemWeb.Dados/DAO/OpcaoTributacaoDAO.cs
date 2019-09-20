#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystemWeb.Dados.DAO
{   
    public abstract class OpcaoTributacaoDAO : BaseDAO<OpcaoTributacaoEntidade>
    {
        
		public virtual IEnumerable<OpcaoTributacaoEntidade> BuscarTodas()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<OpcaoTributacaoEntidade>("SELECT SQ_OPCAO_TRIBUTACAO,  	   DS_OPCAO_TRIBUTACAO  FROM fi_opcao_tributacao  WHERE SQ_OPCAO_TRIBUTACAO <> 2", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<OpcaoTributacaoEntidade>("SELECT SQ_OPCAO_TRIBUTACAO, DS_OPCAO_TRIBUTACAO FROM FI_OPCAO_TRIBUTACAO WHERE SQ_OPCAO_TRIBUTACAO<>2", new {  });
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
