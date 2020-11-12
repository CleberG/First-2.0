using First2._0.Application.Models.UsuarioModel;
using First2._0.Tests.Integration.Utils;
using First2._0.Web;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Integration.Integration.UsuarioTest
{
    [Collection("Non-Parallel")]
    public class UsuarioTests : IntegrationTestsBase
    {
        private readonly UsuarioSetup _setup;
        public readonly string endpointController = "Usuario";

        public UsuarioTests(CustomWebAppFactory<Startup> appFactory) : base(appFactory)
        {
            _setup = UsuarioSetup.GetSetup(_context);
        }

        [Fact]
        public async Task Deve_Criar_Usuario()
        {
            string suffix = "dcu";
            var usuarioResponse = await CriarUsuario(suffix);
            usuarioResponse.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Deve_Atualizar_Usuario()
        {
            string suffix = "dau";
            var buscaUsuarios = _setup.BuscarUsuario();
            var usuario = CriarUsuarioRequest(suffix, $"Usuario{suffix}", $"Usuario45{suffix}", $"987654321{suffix}");
            var usuarioResponse = await CriarUsuario(suffix);

            await UpdateEntity(usuario, buscaUsuarios.Id, endpointController);
            usuarioResponse.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Deve_Buscar_Todos()
        {
            var buscaUsuarios = _setup.BuscarUsuario();
            var usuario = await Client.GetAsync("api/usuario");
            var resultJsonUsuario = await usuario.Content.ReadAsStringAsync();
            var getResponse = JsonConvert.DeserializeObject<List<UsuarioResponseModel>>(resultJsonUsuario);

            getResponse.Should().HaveCount(1);
            getResponse.Should().Contain(x => x.Nome == buscaUsuarios.Nome
                                        && x.Login == buscaUsuarios.Login
                                        && x.Senha == buscaUsuarios.Senha);
        }

        [Fact]
        public async Task Deve_Desativar_Usuario()
        {
            var usuario = _setup.BuscarUsuario();
            var usuarioResponse = await DeleteEntity(usuario.Id, endpointController);
            usuarioResponse.Should().Be(HttpStatusCode.NoContent);
        }

        private async Task<ApiResponse<List<UsuarioResponseModel>>> CriarUsuario(string suffix)
        {
            var usuario = CriarUsuarioRequest(suffix, $"Usuario{suffix}", $"Login{suffix}", $"Senha{suffix}");
            var result = await CreateEntity<UsuarioRequestModel, List<UsuarioResponseModel>>(usuario, endpointController);
            return result;
        }

        private UsuarioRequestModel CriarUsuarioRequest(string suffix, string name, string login, string senha)
        {
            return new UsuarioRequestModel()
            {
                Ativo = true,
                Nome = $"{name}{suffix}",
                Login = $"{login}{suffix}",
                Senha = $"{senha}{suffix}"
            };
        }
    }
}
