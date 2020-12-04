using First2._0.Application.Models.HistoricoModel;
using First2._0.Tests.Integration.Utils;
using First2._0.Web;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Integration.Integration.HistoricoTest
{
    [Collection("Non-Parallel")]
    public class HistoricoTests : IntegrationTestsBase
    {
        private readonly HistoricoSetup _setup;
        public readonly string endpointController = "Historico";

        public HistoricoTests(CustomWebAppFactory<Startup> appFactory) : base(appFactory)
        {
            _setup = HistoricoSetup.GetSetup(_context);
        }

        [Fact]
        public async Task Deve_Criar_Historico()
        {
            string suffix = "dcu";
            var historicoResponse = await CriarHistorico(suffix);
            historicoResponse.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Deve_Atualizar_Historico()
        {
            string suffix = "dau";
            var buscaHistoricos = _setup.BuscarHistorico();
            var historico = CriarHistoricoRequest(suffix, $"Descricao{suffix}");
            var historicoResponse = await CriarHistorico(suffix);

            await UpdateEntity(historico, buscaHistoricos.Id, endpointController);
            historicoResponse.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Deve_Buscar_Todos()
        {
            var historico = await Client.GetAsync("api/historico");
            var resultJsonHistorico = await historico.Content.ReadAsStringAsync();
            var getResponse = JsonConvert.DeserializeObject<List<HistoricoResponseDto>>(resultJsonHistorico);
            getResponse.All(x => x.Ativo);
        }

        [Fact]
        public async Task Deve_Desativar_Historico()
        {
            var historico = _setup.BuscarHistorico();
            var historicoResponse = await DeleteEntity(historico.Id, endpointController);
            historicoResponse.Should().Be(HttpStatusCode.NoContent);
        }

        private async Task<ApiResponse<List<HistoricoResponseDto>>> CriarHistorico(string suffix)
        {
            var historico = CriarHistoricoRequest(suffix, $"Descricao{suffix}");
            var result = await CreateEntity<HistoricoRequestDto, List<HistoricoResponseDto>>(historico, endpointController);
            return result;
        }

        private HistoricoRequestDto CriarHistoricoRequest(string suffix, string descricao)
        {
            return new HistoricoRequestDto()
            {
                Ativo = true,
                Descricao = $"{descricao}{suffix}"
            };
        }
    }
}
