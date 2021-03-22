using Fisrt2._0.Domain.Entidades;
using System;

namespace First2._0.Tests.Builders
{
    public class AgenciaBuilder
    {
        private Guid _id;
        private string _banco;
        private string _nome;
        private string _numero;
        private bool _ativo;

        public Agencia Construir()
        {
            return new Agencia(_nome, _banco, _numero)
            {
                Id = _id
            };
        }

        public AgenciaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public AgenciaBuilder ComBanco(string banco)
        {
            _banco = banco;
            return this;
        }

        public AgenciaBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public AgenciaBuilder ComNumero(string numero)
        {
            _numero = numero;
            return this;
        }

        public AgenciaBuilder Ativo()
        {
            _ativo = true;
            return this;
        }

        public AgenciaBuilder Inativo()
        {
            _ativo = false;
            return this;
        }
    }
}
