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
    public abstract class IRRFFaixaCalculoDAO : BaseDAO<IRRFFaixaCalculoEntidade>
    {
        
		public virtual IEnumerable<IRRFFaixaCalculoEntidade> BuscarUltima()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IRRFFaixaCalculoEntidade>("SELECT * FROM FI_IRRF_FAIXA_CALCULO WHERE DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF_FAIXA_CALCULO)", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IRRFFaixaCalculoEntidade>("SELECT * FROM FI_IRRF_FAIXA_CALCULO WHERE DT_INIC_VALIDADE=(SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF_FAIXA_CALCULO)", new {  });
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
