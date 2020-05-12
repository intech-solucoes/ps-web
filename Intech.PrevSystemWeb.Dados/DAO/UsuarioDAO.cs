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
    public abstract class UsuarioDAO : BaseDAO<UsuarioEntidade>
    {
        
		public virtual void Atualizar(int USR_CODIGO, string USR_LOGIN, string USR_SENHA, string USR_ADMINISTRADOR, string USR_TIPO_EXPIRACAO, string USR_NOME, string USR_EMAIL, int CD_PESSOA, string EE_TERMO_RESPONSABILIDADE, int CD_PESSOA_CLIENTE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE FR_USUARIO   SET USR_CODIGO = @USR_CODIGO,      USR_LOGIN = @USR_LOGIN,      USR_SENHA = @USR_SENHA,      USR_ADMINISTRADOR = @USR_ADMINISTRADOR,      USR_TIPO_EXPIRACAO = @USR_TIPO_EXPIRACAO,      USR_NOME = @USR_NOME,      USR_EMAIL = @USR_EMAIL,      CD_PESSOA = @CD_PESSOA,      EE_TERMO_RESPONSABILIDADE = @EE_TERMO_RESPONSABILIDADE,      CD_PESSOA_CLIENTE = @CD_PESSOA_CLIENTE  WHERE USR_CODIGO = @USR_CODIGO", new { USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE FR_USUARIO SET USR_CODIGO=:USR_CODIGO, USR_LOGIN=:USR_LOGIN, USR_SENHA=:USR_SENHA, USR_ADMINISTRADOR=:USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO=:USR_TIPO_EXPIRACAO, USR_NOME=:USR_NOME, USR_EMAIL=:USR_EMAIL, CD_PESSOA=:CD_PESSOA, EE_TERMO_RESPONSABILIDADE=:EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE=:CD_PESSOA_CLIENTE WHERE USR_CODIGO=:USR_CODIGO", new { USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual UsuarioEntidade BuscarPorCPF(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM FR_USUARIO  WHERE USR_LOGIN = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM FR_USUARIO WHERE USR_LOGIN=:CPF", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual UsuarioEntidade BuscarPorLoginSenha(string USR_LOGIN, string USR_SENHA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT *  FROM FR_USUARIO  WHERE USR_LOGIN = @USR_LOGIN    AND USR_SENHA = @USR_SENHA", new { USR_LOGIN, USR_SENHA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM FR_USUARIO WHERE USR_LOGIN=:USR_LOGIN AND USR_SENHA=:USR_SENHA", new { USR_LOGIN, USR_SENHA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual int BuscarProximoCodigo()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT TOP 1    (0 + USR_CODIGO + 1)  FROM FR_USUARIO  ORDER BY USR_CODIGO DESC", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT (0 + USR_CODIGO + 1) FROM FR_USUARIO WHERE ROWNUM <= 1  ORDER BY USR_CODIGO DESC", new {  });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual void Inserir(int USR_CODIGO, string USR_LOGIN, string USR_SENHA, string USR_ADMINISTRADOR, string USR_TIPO_EXPIRACAO, string USR_NOME, string USR_EMAIL, int CD_PESSOA, string EE_TERMO_RESPONSABILIDADE, int CD_PESSOA_CLIENTE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO FR_USUARIO(USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE)  VALUES (@USR_CODIGO, @USR_LOGIN, @USR_SENHA, @USR_ADMINISTRADOR, @USR_TIPO_EXPIRACAO, @USR_NOME, @USR_EMAIL, @CD_PESSOA, @EE_TERMO_RESPONSABILIDADE, @CD_PESSOA_CLIENTE)", new { USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO FR_USUARIO (OID_SUARIO,USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE) VALUES (S_FR_USUARIO.NEXTVAL,:USR_CODIGO, :USR_LOGIN, :USR_SENHA, :USR_ADMINISTRADOR, :USR_TIPO_EXPIRACAO, :USR_NOME, :USR_EMAIL, :CD_PESSOA, :EE_TERMO_RESPONSABILIDADE, :CD_PESSOA_CLIENTE) RETURNING OID_SUARIO INTO :PK", new { USR_CODIGO, USR_LOGIN, USR_SENHA, USR_ADMINISTRADOR, USR_TIPO_EXPIRACAO, USR_NOME, USR_EMAIL, CD_PESSOA, EE_TERMO_RESPONSABILIDADE, CD_PESSOA_CLIENTE });
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
