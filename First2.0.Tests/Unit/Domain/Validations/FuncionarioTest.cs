using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Enums;
using Fisrt2._0.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace First2._0.Tests.Unit.Domain.Validations
{
    public class FuncionarioTest
    {
        private readonly FuncionarioValidation validation;

        public FuncionarioTest()
        {
            validation = new FuncionarioValidation();
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Nome_For_Vazio()
        {
            var funcionario = new Funcionario("", TipoFuncionario.Funcionario, "Usuario", "Senha456789", true);

            validation.ShouldHaveValidationErrorFor(f => f.Nome, funcionario)
                .WithErrorMessage("Informe o nome do funcionário.");
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Usuario_For_Vazio()
        {
            var funcionario = new Funcionario("Funcionario", TipoFuncionario.Funcionario, "", "Senha456789", true);

            validation.ShouldHaveValidationErrorFor(f => f.Usuario, funcionario)
                .WithErrorMessage("Informe o usuário do funcionário.");
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Senha_For_Incorreta()
        {
            var funcionario = new Funcionario("Funcionario", TipoFuncionario.Funcionario, "Usuario", "123", true);

            validation.ShouldHaveValidationErrorFor(f => f.Senha, funcionario)
                .WithErrorMessage("Informe uma senha com 8 caracteres.");
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Quando_Senha_For_Vazio()
        {
            var funcionario = new Funcionario("Funcionario", TipoFuncionario.Funcionario, "Usuario", "", true);

            validation.ShouldHaveValidationErrorFor(f => f.Senha, funcionario)
                .WithErrorMessage("Informe uma senha.");
        }
    }
}
