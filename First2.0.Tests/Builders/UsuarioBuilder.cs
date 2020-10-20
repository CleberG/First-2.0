using Fisrt2._0.Domain;
using System;

namespace First2._0.Tests.Builders
{
    public class UsuarioBuilder
    {
        private Guid _id;
        private string _nome;
        private string _login;
        private string _senha;
        private bool _ativo;

        public Usuario Construir()
        {
            return new Usuario(_nome, _login, _senha, _ativo)
            {
                Id = _id
            };
        }
        public UsuarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public UsuarioBuilder ComLogin(string login)
        {
            _login = login;
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public UsuarioBuilder Ativo()
        {
            _ativo = true;
            return this;
        }
        public UsuarioBuilder Inativo()
        {
            _ativo = false;
            return this;
        }

        public UsuarioBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}
