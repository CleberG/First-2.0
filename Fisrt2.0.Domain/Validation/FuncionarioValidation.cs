using FluentValidation;

namespace Fisrt2._0.Domain.Validation
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            ValidaNome();
            ValidaUsuario();
            ValidaSenha();
        }

        private void ValidaNome()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome do funcionário.");
        }

        private void ValidaUsuario()
        {
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("Informe o usuário do funcionário.");
        }

        private void ValidaSenha()
        {
            RuleFor(x => x.Senha).MinimumLength(8)
                .WithMessage("Informe uma senha com 8 caracteres.")
                .NotEmpty()
                .WithMessage("Informe uma senha.");
        }
    }
}
