using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First2._0.Infra.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.TipoFuncionario).IsRequired();
            builder.Property(x => x.Usuario).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
        }
    }
}
