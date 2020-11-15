using First2._0.Infra.Context;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;

namespace First2._0.Infra.Repositories
{
    public class PessoaFisicaRepository : GenericRepository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
