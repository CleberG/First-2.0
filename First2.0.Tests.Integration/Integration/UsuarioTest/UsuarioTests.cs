using First2._0.Application.Models.UsuarioModel;
using First2._0.Tests.Integration.Utils;
using First2._0.Web;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    [Collection("Non-Parallel")]
    public class UsuarioTests : IntegrationTestsBase
    {
        private UsuarioSetup _setup;

        public UsuarioTests(CustomWebAppFactory<Startup> appFactory) : base(appFactory)
        {
            _setup = new UsuarioSetup();
            Task.FromResult(_setup.Seed(_context));
        }

        [Fact]
        public async Task Deve_Criar_Usuario()
        {
            string suffix = "dcu";

            var usuarioResponse = await CriarUsuario(suffix);
            usuarioResponse.StatusCode.Should().Be(204);

            var usuarioResponseModel = usuarioResponse.Data;
            usuarioResponseModel.Should().Be(usuarioResponse.Data.Id);
            usuarioResponseModel.Should().Be(usuarioResponse.Data.Nome);
            usuarioResponseModel.Should().Be(usuarioResponse.Data.Login);
            usuarioResponseModel.Should().Be(usuarioResponse.Data.Senha);
        }

        private async Task<ApiResponse<UsuarioResponseModel>> CriarUsuario(string suffix)
        {
            var usuario = CriarUsuarioRequest(suffix);
            var result = await CreateEntity<UsuarioRequestModel, UsuarioResponseModel>(usuario, "usuario");
            return result;
        }

        private UsuarioRequestModel CriarUsuarioRequest(string suffix)
        {
            return new UsuarioRequestModel()
            {
                Ativo = true,
                Nome = $"Usuario{suffix}",
                Login = $"Login{suffix}",
                Senha = $"Senha{suffix}"
            };
        }
    }
}
