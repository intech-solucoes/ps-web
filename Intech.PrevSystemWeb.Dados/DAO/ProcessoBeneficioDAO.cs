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
    public abstract class ProcessoBeneficioDAO : BaseDAO<ProcessoBeneficioEntidade>
    {
        
		public virtual ProcessoBeneficioEntidade BuscarPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProcessoBeneficioEntidade>("SELECT * FROM FI_PROCESSO_BENEFICIO INNER JOIN FI_RECEBEDOR_BENEFICIO ON FI_RECEBEDOR_BENEFICIO.SQ_PROCESSO = FI_PROCESSO_BENEFICIO.SQ_PROCESSO WHERE FI_RECEBEDOR_BENEFICIO.CD_PESSOA_RECEB = @CD_PESSOA   AND FI_PROCESSO_BENEFICIO.SQ_MOT_SITUACAO = 4;", new { CD_PESSOA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProcessoBeneficioEntidade>("SELECT * FROM FI_PROCESSO_BENEFICIO INNER  JOIN FI_RECEBEDOR_BENEFICIO  ON FI_RECEBEDOR_BENEFICIO.SQ_PROCESSO=FI_PROCESSO_BENEFICIO.SQ_PROCESSO WHERE FI_RECEBEDOR_BENEFICIO.CD_PESSOA_RECEB=:CD_PESSOA AND FI_PROCESSO_BENEFICIO.SQ_MOT_SITUACAO=4", new { CD_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual ProcessoBeneficioEntidade BuscarPorContratoPlano(int SQ_CONTRATO_TRABALHO, int SQ_PLANO_PREVIDENCIAL)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProcessoBeneficioEntidade>("SELECT PB.*,        EB.DS_ESPECIE,        MT.DS_MOT_SITUACAO FROM fi_processo_beneficio PB      INNER JOIN fi_especie_beneficio EB ON EB.SQ_ESPECIE = PB.SQ_ESPECIE      INNER JOIN fi_mot_sit_processo MT ON MT.SQ_MOT_SITUACAO = PB.SQ_MOT_SITUACAO WHERE PB.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL   AND PB.SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProcessoBeneficioEntidade>("SELECT PB.*, EB.DS_ESPECIE, MT.DS_MOT_SITUACAO FROM FI_PROCESSO_BENEFICIO  PB  INNER  JOIN FI_ESPECIE_BENEFICIO   EB  ON EB.SQ_ESPECIE=PB.SQ_ESPECIE INNER  JOIN FI_MOT_SIT_PROCESSO   MT  ON MT.SQ_MOT_SITUACAO=PB.SQ_MOT_SITUACAO WHERE PB.SQ_PLANO_PREVIDENCIAL=:SQ_PLANO_PREVIDENCIAL AND PB.SQ_CONTRATO_TRABALHO=:SQ_CONTRATO_TRABALHO", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
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
