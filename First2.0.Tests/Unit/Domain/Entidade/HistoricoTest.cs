using First2._0.Tests.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Entidade
{
    public class HistoricoTest
    {
        [Fact]
        public void Deve_inativar_historico()
        {
            //arrange
            var historico = new HistoricoBuilder().Ativo().Construir();
            //action
            historico.Desabilitar();
            //assert
            historico.Ativo.Should().BeFalse();
        }
        [Fact]
        public void Deve_atualizar_historico()
        {
            //arrange
            var historicoId = Guid.NewGuid();
            var historico = new HistoricoBuilder()
                .ComDescricao("Descrição Teste")
                .ComId(historicoId)
                .Ativo()
                .Construir();

            //action
            historico.Update("Descrição Teste Update", false);

            //assert
            historico.Ativo.Should().BeFalse();
            historico.Descricao.Should().Be("Descrição Teste Update");
            historico.Id.Should().Be(historicoId);
        }
    }
}
