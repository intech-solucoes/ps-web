using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class EnderecoPessoaDAO : BaseDAO<EnderecoPessoaEntidade>
	{
		public virtual void AtualizarEmailPorCdPessoa(int CD_PESSOA, string NO_EMAIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE FI_ENDERECO_PESSOA SET NO_EMAIL = @NO_EMAIL WHERE CD_PESSOA = @CD_PESSOA", new { CD_PESSOA, NO_EMAIL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE FI_ENDERECO_PESSOA SET NO_EMAIL=:NO_EMAIL WHERE CD_PESSOA=:CD_PESSOA", new { CD_PESSOA, NO_EMAIL });
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
