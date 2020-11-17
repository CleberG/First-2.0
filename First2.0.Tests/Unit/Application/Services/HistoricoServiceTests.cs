using First2._0.Application.Models.HistoricoModel;
using First2._0.Application.Services.HistoricoService;
using First2._0.Tests.Builders;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Unit.Application.Services
{
    public class HistoricoServiceTests
    {
        private IHistoricoRepository _historicoRepository;
        private IHistoricoService _historicoService;

        public HistoricoServiceTests()
        {
            _historicoRepository = Substitute.For<IHistoricoRepository>();
            _historicoService = new HistoricoService(_historicoRepository);
        }

        [Fact]
        public async Task Deve_salvar_historico()
        {
            //arrange
            var model = new HistoricoRequestDto()
            {
                Ativo = true,
                Descricao = "Teste Descrição"
            };

            //action
            await _historicoService.Create(model);

            //assert
            await _historicoRepository
                .Received(1)
                .Create(Arg.Is<Historico>(d => d.Ativo == true
                                             && d.Descricao == "Teste Descrição"));

        }
        [Fact]
        public async Task Deve_atualizar_historico()
        {
            //arrange
            Guid historicoId;
            HistoricoRequestDto model;
            GetIdModelHistorico(out historicoId, out model);
            var historico = new HistoricoBuilder()
                .ComDescricao("Teste Descricao")
                .Ativo()
                .Construir();

            _historicoRepository
                .GetById(historicoId)
                .Returns(historico);

            //action
            await _historicoService
                .Update(historicoId, model);

            //assert
            await _historicoRepository
                .Received(1)
                .Update(historicoId, Arg.Is<Historico>(d => d.Ativo == false
                                                      && d.Descricao == "Teste Descrição Atualizado"));

        }
        private static void GetIdModelHistorico(out Guid historicoId, out HistoricoRequestDto model)
        {
            historicoId = Guid.NewGuid();
            model = new HistoricoRequestDto()
            {
                Ativo = false,
                Descricao = "Teste Descrição Atualizado"
            };
        }

        [Fact]
        public async Task Deve_inativar_historico()
        {
            //arrange
            var historicoId = Guid.NewGuid();
            var historico = new HistoricoBuilder()
                .Ativo()
                .ComDescricao("Teste Descricão Desativado")
                .Construir();

            _historicoRepository
                .GetById(historicoId)
                .Returns(historico);

            //action
            await _historicoService
                .Delete(historicoId);

            //assert
            await _historicoRepository
                .Received(1)
                .Update(historicoId, Arg.Is<Historico>(d => d.Ativo == false
                                                        && d.Descricao == "Teste Descricão Desativado"));
        }

        [Fact]
        public async Task Deve_obter_por_id()
        {
            //arrange
            var historicoId = Guid.NewGuid();
            var historico = new HistoricoBuilder()
                .Ativo()
                .ComDescricao("Teste Descrição")
                .ComId(historicoId)
                .Construir();

            _historicoRepository
                .GetById(historicoId)
                .Returns(historico);

            //action
            var historicoRetornado = await _historicoService
                .GetById(historicoId);

            //assert
            historicoRetornado.Descricao.Should().Be(historico.Descricao);
            historicoRetornado.Ativo.Should().Be(historico.Ativo);
            historicoRetornado.Id.Should().Be(historicoId);
        }

        [Fact]
        public async Task Deve_retornar_todos_os_historicos()
        {
            //arrange
            var historicoIdA = Guid.NewGuid();
            var historicoA = new HistoricoBuilder()
                .ComDescricao("Teste descrição A")
                .Ativo()
                .ComId(historicoIdA)
                .Construir();
            var historicoIdB = Guid.NewGuid();
            var historicoB = new HistoricoBuilder()
                .ComDescricao("Teste descrição A")
                .Inativo()
                .ComId(historicoIdB)
                .Construir();
            var historicos = new List<Historico>();
            historicos.Add(historicoA);
            historicos.Add(historicoB);

            _historicoRepository.GetAll().Returns(historicos.AsQueryable());

            //action
            var historicosRetornados = await _historicoService.GetAll();

            //assert
            historicosRetornados.Should().HaveCount(2);

            historicosRetornados[0].Descricao.Should().Be(historicoA.Descricao);
            historicosRetornados[0].Ativo.Should().Be(historicoA.Ativo);
            historicosRetornados[0].Id.Should().Be(historicoIdA);

            historicosRetornados[1].Descricao.Should().Be(historicoB.Descricao);
            historicosRetornados[1].Ativo.Should().Be(historicoB.Ativo);
            historicosRetornados[1].Id.Should().Be(historicoIdB);
        }
    }
}
