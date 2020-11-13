using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Infra.Mappings
{
    public class HistoricoMapping
        : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.Property(d => d.Descricao).HasColumnName(nameof(Historico.Descricao)).IsRequired();
            builder.Property(d => d.Ativo).HasColumnName(nameof(Historico.Ativo)).IsRequired();
        }
    }
}
