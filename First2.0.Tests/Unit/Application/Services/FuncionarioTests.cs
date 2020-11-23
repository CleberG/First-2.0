using First2._0.Application.Models.FuncionarioModel;
using First2._0.Application.Services.Funcionarios;
using First2._0.Application.Services.Notifications;
using First2._0.Tests.Builders;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Enums;
using Fisrt2._0.Domain.Interfaces;
using Fisrt2._0.Domain.Notifications;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Unit.Application.Services
{
    public class FuncionarioTests
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;
        private readonly INotificationService _notificationService;

        public FuncionarioTests()
        {
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _notificationService = new NotificationService(new NotificationContext());
            _funcionarioService = new FuncionarioService(_funcionarioRepository, _notificationService);
        }

        [Fact]
        public async Task Deve_Criar_Funcionario()
        {
            var model = CriarFuncionarioRequest("Funcionario", "Funci", "Naotemsenha", TipoFuncionario.Funcionario, true);

            await _funcionarioService.Create(model);

            await _funcionarioRepository.Received(1)
                .Create(Arg.Is<Funcionario>(x => x.Ativo
                                            && x.Nome == "Funcionario"
                                            && x.Usuario == "Funci"
                                            && x.Senha == "Naotemsenha"
                                            && x.TipoFuncionario == TipoFuncionario.Funcionario));
        }

        [Fact]
        public async Task Deve_Atualizar_Funcionario()
        {
            var funcionarioId = Guid.NewGuid();

            var funcionarioBuilder = CriarFuncionarioBuilder(funcionarioId, "Joao", "JoaoStein", "123456789", TipoFuncionario.Gerente);

            var model = CriarFuncionarioRequest("Ciclano", "Usuario", "qualquersenha", TipoFuncionario.Gerente, false);

            _funcionarioRepository.GetById(funcionarioBuilder.Id).Returns(funcionarioBuilder);

            await _funcionarioService.Update(funcionarioBuilder.Id, model);

            await _funcionarioRepository.Received(1)
                .Update(funcionarioBuilder.Id, Arg.Is<Funcionario>(x => x.Ativo == funcionarioBuilder.Ativo
                                            && x.Id == funcionarioBuilder.Id
                                            && x.Nome == funcionarioBuilder.Nome
                                            && x.Usuario == funcionarioBuilder.Usuario
                                            && x.Senha == funcionarioBuilder.Senha
                                            && x.TipoFuncionario == funcionarioBuilder.TipoFuncionario));
        }

        [Fact]
        public async Task Deve_Buscar_Por_Id()
        {
            var funcionarioId = Guid.NewGuid();
            var funcionario = CriarFuncionarioBuilder(funcionarioId, "Joao", "JoaoStein", "123456789", TipoFuncionario.Gerente);

            _funcionarioRepository.GetById(funcionarioId).Returns(funcionario);

            var response = await _funcionarioService.GetById(funcionarioId);

            response.Ativo.Should().Be(funcionario.Ativo);
            response.Nome.Should().Be(funcionario.Nome);
            response.Usuario.Should().Be(funcionario.Usuario);
            response.Senha.Should().Be(funcionario.Senha);
            response.TipoFuncionario.Should().Be(funcionario.TipoFuncionario);
            response.Id.Should().Be(funcionarioId);
        }

        [Fact]
        public async Task Deve_Buscar_Todos()
        {
            var funcionarioIdA = Guid.NewGuid();
            var funcionarioA = CriarFuncionarioBuilder(funcionarioIdA, "Joao", "JoaoStein", "naotemsenha", TipoFuncionario.Funcionario);

            var funcionarioIdB = Guid.NewGuid();
            var funcionarioB = CriarFuncionarioBuilder(funcionarioIdB, "Cleber", "Clebin", "tiozinho147", TipoFuncionario.Gerente);

            var funcionarios = new List<Funcionario>();
            funcionarios.Add(funcionarioA);
            funcionarios.Add(funcionarioB);

            _funcionarioRepository.GetAll().Returns(funcionarios.AsQueryable());

            var response = await _funcionarioService.GetAll();

            response.Should().HaveCount(2);

            response[0].Id.Should().Be(funcionarioIdA);
            response[0].Nome.Should().Be(funcionarioA.Nome);
            response[0].Usuario.Should().Be(funcionarioA.Usuario);
            response[0].Senha.Should().Be(funcionarioA.Senha);
            response[0].TipoFuncionario.Should().Be(funcionarioA.TipoFuncionario);
            response[0].Ativo.Should().Be(funcionarioA.Ativo);

            response[1].Id.Should().Be(funcionarioIdB);
            response[1].Nome.Should().Be(funcionarioB.Nome);
            response[1].Usuario.Should().Be(funcionarioB.Usuario);
            response[1].Senha.Should().Be(funcionarioB.Senha);
            response[1].TipoFuncionario.Should().Be(funcionarioB.TipoFuncionario);
            response[1].Ativo.Should().Be(funcionarioB.Ativo);
        }

        [Fact]
        public async Task Deve_Inativar_Funcionario()
        {
            var funcionarioId = Guid.NewGuid();
            var funcionario = CriarFuncionarioBuilder(funcionarioId, "Joao", "JoaoStein", "naotemsenha", TipoFuncionario.Funcionario);

            _funcionarioRepository.GetById(funcionarioId).Returns(funcionario);

            await _funcionarioService.Disable(funcionarioId);

            await _funcionarioRepository.Received(1).Update(funcionarioId, Arg.Is<Funcionario>(x => !x.Ativo));
        }

        private Funcionario CriarFuncionarioBuilder(Guid id, string nome, string usuario, string senha, TipoFuncionario tipoFuncionario)
        {
            return new FuncionarioBuilder()
                            .ComId(id)
                            .ComNome(nome)
                            .ComTipoFuncionario(tipoFuncionario)
                            .ComUsuario(usuario)
                            .ComSenha(senha)
                            .ComAtivo()
                            .Construir();
        }

        private FuncionarioRequestModel CriarFuncionarioRequest(string nome, string usuario, string senha,
            TipoFuncionario tipoFuncionario, bool ativo)
        {
            return new FuncionarioRequestModel()
            {
                Ativo = ativo,
                Nome = nome,
                Usuario = usuario,
                Senha = senha,
                TipoFuncionario = tipoFuncionario
            };
        }
    }
}
