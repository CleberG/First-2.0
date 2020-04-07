using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUsuarioService
    {
        Task Create(UsuarioRequestDto request);
        Task Update(Guid id, UsuarioRequestDto request);
        Task Delete(Guid id);
        Task<UsuarioResponseDto> GetById(Guid id);
        Task<IList<UsuarioResponseDto>> GetAll();
    }
}
