using First2._0.Tests.Builders;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Entidade
{
    public class UsuarioTest
    {
        [Fact]
        public async Task deve_inativar_usuario()
        {
            //arrange
            var usuario = new UsuarioBuilder().Ativo().Construir();
            //action
            usuario.Desabilitar();
            //assert
            usuario.Ativo.Should().BeFalse();
        }

        [Fact]
        public async Task deve_atualizar_usuario()
        {
            //arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder()
                .ComNome("Grahl")
                .ComLogin("grahl")
                .ComSenha("123456")
                .ComId(usuarioId)
                .Ativo()
                .Construir();

            //action
            usuario.Update("Darlei", "darlei", "1234567", false);

            //assert
            usuario.Ativo.Should().BeFalse();
            usuario.Login.Should().Be("darlei");
            usuario.Nome.Should().Be("Darlei");
            usuario.Senha.Should().Be("1234567");
            usuario.Id.Should().Be(usuarioId);
        }
    }
}
