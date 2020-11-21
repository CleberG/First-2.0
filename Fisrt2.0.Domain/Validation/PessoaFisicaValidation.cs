using Fisrt2._0.Domain.Entidades;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Fisrt2._0.Domain.Validation
{
    class PessoaFisicaValidation : AbstractValidator<PessoaFisica>
    {
        public PessoaFisicaValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Por favor, informe o nome!")
                .Length(3, 50)
                .WithMessage("O nome deve conter entre 3 e 50 caracteres!");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Por favor, informe um email válido!");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("Por favor, informe o CPF!")
                .Length(11)
                .WithMessage("Número de caracteres inválido!")
                .Must(VerificaCpf)
                .WithMessage("Este CPF não é válido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("Por favor, informe a data de nascimento!")
                .LessThan(DateTime.Today)
                .WithMessage("Data de nascimento deve ser menor que a atual.");

            RuleFor(x => x.Complemento)
                .Length(3, 50)
                .WithMessage("Complemento deve conter entre 3 e 50 caracteres.");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("Por favor, informe um número de telefone!")
                .Must(VerificaTelefone)
                .WithMessage("Por favor, informe um número de telefone valido")
                .MaximumLength(11)
                .WithMessage("Número de telefone deve conter no máximo 11 números.");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("Por favor, informe a cidade!")
                .Length(2, 58)
                .WithMessage("O nome da ciadade deve conter entre 3 e 58 caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Por favor, informe o bairro!")
                .Length(2, 58)
                .WithMessage("O nome do bairro deve conter entre 3 e 58 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty()
                .WithMessage("Por favor, informe o numero!");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .WithMessage("Por favor, informe o CEP!")
                .Must(ValidaCEP)
                .WithMessage("O CEP está incorreto.")
                .MaximumLength(9)
                .WithMessage("O CEP deve conter no máximo 8 números.");

            RuleFor(x => x.UF)
                .NotEmpty()
                .WithMessage("Por favor, informe o seu estado!");
        }

        private bool VerificaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
        
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
        
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
        
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool VerificaTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, "[0-9]{9,11}");
        }

        private bool ValidaCEP(string cep)
        {
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        }


        private bool ValidaCpf(string cep)
        {
            return Regex.IsMatch(cep, @"/^\d{ 3}\.\d{ 3}\.\d{ 3}\-\d{ 2}$/");
        }
    }
}
