using Fisrt2._0.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Infra.Mappings
{
    public class UsuarioMapping
        : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(d => d.Nome).HasColumnName(nameof(Usuario.Nome)).IsRequired();
            builder.Property(d => d.Login).HasColumnName(nameof(Usuario.Login)).IsRequired();
            builder.Property(d => d.Senha).HasColumnName(nameof(Usuario.Senha)).IsRequired();
            builder.Property(d => d.Ativo).HasColumnName(nameof(Usuario.Ativo)).IsRequired();
        }
    }
}
