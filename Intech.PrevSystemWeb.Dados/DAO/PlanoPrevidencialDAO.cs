using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class PlanoPrevidencialDAO : BaseDAO<PlanoPrevidencialEntidade>
	{
		public virtual PlanoPrevidencialEntidade BuscarPorPlano(int SQ_PLANO_PREVIDENCIAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoPrevidencialEntidade>("SELECT *  FROM FI_PLANO_PREVIDENCIAL  WHERE SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL", new { SQ_PLANO_PREVIDENCIAL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoPrevidencialEntidade>("SELECT * FROM FI_PLANO_PREVIDENCIAL WHERE SQ_PLANO_PREVIDENCIAL=:SQ_PLANO_PREVIDENCIAL", new { SQ_PLANO_PREVIDENCIAL });
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
