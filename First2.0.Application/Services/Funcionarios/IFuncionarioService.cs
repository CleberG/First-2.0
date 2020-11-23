using First2._0.Application.Models.FuncionarioModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Application.Services.Funcionarios
{
    public interface IFuncionarioService
    {
        Task Create(FuncionarioRequestModel request);
        Task Disable(Guid id);
        Task Update(Guid id, FuncionarioRequestModel request);
        Task<FuncionarioResponseModel> GetById(Guid id);
        Task<IList<FuncionarioResponseModel>> GetAll();
    }
}
