using System;

namespace Intech.PrevSystemWeb.Entidades
{
    public class LoginEntidade
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Chave { get; set; }
        public string SenhaAtual { get; set; }
        public string SenhaNova { get; set; }
    }
}