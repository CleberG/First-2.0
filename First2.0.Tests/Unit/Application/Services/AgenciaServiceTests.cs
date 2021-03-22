using First2._0.Application.Models.AgenciaModel;
using First2._0.Application.Services.Agencias;
using First2._0.Tests.Builders;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Unit.Application.Services
{
    public class AgenciaServiceTests
    {
        private IAgenciaRepository _agenciaRepository;
        private IAgenciaService _agenciaService;

        public AgenciaServiceTests()
        {
            _agenciaRepository = Substitute.For<IAgenciaRepository>();
            _agenciaService = new AgenciaService(_agenciaRepository);
        }

        [Fact]
        public async Task Deve_Criar_Agencia()
        {
            var request = CreateAgenciaRequest("nome", "banco", "978654215");

            await _agenciaService.Create(request);

            await _agenciaRepository.Received(1)
                .Create(Arg.Is<Agencia>(agencia => agencia.Nome == request.Nome
                                                && agencia.Banco == request.Banco
                                                && agencia.Numero == request.Numero));
        }

        [Fact]
        public async Task Deve_Atualizar_Agencia()
        {
            var agenciaId = Guid.NewGuid();
            var request = CreateAgenciaRequest("nome", "banco", "978654215");

            var newRequest = new AgenciaBuilder()
                .ComNome("teste")
                .ComBanco("teste")
                .ComNumero("98564123")
                .Ativo()
                .Construir();


            _agenciaRepository.GetById(agenciaId).Returns(newRequest);

            await _agenciaService.Update(agenciaId, request);

            await _agenciaRepository.Received(1)
                .Update(agenciaId, Arg.Is<Agencia>(agencia => agencia.Nome == newRequest.Nome
                                                && agencia.Banco == newRequest.Banco
                                                && agencia.Numero == newRequest.Numero));
        }

        [Fact]
        public async Task Deve_Inativar_Agencia()
        {
            var agenciaId = Guid.NewGuid();
            var request = new AgenciaBuilder()
                .ComNome("teste")
                .ComBanco("teste")
                .ComNumero("98564123")
                .Ativo()
                .Construir();


            _agenciaRepository.GetById(agenciaId).Returns(request);

            await _agenciaService.Delete(agenciaId);

            await _agenciaRepository.Received(1)
                .Update(agenciaId, Arg.Is<Agencia>(agencia => agencia.Nome == request.Nome
                                                && agencia.Banco == request.Banco
                                                && agencia.Numero == request.Numero));
        }


        private static AgenciaRequestModel CreateAgenciaRequest(string nome, string banco, string numero)
        {
            return new AgenciaRequestModel()
            {
                Nome = nome,
                Banco = banco,
                Numero = numero
            };
        }
    }
}
