using Fisrt2._0.Domain.Entidades;
using FluentValidation;

namespace Fisrt2._0.Domain.Validation
{
    public class AgenciaValidation : AbstractValidator<Agencia>
    {
        public AgenciaValidation()
        {
            ValidaBanco();
            ValidaNome();
            ValidaNumero();
        }

        private void ValidaBanco()
        {
            RuleFor(x => x.Banco)
                .NotEmpty()
                .WithMessage("Nome do banco não pode ser vazio.");
        }

        private void ValidaNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome da agencia não pode ser vazio.");
        }

        private void ValidaNumero()
        {
            RuleFor(x => x.Numero)
                .NotEmpty()
                .WithMessage("Numero da agencia não pode ser vazio.");
        }
    }
}
