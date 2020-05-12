using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class CargoDAO : BaseDAO<CargoEntidade>
	{
		public virtual List<CargoEntidade> BuscarPorCdPessoaPart(int CD_PESSOA_PATR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<CargoEntidade>("SELECT SQ_CARGO,         DS_CARGO   FROM fi_cargo  WHERE CD_PESSOA_PATR = @CD_PESSOA_PATR", new { CD_PESSOA_PATR }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<CargoEntidade>("SELECT SQ_CARGO, DS_CARGO FROM FI_CARGO WHERE CD_PESSOA_PATR=:CD_PESSOA_PATR", new { CD_PESSOA_PATR }).ToList();
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
