using Application.Dto;
using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Create(UsuarioRequestDto request)
        {
            var usuario = new Usuario(request.Nome, request.Email);
            await _usuarioRepository.Create(usuario);
        }

        public async Task Delete(Guid id)
        {
            var usuario = await _usuarioRepository.GetById(id);

            usuario.Desabilitar();

            await _usuarioRepository.Update(id, usuario);
        }

        public async Task<IList<UsuarioResponseDto>> GetAll()
        {
            var usuarios =  _usuarioRepository.GetAll().ToList();

            return usuarios.Select(d => new UsuarioResponseDto()
            {
                Nome = d.Nome,
                Email = d.Email,
                Ativo = d.Ativo,
                Id = d.Id

            }).ToList();
        }

        public async Task<UsuarioResponseDto> GetById(Guid id)
        {
            var usuario = await _usuarioRepository.GetById(id);

            return new UsuarioResponseDto()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                Id = usuario.Id
            };
        }

        public async Task Update(Guid id, UsuarioRequestDto request)
        {
            var usuario = await _usuarioRepository.GetById(id);

            usuario.Update(request.Nome, request.Email);
            await _usuarioRepository.Update(id, usuario);
        }
    }
}
