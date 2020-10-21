using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    public class UsuarioSetup
    {
        public async Task Seed(DbContext _context)
        {
            await _context.AddAsync(UsuarioFactory.CreateUsuario("ufcu"));
        }
    }
}
