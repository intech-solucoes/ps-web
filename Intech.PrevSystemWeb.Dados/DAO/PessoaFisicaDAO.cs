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
    public abstract class PessoaFisicaDAO : BaseDAO<PessoaFisicaEntidade>
    {
        
		public virtual PessoaFisicaEntidade BuscarPorCPF(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*, 	FI_PESSOA.NO_PESSOA FROM FI_PESSOA_FISICA INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA WHERE FI_PESSOA_FISICA.NR_CPF = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*, FI_PESSOA.NO_PESSOA FROM FI_PESSOA_FISICA INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=FI_PESSOA_FISICA.CD_PESSOA WHERE FI_PESSOA_FISICA.NR_CPF=:CPF", new { CPF });
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
