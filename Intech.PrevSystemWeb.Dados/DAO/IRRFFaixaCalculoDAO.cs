using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class IRRFFaixaCalculoDAO : BaseDAO<IRRFFaixaCalculoEntidade>
	{
		public virtual List<IRRFFaixaCalculoEntidade> BuscarUltima()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IRRFFaixaCalculoEntidade>("SELECT * FROM FI_IRRF_FAIXA_CALCULO  WHERE DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF_FAIXA_CALCULO)", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IRRFFaixaCalculoEntidade>("SELECT * FROM FI_IRRF_FAIXA_CALCULO WHERE DT_INIC_VALIDADE=(SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF_FAIXA_CALCULO)", new {  }).ToList();
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
