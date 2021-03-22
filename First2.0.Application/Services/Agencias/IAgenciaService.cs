using First2._0.Application.Models.AgenciaModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Application.Services.Agencias
{
    public interface IAgenciaService
    {
        Task Create(AgenciaRequestModel request);
        Task Update(Guid id, AgenciaRequestModel request);
        Task Delete(Guid id);
        Task<AgenciaResponseModel> GetById(Guid id);
        Task<IList<AgenciaResponseModel>> GetAll();
    }
}
