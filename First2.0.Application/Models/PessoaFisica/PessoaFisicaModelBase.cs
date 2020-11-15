using Fisrt2._0.Domain.Enums;
using System;

namespace First2._0.Application.Models.PessoaFisica
{
    public class PessoaFisicaModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public UF UF { get; set; }
        public bool Ativo { get; set; }
    }
}
