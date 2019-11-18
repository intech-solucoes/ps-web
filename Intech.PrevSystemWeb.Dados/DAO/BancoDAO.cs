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
    public abstract class BancoDAO : BaseDAO<BancoEntidade>
    {
        
		public virtual IEnumerable<BancoEntidade> BuscarOrdemAlfabetica()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BancoEntidade>("SELECT * FROM fi_banco ORDER BY NO_BANCO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BancoEntidade>("SELECT * FROM FI_BANCO ORDER BY NO_BANCO", new {  });
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
