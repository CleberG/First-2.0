using Fisrt2._0.Domain.Enums;
using System;

namespace Fisrt2._0.Domain.Entidades
{
    public class PessoaFisica : Endereco
    {
        public PessoaFisica()
        {

        }

        public PessoaFisica(string nome, string email, string cPF, DateTime dataNascimento, decimal limiteCredito,
            string complemento, string telefone, string cidade, string bairro, string numero, string cEP, UF uF, bool ativo)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
            DataNascimento = dataNascimento;
            LimiteCredito = limiteCredito;
            Complemento = complemento;
            Telefone = telefone;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            CEP = cEP;
            UF = uF;
            Ativo = ativo;
        }

        public void Update(string nome, string email, string cPF, DateTime dataNascimento, decimal limiteCredito,
         string complemento, string telefone, string cidade, string bairro, string numero, string cEP, UF uF, bool ativo)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
            DataNascimento = dataNascimento;
            LimiteCredito = limiteCredito;
            Complemento = complemento;
            Telefone = telefone;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            CEP = cEP;
            UF = uF;
            Ativo = ativo;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
    }
}
