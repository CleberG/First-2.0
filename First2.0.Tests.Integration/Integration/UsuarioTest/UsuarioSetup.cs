using First2._0.Application.Models.UsuarioModel;
using Fisrt2._0.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    public class UsuarioSetup
    {
        private static UsuarioSetup _usuarioSetup;

        private UsuarioSetup(DbContext dbContext)
        {
            Task.FromResult(Seed(dbContext));
        }

        public static UsuarioSetup GetSetup(DbContext dbContext)
        {
            if (_usuarioSetup == null)
            {
                _usuarioSetup = new UsuarioSetup(dbContext);
            }
            return _usuarioSetup;
        }

        public Usuario Usuario { get; private set; }
        public async Task Seed(DbContext _context)
        {
            var usuario = await _context.AddAsync(CriarUsuario("ufcu"));
            Usuario = usuario.Entity;

            await _context.SaveChangesAsync();
        }

        public Usuario CriarUsuario(string suffix)
        {
            return new Usuario($"Usuario{suffix}", $"Login{suffix}", $"Senha{suffix}", true);
        }

        public UsuarioResponseModel BuscarUsuario()
        {
            return new UsuarioResponseModel()
            {
                Ativo = Usuario.Ativo,
                Nome = Usuario.Nome,
                Login = Usuario.Login,
                Senha = Usuario.Senha,
                Id = Usuario.Id
            };
        }
    }
}
