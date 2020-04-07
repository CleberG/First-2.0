using Domain.Entidades;
using Domain.Interfaces;
using Infra.Contex;

namespace Infra.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
