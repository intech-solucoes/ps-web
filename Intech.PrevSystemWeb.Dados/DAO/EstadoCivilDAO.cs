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
    public abstract class EstadoCivilDAO : BaseDAO<EstadoCivilEntidade>
    {
        
		public virtual IEnumerable<EstadoCivilEntidade> BuscarOrdemAlfabetica()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<EstadoCivilEntidade>("SELECT * FROM fi_estado_civil ORDER BY DS_ESTADO_CIVIL", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<EstadoCivilEntidade>("SELECT * FROM FI_ESTADO_CIVIL ORDER BY DS_ESTADO_CIVIL", new {  });
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
