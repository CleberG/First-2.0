using First2._0.Tests.Builders;
using Fisrt2._0.Domain.Entidades;
using FluentAssertions;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Entidade
{
    public class AgenciaTest
    {
        [Fact]
        public void Deve_Criar_Agencia()
        {
            Agencia agencia = CriarAgenciaBuilder("Viacredi", "085", "0101");

            var novaAgencia = new Agencia(agencia.Banco, agencia.Nome, agencia.Numero);

            novaAgencia.Banco.Should().Be(agencia.Banco);
            novaAgencia.Nome.Should().Be(agencia.Nome);
            novaAgencia.Numero.Should().Be(agencia.Numero);
            novaAgencia.Ativo.Should().Be(agencia.Ativo);
        }

        [Fact]
        public void Deve_Inativar_Agencia()
        {
            var agencia = new AgenciaBuilder().Ativo().Construir();

            agencia.Desativar();

            agencia.Ativo.Should().BeFalse();
        }

        [Fact]
        public void Deve_Atualizar_Agencia()
        {
            var agencia = CriarAgenciaBuilder("Viacredi", "085", "0101");

            agencia.Editar("Teste", "0202", "765");

            agencia.Banco.Should().Be("Teste");
            agencia.Nome.Should().Be("0202");
            agencia.Numero.Should().Be("765");
            agencia.Ativo.Should().BeFalse();
        }

        private static Agencia CriarAgenciaBuilder(string nome, string banco, string numero)
        {
            return new AgenciaBuilder()
                .ComNome(nome)
                .ComNumero(numero)
                .ComBanco(banco)
                .Ativo()
                .Construir();
        }
    }
}
