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
    public abstract class HistDependentePrevidencialDAO : BaseDAO<HistDependentePrevidencialEntidade>
    {
        
		public virtual IEnumerable<HistDependentePrevidencialEntidade> BuscarPorCdPessoaPlano(int CD_PESSOA, int SQ_PLANO_PREVIDENCIAL)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<HistDependentePrevidencialEntidade>("SELECT HDP.*,      PE.NO_PESSOA,      PF.DT_NASCIMENTO,       GP.DS_GRAU_PARENTESCO,       PF.NR_CPF  FROM fi_hist_dependente_previdencial HDP      INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = HDP.CD_PESSOA_DEP      INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = HDP.CD_PESSOA_DEP      INNER JOIN fi_dependente DP ON DP.CD_PESSOA_DEP = HDP.CD_PESSOA_DEP      INNER JOIN fi_grau_parentesco GP ON GP.CD_GRAU_PARENTESCO = DP.CD_GRAU_PARENTESCO  WHERE HDP.CD_PESSOA = @CD_PESSOA    AND HDP.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL", new { CD_PESSOA, SQ_PLANO_PREVIDENCIAL });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<HistDependentePrevidencialEntidade>("SELECT HDP.*, PE.NO_PESSOA, PF.DT_NASCIMENTO, GP.DS_GRAU_PARENTESCO, PF.NR_CPF FROM FI_HIST_DEPENDENTE_PREVIDENCIAL  HDP  INNER  JOIN FI_PESSOA   PE  ON PE.CD_PESSOA=HDP.CD_PESSOA_DEP INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=HDP.CD_PESSOA_DEP INNER  JOIN FI_DEPENDENTE   DP  ON DP.CD_PESSOA_DEP=HDP.CD_PESSOA_DEP INNER  JOIN FI_GRAU_PARENTESCO   GP  ON GP.CD_GRAU_PARENTESCO=DP.CD_GRAU_PARENTESCO WHERE HDP.CD_PESSOA=:CD_PESSOA AND HDP.SQ_PLANO_PREVIDENCIAL=:SQ_PLANO_PREVIDENCIAL", new { CD_PESSOA, SQ_PLANO_PREVIDENCIAL });
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
