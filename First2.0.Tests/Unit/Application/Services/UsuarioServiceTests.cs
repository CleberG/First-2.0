using First2._0.Application.Models.UsuarioModel;
using First2._0.Application.Services;
using First2._0.Tests.Builders;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Unit.Application.Services
{
    public class UsuarioServiceTests
    {
        private IUsuarioRepository _usuarioRepository;
        private IUsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioRepository = Substitute.For<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_usuarioRepository);
        }

        [Fact]
        public async Task Deve_salvar_usuario()
        {
            //arrange
            var model = new UsuarioRequestModel()
            {
                Ativo = true,
                Login = "vitor",
                Nome = "Vitor",
                Senha = "123456"
            };

            //action
            await _usuarioService.Create(model);

            //assert
            await _usuarioRepository
                .Received(1)
                .Create(Arg.Is<Usuario>(d => d.Ativo == true
                                             && d.Login == "vitor"
                                             && d.Nome == "Vitor"
                                             && d.Senha == "123456"));
        }

        [Fact]
        public async Task Deve_atualizar_usuario()
        {
            //arrange
            var usuarioId = Guid.NewGuid();
            var model = new UsuarioRequestModel()
            {
                Ativo = false,
                Login = "paulo",
                Nome = "Paulo",
                Senha = "123456"
            };
            var usuario = new UsuarioBuilder()
                .ComNome("Stein")
                .ComLogin("stien")
                .Ativo()
                .ComSenha("123456")
                .Construir();

            _usuarioRepository
                .GetById(usuarioId)
                .Returns(usuario);

            //action
            await _usuarioService
                .Update(usuarioId, model);

            //assert
            await _usuarioRepository
                .Received(1)
                .Update(usuarioId, Arg.Is<Usuario>(d => d.Ativo == false
                                                      && d.Login == "paulo"
                                                      && d.Nome == "Paulo"
                                                      && d.Senha == "123456"));
        }

        [Fact]
        public async Task Deve_inativar_usuario()
        {
            //arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder()
                .ComNome("Andre")
                .ComLogin("andre")
                .Ativo()
                .ComSenha("123456")
                .Construir();

            _usuarioRepository
                .GetById(usuarioId)
                .Returns(usuario);

            //action
            await _usuarioService
                .Delete(usuarioId);

            //assert
            await _usuarioRepository
                .Received(1)
                .Update(usuarioId, Arg.Is<Usuario>(d => d.Ativo == false
                                                        && d.Login == "andre"
                                                        && d.Nome == "Andre"
                                                        && d.Senha == "123456"));
        }

        [Fact]
        public async Task Deve_obter_por_id()
        {
            //arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder()
                .ComNome("Stein")
                .ComLogin("stein")
                .Ativo()
                .ComSenha("123456")
                .ComId(usuarioId)
                .Construir();

            _usuarioRepository
                .GetById(usuarioId)
                .Returns(usuario);

            //action
            var usuarioRetornado = await _usuarioService
                .GetById(usuarioId);

            //assert
            usuarioRetornado.Nome.Should().Be(usuario.Nome);
            usuarioRetornado.Login.Should().Be(usuario.Login);
            usuarioRetornado.Ativo.Should().Be(usuario.Ativo);
            usuarioRetornado.Senha.Should().Be(usuario.Senha);
            usuarioRetornado.Id.Should().Be(usuarioId);
        }

        [Fact]
        public async Task Deve_retornar_todos_os_usuarios()
        {
            //arrange
            var usuarioIdA = Guid.NewGuid();
            var usuarioA = new UsuarioBuilder()
                .ComNome("Vitor")
                .ComLogin("vitor")
                .Ativo()
                .ComSenha("123456")
                .ComId(usuarioIdA)
                .Construir();
            var usuarioIdB = Guid.NewGuid();
            var usuarioB = new UsuarioBuilder()
                .ComNome("Cleber")
                .ComLogin("cleber")
                .Inativo()
                .ComSenha("12345678")
                .ComId(usuarioIdB)
                .Construir();
            var usuarios = new List<Usuario>();
            usuarios.Add(usuarioA);
            usuarios.Add(usuarioB);

            _usuarioRepository.GetAll().Returns(usuarios.AsQueryable());

            //action
            var usuariosRetornados = await _usuarioService.GetAll();

            //assert
            usuariosRetornados.Should().HaveCount(2);

            usuariosRetornados[0].Nome.Should().Be(usuarioA.Nome);
            usuariosRetornados[0].Login.Should().Be(usuarioA.Login);
            usuariosRetornados[0].Ativo.Should().Be(usuarioA.Ativo);
            usuariosRetornados[0].Senha.Should().Be(usuarioA.Senha);
            usuariosRetornados[0].Id.Should().Be(usuarioIdA);

            usuariosRetornados[1].Nome.Should().Be(usuarioB.Nome);
            usuariosRetornados[1].Login.Should().Be(usuarioB.Login);
            usuariosRetornados[1].Ativo.Should().Be(usuarioB.Ativo);
            usuariosRetornados[1].Senha.Should().Be(usuarioB.Senha);
            usuariosRetornados[1].Id.Should().Be(usuarioIdB);
        }
    }
}