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
    public abstract class DocumentoPlanoDAO : BaseDAO<DocumentoPlanoEntidade>
    {
        
		public virtual void DeletarPorOidDocumento(decimal OID_DOCUMENTO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PLANO  WHERE OID_DOCUMENTO = @OID_DOCUMENTO", new { OID_DOCUMENTO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PLANO WHERE OID_DOCUMENTO=:OID_DOCUMENTO", new { OID_DOCUMENTO });
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
