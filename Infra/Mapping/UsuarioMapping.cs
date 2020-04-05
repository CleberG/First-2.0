using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nome).HasColumnName(nameof(Usuario.Nome)).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnName(nameof(Usuario.Email)).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName(nameof(Usuario.Ativo)).IsRequired();
        }
    }
}
