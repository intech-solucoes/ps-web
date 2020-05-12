using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class RecebedorBeneficioDAO : BaseDAO<RecebedorBeneficioEntidade>
	{
		public virtual List<RecebedorBeneficioEntidade> BuscarPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RecebedorBeneficioEntidade>("SELECT * FROM FI_RECEBEDOR_BENEFICIO  WHERE CD_PESSOA_RECEB = @CD_PESSOA", new { CD_PESSOA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RecebedorBeneficioEntidade>("SELECT * FROM FI_RECEBEDOR_BENEFICIO WHERE CD_PESSOA_RECEB=:CD_PESSOA", new { CD_PESSOA }).ToList();
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
