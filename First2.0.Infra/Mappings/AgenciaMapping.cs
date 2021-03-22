using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First2._0.Infra.Mappings
{
    public class AgenciaMapping : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.Property(x => x.Banco).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
        }
    }
}
