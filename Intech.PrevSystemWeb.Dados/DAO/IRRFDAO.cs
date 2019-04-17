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
    public abstract class IRRFDAO : BaseDAO<IRRFEntidade>
    {
        
		public virtual IRRFEntidade BuscarUltima()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT * FROM FI_IRRF WHERE DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF)", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT * FROM FI_IRRF WHERE DT_INIC_VALIDADE=(SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF)", new {  });
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
