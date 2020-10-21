using Fisrt2._0.Domain;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    public static class UsuarioFactory
    {
        public static Usuario CreateUsuario(string suffix)
        {
            return new Usuario($"Usuario{suffix}", $"Login{suffix}", $"Senha{suffix}", true);
        }
    }
}
