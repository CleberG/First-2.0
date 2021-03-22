using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Validations
{
    public class AgenciaTest
    {
        private readonly AgenciaValidation validation;

        public AgenciaTest()
        {
            validation = new AgenciaValidation();
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Nome_For_Vazio()
        {
            Agencia entity = CreateAgencia("", "085", "0101");

            validation
                .ShouldHaveValidationErrorFor(agencia => agencia.Nome, entity)
                .WithErrorMessage("Nome da agencia não pode ser vazio.");
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Banco_For_Vazio()
        {
            Agencia entity = CreateAgencia("Viacredi", "", "0101");

            validation
                .ShouldHaveValidationErrorFor(agencia => agencia.Banco, entity)
                .WithErrorMessage("Nome do banco não pode ser vazio.");
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Numero_For_Vazio()
        {
            Agencia entity = CreateAgencia("Viacredi", "085", "");

            validation
                .ShouldHaveValidationErrorFor(agencia => agencia.Numero, entity)
                .WithErrorMessage("Numero da agencia não pode ser vazio.");
        }

        private static Agencia CreateAgencia(string nome, string banco, string numero)
        {
            return new Agencia(banco, nome, numero);
        }
    }
}
