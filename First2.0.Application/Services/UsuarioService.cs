using First2._0.Application.Models.UsuarioModel;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2._0.Application.Services
{
    public class UsuarioService
       : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Create(UsuarioRequestModel request)
        {
            var usuario = new Usuario(request.Nome, request.Login, request.Senha, request.Ativo);
            await _usuarioRepository.Create(usuario);
        }

        public async Task Delete(Guid id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            usuario.Desabilitar();
            await _usuarioRepository.Update(id, usuario);
        }

        public async Task<IList<UsuarioResponseModel>> GetAll()
        {
            var usuarios = _usuarioRepository
                .GetAll()
                .ToList();

            return usuarios.Select(d => new UsuarioResponseModel()
            {
                Ativo = d.Ativo,
                Id = d.Id,
                Login = d.Login,
                Nome = d.Nome,
                Senha = d.Senha
            }).ToList();
        }

        public async Task<UsuarioResponseModel> GetById(Guid id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            return new UsuarioResponseModel()
            {
                Ativo = usuario.Ativo,
                Id = usuario.Id,
                Login = usuario.Login,
                Nome = usuario.Nome,
                Senha = usuario.Senha
            };
        }

        public async Task Update(Guid id, UsuarioRequestModel request)
        {
            var verificaUsuario = _usuarioRepository.VerificarExistencia(id);
            if (verificaUsuario == null)
            {
               // exception + mensagem 
            }
            var usuario = await _usuarioRepository.GetById(id);
            usuario.Update(request.Nome, request.Login, request.Senha, request.Ativo);
            await _usuarioRepository.Update(id, usuario);

        }
    }
}
