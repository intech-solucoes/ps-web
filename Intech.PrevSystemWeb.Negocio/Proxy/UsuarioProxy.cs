#region Usings
using Intech.Lib.Dominios;
using Intech.Lib.Email;
using Intech.Lib.Util.Validacoes;
using Intech.Lib.Web;
using Intech.PrevSystemWeb.Dados.DAO;
using Intech.PrevSystemWeb.Entidades;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Intech.PrevSystemWeb.Negocio.Proxy
{
    public class UsuarioProxy : UsuarioDAO
    {
        private Exception ExceptionDadosInvalidos => new Exception("Dados inválidos!");

        public override UsuarioEntidade BuscarPorLoginSenha(string USR_LOGIN, string USR_SENHA)
        {
            // Busca usuario existente para utilizar o USR_CODIGO
            var user = base.BuscarPorCPF(USR_LOGIN);

            if (user == null)
                return null;

            // Concatena o USR_CODIGO com a senha e encripta utilizando MD5
            var senha = GerarHashMd5(user.USR_CODIGO + USR_SENHA);

            return base.BuscarPorLoginSenha(USR_LOGIN, senha);
        }

        private string GerarHashMd5(string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public string CriarAcesso(string cpf, DateTime dataNascimento)
        {
            cpf = cpf.LimparMascara();

            var pensionista = false;

            var pessoaFisica = new PessoaFisicaProxy().BuscarPorCpfComContrato(cpf).FirstOrDefault();

            if (pessoaFisica == null)
                throw ExceptionDadosInvalidos;

            if (pessoaFisica.DT_NASCIMENTO != dataNascimento)
                throw ExceptionDadosInvalidos;

            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCdPessoa(pessoaFisica.CD_PESSOA);

            if (dadosPessoais == null)
            {
                pensionista = true;
                dadosPessoais = new DadosPessoaisProxy().BuscarPensionistaTodosPorCdPessoa(pessoaFisica.CD_PESSOA).First();
            }

            var senha = new Random().Next(999999).ToString();

            // Verifica se existe usuário. Caso sim, atualiza a senha. Caso não, cria novo usuário.
            var usuarioExistente = BuscarPorCPF(cpf);

            if (usuarioExistente != null)
            {
                var senhaEncriptada = GerarHashMd5(usuarioExistente.USR_CODIGO + senha);
                
                Atualizar(USR_CODIGO: usuarioExistente.USR_CODIGO,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL,
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);
            }
            else
            {
                var proximoCodigo = BuscarProximoCodigo();

                var senhaEncriptada = GerarHashMd5(proximoCodigo + senha);

                Inserir(USR_CODIGO: proximoCodigo,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL,
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);

                if (pensionista)
                {
                    new UsuarioGrupoProxy().Inserir(new UsuarioGrupoEntidade
                    {
                        GRP_CODIGO = 32,
                        SIS_CODIGO = "PWA",
                        USR_CODIGO = proximoCodigo
                    });
                }
            }

            // Envia e-mail com nova senha de acesso
            var config = AppSettings.Get();
            
            EnvioEmail.Enviar(config.Email, dadosPessoais.NO_EMAIL, $"{config.Cliente} - Nova senha de acesso", $"Esta é sua nova senha da {config.Cliente}: {senha}");

            return "Sua nova senha foi enviada para seu e-mail!";
        }

        public string CriarAcessoComEmail(string cpf, DateTime dataNascimento, string email)
        {
            cpf = cpf.LimparMascara();

            if (!Validador.ValidarEmail(email))
                throw new Exception("E-mail em formato inválido.");

            var pensionista = false;

            var pessoaFisica = new PessoaFisicaProxy().BuscarPorCPF(cpf).FirstOrDefault();

            if (pessoaFisica == null)
                throw ExceptionDadosInvalidos;

            if (pessoaFisica.DT_NASCIMENTO != dataNascimento)
                throw ExceptionDadosInvalidos;

            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCdPessoa(pessoaFisica.CD_PESSOA);

            if (dadosPessoais == null)
            {
                pensionista = true;
                dadosPessoais = new DadosPessoaisProxy().BuscarPensionistaTodosPorCdPessoa(pessoaFisica.CD_PESSOA).First();
            }

            if (!string.IsNullOrEmpty(dadosPessoais.NO_EMAIL.Trim()) && email != dadosPessoais.NO_EMAIL.Trim())
                throw new Exception("O e-mail digitado não coincide com o e-mail registrado em nosso cadastro. Favor entrar em contato com a EqtPrev.");

            var senha = new Random().Next(999999).ToString();

            // Verifica se existe usuário. Caso sim, atualiza a senha. Caso não, cria novo usuário.
            var usuarioExistente = BuscarPorCPF(cpf);

            if (usuarioExistente != null)
            {
                var senhaEncriptada = GerarHashMd5(usuarioExistente.USR_CODIGO + senha);

                Atualizar(USR_CODIGO: usuarioExistente.USR_CODIGO,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL.Trim(),
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);
            }
            else
            {
                var proximoCodigo = BuscarProximoCodigo();

                var senhaEncriptada = GerarHashMd5(proximoCodigo + senha);

                Inserir(USR_CODIGO: proximoCodigo,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL.Trim(),
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);

                if (pensionista)
                {
                    new UsuarioGrupoProxy().Inserir(new UsuarioGrupoEntidade
                    {
                        GRP_CODIGO = 32,
                        SIS_CODIGO = "PWA",
                        USR_CODIGO = proximoCodigo
                    });
                }
            }

            // Envia e-mail com nova senha de acesso
            var config = AppSettings.Get();

            EnvioEmail.Enviar(config.Email, email, $"{config.Cliente} - Nova senha de acesso", $"Esta é sua nova senha da {config.Cliente}: {senha}");

            if(string.IsNullOrEmpty(dadosPessoais.NO_EMAIL.Trim()))
            {
                new EnderecoPessoaProxy().AtualizarEmailPorCdPessoa(dadosPessoais.CD_PESSOA, email);
            }

            return "Sua nova senha foi enviada para seu e-mail!";
        }

        public void CriarAcessoIntech(string cpf, string chave)
        {
            if (chave != "Intech456#@!")
                throw ExceptionDadosInvalidos;

            var pensionista = false;

            var pessoaFisica = new PessoaFisicaProxy().BuscarPorCpfComContrato(cpf).FirstOrDefault();

            if (pessoaFisica == null)
                throw ExceptionDadosInvalidos;

            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCdPessoa(pessoaFisica.CD_PESSOA);

            if (dadosPessoais == null)
            {
                pensionista = true;
                dadosPessoais = new DadosPessoaisProxy().BuscarPensionistaTodosPorCdPessoa(pessoaFisica.CD_PESSOA).First();
            }

            // Verifica se existe usuário. Caso sim, atualiza a senha. Caso não, cria novo usuário.
            var usuarioExistente = BuscarPorCPF(cpf);

            if (usuarioExistente != null)
            {
                var senhaEncriptada = GerarHashMd5(usuarioExistente.USR_CODIGO + "123");

                Atualizar(USR_CODIGO: usuarioExistente.USR_CODIGO,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL,
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);
            }
            else
            {
                var proximoCodigo = BuscarProximoCodigo();

                var senhaEncriptada = GerarHashMd5(proximoCodigo + "123");

                Inserir(USR_CODIGO: proximoCodigo,
                    USR_LOGIN: cpf,
                    USR_SENHA: senhaEncriptada,
                    USR_ADMINISTRADOR: DMN_SN.NAO,
                    USR_TIPO_EXPIRACAO: DMN_SN.NAO,
                    USR_NOME: pessoaFisica.NO_PESSOA,
                    USR_EMAIL: dadosPessoais.NO_EMAIL,
                    CD_PESSOA: pessoaFisica.CD_PESSOA,
                    EE_TERMO_RESPONSABILIDADE: DMN_SN.SIM,
                    CD_PESSOA_CLIENTE: 1);

                if (pensionista)
                {
                    new UsuarioGrupoProxy().Inserir(new UsuarioGrupoEntidade
                    {
                        GRP_CODIGO = 32,
                        SIS_CODIGO = "PWA",
                        USR_CODIGO = proximoCodigo
                    });
                }
            }
        }

        public string AlterarSenha(string cpf, string senhaAntiga, string senhaNova)
        {
            var usuarioExistente = BuscarPorLoginSenha(cpf, senhaAntiga);

            if (usuarioExistente == null)
                throw new Exception("Senha antiga incorreta!");

            var senhaEncriptada = GerarHashMd5(usuarioExistente.USR_CODIGO + senhaNova);

            Atualizar(USR_CODIGO: usuarioExistente.USR_CODIGO,
                USR_LOGIN: cpf,
                USR_SENHA: senhaEncriptada,
                USR_ADMINISTRADOR: usuarioExistente.USR_ADMINISTRADOR,
                USR_TIPO_EXPIRACAO: usuarioExistente.USR_TIPO_EXPIRACAO,
                USR_NOME: usuarioExistente.USR_NOME,
                USR_EMAIL: usuarioExistente.USR_EMAIL,
                CD_PESSOA: usuarioExistente.CD_PESSOA.Value,
                EE_TERMO_RESPONSABILIDADE: usuarioExistente.EE_TERMO_RESPONSABILIDADE,
                CD_PESSOA_CLIENTE: usuarioExistente.CD_PESSOA_CLIENTE.Value);

            return "Senha alterada com sucesso!";
        }
    }
}
