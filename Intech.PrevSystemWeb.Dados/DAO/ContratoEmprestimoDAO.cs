﻿#region Usings
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
    public abstract class ContratoEmprestimoDAO : BaseDAO<ContratoEmprestimoEntidade>
    {
        
		public virtual IEnumerable<ContratoEmprestimoEntidade> BuscarPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEmprestimoEntidade>("SELECT CE.*,         PE.NO_PESSOA,    	   PF.NR_CPF,         EM.NO_PESSOA AS NO_EMPRESA,         CT.NR_REGISTRO,         PL.DS_PLANO_PREVIDENCIAL,         NA.DS_NATUREZA,         ST.DS_SITUACAO,         MQ.DS_MOT_QUITACAO  FROM fi_contrato_emprestimo CE      INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = CE.CD_PESSOA      INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = CE.CD_PESSOA      INNER JOIN fi_natureza_emprestimo NA ON NA.SQ_NATUREZA = CE.SQ_NATUREZA      INNER JOIN fi_situacao_emprestimo ST ON ST.SQ_SITUACAO = CE.SQ_SITUACAO      INNER JOIN fi_contrato_trabalho CT ON CT.SQ_CONTRATO_TRABALHO = CE.SQ_CONTRATO_TRABALHO      INNER JOIN fi_pessoa EM ON EM.CD_PESSOA = CT.CD_PESSOA_PATR      INNER JOIN fi_plano_previdencial PL ON PL.SQ_PLANO_PREVIDENCIAL = CE.SQ_PLANO_PREVIDENCIAL      LEFT OUTER JOIN fi_motivo_quitacao MQ ON MQ.SQ_MOT_QUITACAO = CE.SQ_MOT_QUITACAO  WHERE CE.CD_PESSOA = @CD_PESSOA  ORDER BY CE.DT_CREDITO DESC", new { CD_PESSOA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEmprestimoEntidade>("SELECT CE.*, PE.NO_PESSOA, PF.NR_CPF, EM.NO_PESSOA AS NO_EMPRESA, CT.NR_REGISTRO, PL.DS_PLANO_PREVIDENCIAL, NA.DS_NATUREZA, ST.DS_SITUACAO, MQ.DS_MOT_QUITACAO FROM FI_CONTRATO_EMPRESTIMO  CE  INNER  JOIN FI_PESSOA   PE  ON PE.CD_PESSOA=CE.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=CE.CD_PESSOA INNER  JOIN FI_NATUREZA_EMPRESTIMO   NA  ON NA.SQ_NATUREZA=CE.SQ_NATUREZA INNER  JOIN FI_SITUACAO_EMPRESTIMO   ST  ON ST.SQ_SITUACAO=CE.SQ_SITUACAO INNER  JOIN FI_CONTRATO_TRABALHO   CT  ON CT.SQ_CONTRATO_TRABALHO=CE.SQ_CONTRATO_TRABALHO INNER  JOIN FI_PESSOA   EM  ON EM.CD_PESSOA=CT.CD_PESSOA_PATR INNER  JOIN FI_PLANO_PREVIDENCIAL   PL  ON PL.SQ_PLANO_PREVIDENCIAL=CE.SQ_PLANO_PREVIDENCIAL LEFT OUTER JOIN FI_MOTIVO_QUITACAO   MQ  ON MQ.SQ_MOT_QUITACAO=CE.SQ_MOT_QUITACAO WHERE CE.CD_PESSOA=:CD_PESSOA ORDER BY CE.DT_CREDITO DESC", new { CD_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual ContratoEmprestimoEntidade BuscarPorSqContrato(int SQ_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEmprestimoEntidade>("SELECT CE.*,         PE.NO_PESSOA,    	   PF.NR_CPF,         EM.NO_PESSOA AS NO_EMPRESA,         CT.NR_REGISTRO,         PL.DS_PLANO_PREVIDENCIAL,         NA.DS_NATUREZA,         ST.DS_SITUACAO,         MQ.DS_MOT_QUITACAO  FROM fi_contrato_emprestimo CE      INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = CE.CD_PESSOA      INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = CE.CD_PESSOA      INNER JOIN fi_natureza_emprestimo NA ON NA.SQ_NATUREZA = CE.SQ_NATUREZA      INNER JOIN fi_situacao_emprestimo ST ON ST.SQ_SITUACAO = CE.SQ_SITUACAO      INNER JOIN fi_contrato_trabalho CT ON CT.SQ_CONTRATO_TRABALHO = CE.SQ_CONTRATO_TRABALHO      INNER JOIN fi_pessoa EM ON EM.CD_PESSOA = CT.CD_PESSOA_PATR      INNER JOIN fi_plano_previdencial PL ON PL.SQ_PLANO_PREVIDENCIAL = CE.SQ_PLANO_PREVIDENCIAL      LEFT OUTER JOIN fi_motivo_quitacao MQ ON MQ.SQ_MOT_QUITACAO = CE.SQ_MOT_QUITACAO  WHERE CE.SQ_CONTRATO = @SQ_CONTRATO", new { SQ_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEmprestimoEntidade>("SELECT CE.*, PE.NO_PESSOA, PF.NR_CPF, EM.NO_PESSOA AS NO_EMPRESA, CT.NR_REGISTRO, PL.DS_PLANO_PREVIDENCIAL, NA.DS_NATUREZA, ST.DS_SITUACAO, MQ.DS_MOT_QUITACAO FROM FI_CONTRATO_EMPRESTIMO  CE  INNER  JOIN FI_PESSOA   PE  ON PE.CD_PESSOA=CE.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=CE.CD_PESSOA INNER  JOIN FI_NATUREZA_EMPRESTIMO   NA  ON NA.SQ_NATUREZA=CE.SQ_NATUREZA INNER  JOIN FI_SITUACAO_EMPRESTIMO   ST  ON ST.SQ_SITUACAO=CE.SQ_SITUACAO INNER  JOIN FI_CONTRATO_TRABALHO   CT  ON CT.SQ_CONTRATO_TRABALHO=CE.SQ_CONTRATO_TRABALHO INNER  JOIN FI_PESSOA   EM  ON EM.CD_PESSOA=CT.CD_PESSOA_PATR INNER  JOIN FI_PLANO_PREVIDENCIAL   PL  ON PL.SQ_PLANO_PREVIDENCIAL=CE.SQ_PLANO_PREVIDENCIAL LEFT OUTER JOIN FI_MOTIVO_QUITACAO   MQ  ON MQ.SQ_MOT_QUITACAO=CE.SQ_MOT_QUITACAO WHERE CE.SQ_CONTRATO=:SQ_CONTRATO", new { SQ_CONTRATO });
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