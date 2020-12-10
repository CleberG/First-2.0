using First2._0.Application.Models.FuncionarioModel;
using First2._0.Tests.Integration.Utils;
using First2._0.Web;
using Fisrt2._0.Domain.Enums;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Integration.Integration.FuncionarioTest
{
    [Collection("Non-Parallel")]
    public class FuncionarioTests : IntegrationTestsBase
    {
        private readonly FuncionarioSetup _instance;
        public readonly string endpointController = "Funcionario";

        public FuncionarioTests(CustomWebAppFactory<Startup> appFactory) : base(appFactory)
        {
            _instance = FuncionarioSetup.GetInstance(_context);
        }

        [Fact]
        public async Task Deve_Criar_Funcionario()
        {
            var funcionario = CriarFuncionarioRequest("dcf", TipoFuncionario.Funcionario);

            var response = await CreateEntity(funcionario, endpointController);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Deve_Desativar_Funcionario()
        {
            var funcionario = _instance.DesativarFuncionario;

            var funcionarioResponse = await DeleteEntity(funcionario.Id, endpointController);

            funcionarioResponse.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Deve_Buscar_Todos()
        {
            var getResult = await Client.GetAsync($"api/{endpointController}");

            var resultJsonFuncionario = await getResult.Content.ReadAsStringAsync();
            var funcionarioResponse = JsonConvert.DeserializeObject<List<FuncionarioResponseDto>>(resultJsonFuncionario);

            getResult.StatusCode.Should().Be(HttpStatusCode.OK);

            funcionarioResponse.All(x => x.Ativo);
        }

        [Fact]
        public async Task Deve_Buscar_Por_Id()
        {
            var getFuncionario = _instance.BuscarFuncionarioPorId;

            var getResult = await GetEntity(getFuncionario.Id, endpointController);

            var resultJsonFuncionario = await getResult.Content.ReadAsStringAsync();
            var funcionarioResponse = JsonConvert.DeserializeObject<FuncionarioResponseDto>(resultJsonFuncionario);

            getResult.StatusCode.Should().Be(HttpStatusCode.OK);

            funcionarioResponse.Id.Should().Be(getFuncionario.Id);
            funcionarioResponse.TipoFuncionario.Should().Be(getFuncionario.TipoFuncionario);
            funcionarioResponse.Nome.Should().Be(getFuncionario.Nome);
            funcionarioResponse.Usuario.Should().Be(getFuncionario.Usuario);
            funcionarioResponse.Senha.Should().Be(getFuncionario.Senha);
            funcionarioResponse.Ativo.Should().Be(getFuncionario.Ativo);
        }

        [Fact]
        public async Task Deve_Atualizar_Funcionario()
        {
            var funcionario = _instance.AtualizarFuncionario;

            var funcionarioRequest = CriarFuncionarioRequest("daf", TipoFuncionario.Funcionario);

            var funcionarioResponse = await CreateEntity(funcionarioRequest, endpointController);

            await UpdateEntity(funcionarioRequest, funcionario.Id, endpointController);

            funcionarioResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private FuncionarioRequestDto CriarFuncionarioRequest(string suffix, TipoFuncionario tipoFuncionario)
        {
            return new FuncionarioRequestDto()
            {
                Ativo = true,
                Nome = $"Nome{suffix}",
                Usuario = $"Usuario{suffix}",
                Senha = $"Senha{suffix}",
                TipoFuncionario = tipoFuncionario
            };
        }
    }
}
