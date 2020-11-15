using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Infra.Mappings
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {

        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(d => d.Email)
                .IsRequired();

            builder.Property(d => d.CPF)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .IsRequired();

            builder.Property(d => d.LimiteCredito)
                .IsRequired();

            builder.Property(d => d.Complemento)
                .IsRequired();

            builder.Property(d => d.Telefone)
                .IsRequired();

            builder.Property(d => d.Cidade)
                .IsRequired();

            builder.Property(d => d.Bairro)
                .IsRequired();

            builder.Property(d => d.Numero)
                .IsRequired();

            builder.Property(d => d.CEP)
                .IsRequired();

            builder.Property(d => d.UF)
                .IsRequired();

            builder.Property(d => d.Ativo)
                .IsRequired();
        }
    }
}
