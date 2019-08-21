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
    public abstract class HistEncargoContratoDAO : BaseDAO<HistEncargoContratoEntidade>
    {
        
		public virtual HistEncargoContratoEntidade BuscarPorSqContrato(int SQ_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<HistEncargoContratoEntidade>("SELECT TOP 1 *   FROM fi_hist_encargo_contrato HEC      INNER JOIN fi_tipo_encargo TE ON TE.SQ_TIPO_ENCARGO = HEC.SQ_TIPO_ENCARGO  WHERE SQ_CONTRATO = @SQ_CONTRATO    AND HEC.SQ_TIPO_ENCARGO = 8  ORDER BY DT_VENCIMENTO", new { SQ_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<HistEncargoContratoEntidade>("SELECT * FROM FI_HIST_ENCARGO_CONTRATO  HEC  INNER  JOIN FI_TIPO_ENCARGO   TE  ON TE.SQ_TIPO_ENCARGO=HEC.SQ_TIPO_ENCARGO WHERE SQ_CONTRATO=:SQ_CONTRATO AND HEC.SQ_TIPO_ENCARGO=8 AND ROWNUM <= 1  ORDER BY DT_VENCIMENTO", new { SQ_CONTRATO });
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
