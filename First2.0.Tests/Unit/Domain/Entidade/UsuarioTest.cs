using First2._0.Tests.Builders;
using FluentAssertions;
using System;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Entidade
{
    public class UsuarioTest
    {
        [Fact]
        public void Deve_inativar_usuario()
        {
            //arrange
            var usuario = new UsuarioBuilder().Ativo().Construir();
            //action
            usuario.Desabilitar();
            //assert
            usuario.Ativo.Should().BeFalse();
        }

        [Fact]
        public void Deve_atualizar_usuario()
        {
            //arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder()
                .ComNome("Vitor")
                .ComLogin("vitor")
                .ComSenha("123456")
                .ComId(usuarioId)
                .Ativo()
                .Construir();

            //action
            usuario.Update("Cleber", "cleber", "1234567", false);

            //assert
            usuario.Ativo.Should().BeFalse();
            usuario.Login.Should().Be("cleber");
            usuario.Nome.Should().Be("Cleber");
            usuario.Senha.Should().Be("1234567");
            usuario.Id.Should().Be(usuarioId);
        }
    }
}
