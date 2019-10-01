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
    public abstract class ContratoTrabalhoDAO : BaseDAO<ContratoTrabalhoEntidade>
    {
        
		public virtual IEnumerable<ContratoTrabalhoEntidade> BuscarPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoTrabalhoEntidade>("SELECT CT.*  FROM FI_CONTRATO_TRABALHO CT  INNER JOIN FI_PESSOA_FISICA PF ON PF.CD_PESSOA = CT.CD_PESSOA  WHERE PF.NR_CPF = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoTrabalhoEntidade>("SELECT CT.* FROM FI_CONTRATO_TRABALHO  CT  INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=CT.CD_PESSOA WHERE PF.NR_CPF=:CPF", new { CPF });
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
