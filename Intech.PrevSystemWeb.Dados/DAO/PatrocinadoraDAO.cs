﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystemWeb.Dados.DAO
{
	public abstract class PatrocinadoraDAO : BaseDAO<PatrocinadoraEntidade>
	{
		public virtual List<PatrocinadoraEntidade> BuscarTodas()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PatrocinadoraEntidade>("SELECT   	FI_PATROCINADORA.*,   	FI_PESSOA.NO_PESSOA  FROM FI_PATROCINADORA  INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_PATROCINADORA.CD_PESSOA_PATR", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PatrocinadoraEntidade>("SELECT FI_PATROCINADORA.*, FI_PESSOA.NO_PESSOA FROM FI_PATROCINADORA INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=FI_PATROCINADORA.CD_PESSOA_PATR", new {  }).ToList();
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
