using Fisrt2._0.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Tests.Builders
{
    public class HistoricoBuilder
    {
        private Guid _id;
        private string _descricao;
        private bool _ativo;

        public Historico Construir()
        {
            return new Historico(_descricao, _ativo)
            {
                Id = _id
            };
        }
        public HistoricoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
        public HistoricoBuilder Ativo()
        {
            _ativo = true;
            return this;
        } 
        public HistoricoBuilder Inativo()
        {
            _ativo = false;
            return this;
        }
        public HistoricoBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}
