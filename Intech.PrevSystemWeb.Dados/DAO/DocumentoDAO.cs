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
    public abstract class DocumentoDAO : BaseDAO<DocumentoEntidade>
    {
        
		public virtual IEnumerable<DocumentoEntidade> BuscarPorPasta(decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *  FROM WEB_DOCUMENTO  WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)", new { OID_DOCUMENTO_PASTA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO WHERE (OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )", new { OID_DOCUMENTO_PASTA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoEntidade> BuscarPorPlanoPasta(int SQ_PLANO_PREVIDENCIAL, decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.*  FROM WEB_DOCUMENTO  WHERE OID_DOCUMENTO NOT IN (SELECT OID_DOCUMENTO FROM  WEB_DOCUMENTO_PLANO WHERE SQ_PLANO_PREVIDENCIAL <> @SQ_PLANO_PREVIDENCIAL)    AND ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))", new { SQ_PLANO_PREVIDENCIAL, OID_DOCUMENTO_PASTA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.* FROM WEB_DOCUMENTO WHERE OID_DOCUMENTO NOT  IN (SELECT OID_DOCUMENTO FROM WEB_DOCUMENTO_PLANO WHERE SQ_PLANO_PREVIDENCIAL<>:SQ_PLANO_PREVIDENCIAL) AND ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL ))", new { SQ_PLANO_PREVIDENCIAL, OID_DOCUMENTO_PASTA });
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
