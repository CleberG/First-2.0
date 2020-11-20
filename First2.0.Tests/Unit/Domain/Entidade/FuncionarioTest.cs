using First2._0.Tests.Builders;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Entidade
{
    public class FuncionarioTest
    {
        [Fact]
        public void Deve_Criar_Funcionario()
        {
            var funcionario = CreateFuncionario();
            var newFuncionario = new Funcionario(funcionario.Nome, funcionario.TipoFuncionario, funcionario.Usuario, funcionario.Senha);

            newFuncionario.Nome.Should().Be(funcionario.Nome);
            newFuncionario.TipoFuncionario.Should().Be(funcionario.TipoFuncionario);
            newFuncionario.Usuario.Should().Be(funcionario.Usuario);
            newFuncionario.Senha.Should().Be(funcionario.Senha);
            newFuncionario.Ativo.Should().Be(funcionario.Ativo);
        }

        [Fact]
        public void Deve_Desativar_Funcionario()
        {
            var funcionario = new Funcionario("Funcionario", TipoFuncionario.Gerente, "Usuario", "Senha");

            funcionario.Desabilitar();

            funcionario.Ativo.Should().BeFalse();
        }

        [Fact]
        public void Deve_Atualizar_Funcionario()
        {
            var funcionario = CreateFuncionario();

            funcionario.Update("Funcionario", TipoFuncionario.Gerente, "Usuario", "Senha");

            funcionario.Nome.Should().Be("Funcionario");
            funcionario.TipoFuncionario.Should().Be(TipoFuncionario.Gerente);
            funcionario.Usuario.Should().Be("Usuario");
            funcionario.Senha.Should().Be("Senha");
            funcionario.Ativo.Should().BeFalse();
        }

        private Funcionario CreateFuncionario()
        {
            return new FuncionarioBuilder()
                .ComNome("Funcionario")
                .ComTipoFuncionario(TipoFuncionario.Funcionario)
                .ComUsuario("Testando")
                .ComSenha("132456789")
                .ComAtivo()
                .Construir();
        }
    }
}
