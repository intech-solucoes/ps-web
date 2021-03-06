﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class DocumentoPastaDAO : BaseDAO<DocumentoPastaEntidade>
	{
		public virtual List<DocumentoPastaEntidade> BuscarPorPastaPai(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT *  FROM WEB_DOCUMENTO_PASTA  WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)      OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)", new { OID_DOCUMENTO_PASTA_PAI }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL )", new { OID_DOCUMENTO_PASTA_PAI }).ToList();
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
