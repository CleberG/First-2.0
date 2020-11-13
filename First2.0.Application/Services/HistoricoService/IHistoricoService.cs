using First2._0.Application.Models.HistoricoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace First2._0.Application.Services.HistoricoService
{
    public interface IHistoricoService
    {
        Task Create(HistoricoRequestModel request);
        Task Update(Guid id, HistoricoRequestModel request);
        Task Delete(Guid id);
        Task<HistoricoResponseModel> GetById(Guid id);
        Task<IList<HistoricoResponseModel>> GetAll();
    }
}
