using First2._0.Application.Models.FuncionarioModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Application.Services.Funcionarios
{
    public interface IFuncionarioService
    {
        Task Create(FuncionarioRequestDto request);
        Task Delete(Guid id);
        Task Update(Guid id, FuncionarioRequestDto request);
        Task<FuncionarioResponseDto> GetById(Guid id);
        Task<IList<FuncionarioResponseDto>> GetAll();
    }
}
