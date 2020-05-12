using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class FichaFinancAssistidoDAO : BaseDAO<FichaFinancAssistidoEntidade>
	{
		public virtual List<FichaFinancAssistidoEntidade> BuscarDatasPorProcesso(int SQ_PROCESSO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT DISTINCT CR.DT_REFERENCIA,      FF.SQ_PROCESSO  FROM fi_ficha_financ_assistido FF       INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA       INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA  WHERE FF.SQ_PROCESSO = @SQ_PROCESSO    AND RU.IR_LANCAMENTO IN ('P', 'D')    AND RU.EE_INCIDE_LIQUIDO = 'S'  ORDER BY CR.DT_REFERENCIA DESC", new { SQ_PROCESSO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT DISTINCT CR.DT_REFERENCIA, FF.SQ_PROCESSO FROM FI_FICHA_FINANC_ASSISTIDO  FF  INNER  JOIN FI_RUBRICA_FOLHA_PAGAMENTO   RU  ON RU.SQ_RUBRICA=FF.SQ_RUBRICA INNER  JOIN FI_CRONOGRAMA_CREDITO   CR  ON CR.SQ_CRONOGRAMA=FF.SQ_CRONOGRAMA WHERE FF.SQ_PROCESSO=:SQ_PROCESSO AND RU.IR_LANCAMENTO IN ('P', 'D') AND RU.EE_INCIDE_LIQUIDO='S' ORDER BY CR.DT_REFERENCIA DESC", new { SQ_PROCESSO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<FichaFinancAssistidoEntidade> BuscarPorProcessoReferencia(int SQ_PROCESSO, DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT FF.*,         CR.DT_REFERENCIA,  	   CR.DT_CREDITO,         RU.DS_RUBRICA,         RU.CD_RUBRICA,         CASE              WHEN FF.IR_LANCAMENTO = 'P' THEN 'PROVENTO'              WHEN FF.IR_LANCAMENTO = 'D' THEN 'DESCONTO'         END AS DS_LANCAMENTO  FROM fi_ficha_financ_assistido FF       INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA       INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA  WHERE FF.SQ_PROCESSO = @SQ_PROCESSO    AND CR.DT_REFERENCIA = @DT_REFERENCIA    AND RU.IR_LANCAMENTO IN ('P', 'D')    AND RU.EE_INCIDE_LIQUIDO = 'S'  ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO, DT_REFERENCIA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT FF.*, CR.DT_REFERENCIA, CR.DT_CREDITO, RU.DS_RUBRICA, RU.CD_RUBRICA, CASE  WHEN FF.IR_LANCAMENTO='P' THEN 'PROVENTO' WHEN FF.IR_LANCAMENTO='D' THEN 'DESCONTO' END  AS DS_LANCAMENTO FROM FI_FICHA_FINANC_ASSISTIDO  FF  INNER  JOIN FI_RUBRICA_FOLHA_PAGAMENTO   RU  ON RU.SQ_RUBRICA=FF.SQ_RUBRICA INNER  JOIN FI_CRONOGRAMA_CREDITO   CR  ON CR.SQ_CRONOGRAMA=FF.SQ_CRONOGRAMA WHERE FF.SQ_PROCESSO=:SQ_PROCESSO AND CR.DT_REFERENCIA=:DT_REFERENCIA AND RU.IR_LANCAMENTO IN ('P', 'D') AND RU.EE_INCIDE_LIQUIDO='S' ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO, DT_REFERENCIA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<FichaFinancAssistidoEntidade> BuscarUltimaPorProcesso(int SQ_PROCESSO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT FF.*,         RU.DS_RUBRICA,         CASE              WHEN FF.IR_LANCAMENTO = 'P' THEN 'PROVENTO'              WHEN FF.IR_LANCAMENTO = 'D' THEN 'DESCONTO'         END AS DS_LANCAMENTO  FROM fi_ficha_financ_assistido FF       INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA       INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA  WHERE FF.SQ_PROCESSO = @SQ_PROCESSO    AND FF.DT_COMPETENCIA = (SELECT MAX(DT_COMPETENCIA)                               FROM fi_ficha_financ_assistido FF2                              WHERE FF2.SQ_PROCESSO = FF.SQ_PROCESSO)    AND RU.IR_LANCAMENTO IN ('P', 'D')    AND RU.EE_INCIDE_LIQUIDO = 'S'  ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinancAssistidoEntidade>("SELECT FF.*, RU.DS_RUBRICA, CASE  WHEN FF.IR_LANCAMENTO='P' THEN 'PROVENTO' WHEN FF.IR_LANCAMENTO='D' THEN 'DESCONTO' END  AS DS_LANCAMENTO FROM FI_FICHA_FINANC_ASSISTIDO  FF  INNER  JOIN FI_RUBRICA_FOLHA_PAGAMENTO   RU  ON RU.SQ_RUBRICA=FF.SQ_RUBRICA INNER  JOIN FI_CRONOGRAMA_CREDITO   CR  ON CR.SQ_CRONOGRAMA=FF.SQ_CRONOGRAMA WHERE FF.SQ_PROCESSO=:SQ_PROCESSO AND FF.DT_COMPETENCIA=(SELECT MAX(DT_COMPETENCIA) FROM FI_FICHA_FINANC_ASSISTIDO  FF2  WHERE FF2.SQ_PROCESSO=FF.SQ_PROCESSO) AND RU.IR_LANCAMENTO IN ('P', 'D') AND RU.EE_INCIDE_LIQUIDO='S' ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO }).ToList();
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
