using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fisrt2._0.Domain.Validation
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Informe nome válido.")
                .Length(3, 50)
                .WithMessage("Nome deve conter entre 3 e 50 caracteres.");

            RuleFor(x => x.Login)
                .EmailAddress()
                .WithMessage("Informe email válido para usuário.");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Informe a senha do usuário.")
                .Length(8, 20)
                .WithMessage("Senha deve conter entre 8 e 20 caracteres.");
        }
    }
}