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
        
		public virtual IEnumerable<PessoaFisicaEntidade> BuscarPorCPF(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*,  	FI_PESSOA.NO_PESSOA  FROM FI_PESSOA_FISICA  INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA  WHERE FI_PESSOA_FISICA.NR_CPF = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*, FI_PESSOA.NO_PESSOA FROM FI_PESSOA_FISICA INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=FI_PESSOA_FISICA.CD_PESSOA WHERE FI_PESSOA_FISICA.NR_CPF=:CPF", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PessoaFisicaEntidade> BuscarPorCpfComContrato(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*,  	FI_PESSOA.NO_PESSOA  FROM FI_PESSOA_FISICA  INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA  INNER JOIN FI_CONTRATO_TRABALHO AS CONTRATO ON CONTRATO.CD_PESSOA = FI_PESSOA.CD_PESSOA  WHERE FI_PESSOA_FISICA.NR_CPF = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT FI_PESSOA_FISICA.*, FI_PESSOA.NO_PESSOA FROM FI_PESSOA_FISICA INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=FI_PESSOA_FISICA.CD_PESSOA INNER  JOIN FI_CONTRATO_TRABALHO CONTRATO  ON CONTRATO.CD_PESSOA=FI_PESSOA.CD_PESSOA WHERE FI_PESSOA_FISICA.NR_CPF=:CPF", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PessoaFisicaEntidade> BuscarPorCpfOuNome(string CPF, string NO_PESSOA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT *   FROM FI_PESSOA  INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA  WHERE (FI_PESSOA.NO_PESSOA LIKE '%' + @NO_PESSOA + '%' OR @NO_PESSOA IS NULL)    AND (FI_PESSOA_FISICA.NR_CPF = @CPF OR @CPF IS NULL)", new { CPF, NO_PESSOA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT * FROM FI_PESSOA INNER  JOIN FI_PESSOA_FISICA  ON FI_PESSOA.CD_PESSOA=FI_PESSOA_FISICA.CD_PESSOA WHERE (FI_PESSOA.NO_PESSOA LIKE '%' || :NO_PESSOA || '%' OR :NO_PESSOA IS NULL ) AND (FI_PESSOA_FISICA.NR_CPF=:CPF OR :CPF IS NULL )", new { CPF, NO_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PessoaFisicaEntidade> BuscarPorPesquisa(string CPF, string NO_PESSOA, string MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT *   FROM FI_PESSOA  INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA  INNER JOIN FI_CONTRATO_TRABALHO ON FI_CONTRATO_TRABALHO.CD_PESSOA = FI_PESSOA.CD_PESSOA  WHERE (FI_PESSOA.NO_PESSOA LIKE '%' + @NO_PESSOA + '%' OR @NO_PESSOA IS NULL)    AND (FI_PESSOA_FISICA.NR_CPF = @CPF OR @CPF IS NULL)    AND (FI_CONTRATO_TRABALHO.NR_REGISTRO LIKE '%' + @MATRICULA + '%' OR @MATRICULA IS NULL)", new { CPF, NO_PESSOA, MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PessoaFisicaEntidade>("SELECT * FROM FI_PESSOA INNER  JOIN FI_PESSOA_FISICA  ON FI_PESSOA.CD_PESSOA=FI_PESSOA_FISICA.CD_PESSOA INNER  JOIN FI_CONTRATO_TRABALHO  ON FI_CONTRATO_TRABALHO.CD_PESSOA=FI_PESSOA.CD_PESSOA WHERE (FI_PESSOA.NO_PESSOA LIKE '%' || :NO_PESSOA || '%' OR :NO_PESSOA IS NULL ) AND (FI_PESSOA_FISICA.NR_CPF=:CPF OR :CPF IS NULL ) AND (FI_CONTRATO_TRABALHO.NR_REGISTRO LIKE '%' || :MATRICULA || '%' OR :MATRICULA IS NULL )", new { CPF, NO_PESSOA, MATRICULA });
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
