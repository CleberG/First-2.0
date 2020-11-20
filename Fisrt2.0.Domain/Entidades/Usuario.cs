using Fisrt2._0.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fisrt2._0.Domain
{
    public class Usuario
       : EntidadeBase
    {
        public Usuario(string nome, string login, string senha, bool ativo)
            : base(true, new UsuarioValidation())
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }

        public void Update(string nome, string login, string senha, bool ativo)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }

        public string Nome { get; protected set; }
        public string Login { get; protected set; }
        public string Senha { get; protected set; }
        public bool Ativo { get; protected set; }
    }
}
