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
    public abstract class FichaFinancAssistidoDAO : BaseDAO<FichaFinancAssistidoEntidade>
    {
        
		public virtual FichaFinancAssistidoEntidade BuscarPorProcesso(int SQ_PROCESSO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFinancAssistidoEntidade>("SELECT FF.DT_COMPETENCIA,        FF.SQ_RUBRICA,         RU.DS_RUBRICA,        FF.VL_CALCULO,        CASE             WHEN FF.IR_LANCAMENTO = 'P' THEN 'PROVENTO'             WHEN FF.IR_LANCAMENTO = 'D' THEN 'DESCONTO'        END AS IR_LANCAMENTO FROM fi_ficha_financ_assistido FF      INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA      INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA WHERE FF.SQ_PROCESSO = @SQ_PROCESSO   AND FF.DT_COMPETENCIA = (SELECT MAX(DT_COMPETENCIA)                              FROM fi_ficha_financ_assistido FF2                             WHERE FF2.SQ_PROCESSO = FF.SQ_PROCESSO)   AND RU.IR_LANCAMENTO IN ('P', 'D')   AND RU.EE_INCIDE_LIQUIDO = 'S' ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFinancAssistidoEntidade>("SELECT FF.DT_COMPETENCIA, FF.SQ_RUBRICA, RU.DS_RUBRICA, FF.VL_CALCULO, CASE  WHEN FF.IR_LANCAMENTO='P' THEN 'PROVENTO' WHEN FF.IR_LANCAMENTO='D' THEN 'DESCONTO' END  AS IR_LANCAMENTO FROM FI_FICHA_FINANC_ASSISTIDO  FF  INNER  JOIN FI_RUBRICA_FOLHA_PAGAMENTO   RU  ON RU.SQ_RUBRICA=FF.SQ_RUBRICA INNER  JOIN FI_CRONOGRAMA_CREDITO   CR  ON CR.SQ_CRONOGRAMA=FF.SQ_CRONOGRAMA WHERE FF.SQ_PROCESSO=:SQ_PROCESSO AND FF.DT_COMPETENCIA=(SELECT MAX(DT_COMPETENCIA) FROM FI_FICHA_FINANC_ASSISTIDO  FF2  WHERE FF2.SQ_PROCESSO=FF.SQ_PROCESSO) AND RU.IR_LANCAMENTO IN ('P', 'D') AND RU.EE_INCIDE_LIQUIDO='S' ORDER BY RU.IR_LANCAMENTO DESC", new { SQ_PROCESSO });
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
