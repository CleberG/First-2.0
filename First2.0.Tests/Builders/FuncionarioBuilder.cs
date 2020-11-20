using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Enums;
using System;

namespace First2._0.Tests.Builders
{
    public class FuncionarioBuilder
    {
        private Guid _id;
        private string _nome;
        private string _usuario;
        private string _senha;
        private TipoFuncionario _tipoFuncionario;
        private bool _ativo;

        public Funcionario Construir()
        {
            return new Funcionario(_nome, _tipoFuncionario, _usuario, _senha)
            {
                Id = _id
            };
        }

        public FuncionarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public FuncionarioBuilder ComTipoFuncionario(TipoFuncionario tipoFuncionario)
        {
            _tipoFuncionario = tipoFuncionario;
            return this;
        }

        public FuncionarioBuilder ComUsuario(string usuario)
        {
            _usuario = usuario;
            return this;
        }

        public FuncionarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public FuncionarioBuilder ComAtivo()
        {
            _ativo = true;
            return this; 
        }

        public FuncionarioBuilder ComInativo()
        {
            _ativo = false;
            return this;
        }

        public FuncionarioBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}
