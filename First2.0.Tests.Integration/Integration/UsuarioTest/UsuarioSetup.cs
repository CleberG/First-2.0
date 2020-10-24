using Fisrt2._0.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    public class UsuarioSetup
    {
        public async Task Seed(DbContext _context)
        {
            await _context.AddAsync(CreateUsuario("ufcu"));
        }

        public static Usuario CreateUsuario(string suffix)
        {
            return new Usuario($"Usuario{suffix}", $"Login{suffix}", $"Senha{suffix}", true);
        }
    }
}
