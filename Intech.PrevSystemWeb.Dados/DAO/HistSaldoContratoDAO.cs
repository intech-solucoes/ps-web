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
    public abstract class HistSaldoContratoDAO : BaseDAO<HistSaldoContratoEntidade>
    {
        
		public virtual IEnumerable<HistSaldoContratoEntidade> BuscarPorSqContrato(int SQ_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<HistSaldoContratoEntidade>("SELECT * FROM fi_hist_saldo_contrato WHERE SQ_CONTRATO = @SQ_CONTRATO ORDER BY DT_VENCIMENTO", new { SQ_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<HistSaldoContratoEntidade>("SELECT * FROM FI_HIST_SALDO_CONTRATO WHERE SQ_CONTRATO=:SQ_CONTRATO ORDER BY DT_VENCIMENTO", new { SQ_CONTRATO });
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
