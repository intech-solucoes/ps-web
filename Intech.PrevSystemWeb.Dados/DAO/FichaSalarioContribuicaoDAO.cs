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
    public abstract class FichaSalarioContribuicaoDAO : BaseDAO<FichaSalarioContribuicaoEntidade>
    {
        
		public virtual FichaSalarioContribuicaoEntidade BuscarUltimoPorContratoPlano(int SQ_CONTRATO_TRABALHO, int SQ_PLANO_PREVIDENCIAL)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaSalarioContribuicaoEntidade>("SELECT TOP(1) *  FROM FI_FICHA_SALARIO_CONTRIBUICAO WHERE SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO   AND SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL ORDER BY DT_REFERENCIA DESC", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaSalarioContribuicaoEntidade>("SELECT * FROM FI_FICHA_SALARIO_CONTRIBUICAO WHERE SQ_CONTRATO_TRABALHO=:SQ_CONTRATO_TRABALHO AND SQ_PLANO_PREVIDENCIAL=:SQ_PLANO_PREVIDENCIAL AND ROWNUM <= 1  ORDER BY DT_REFERENCIA DESC", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
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
