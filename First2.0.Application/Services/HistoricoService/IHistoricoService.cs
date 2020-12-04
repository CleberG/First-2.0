using First2._0.Application.Models.HistoricoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace First2._0.Application.Services.HistoricoService
{
    public interface IHistoricoService
    {
        Task Create(HistoricoRequestDto request);
        Task Update(Guid id, HistoricoRequestDto request);
        Task Delete(Guid id);
        Task<HistoricoResponseDto> GetById(Guid id);
        Task<IList<HistoricoResponseDto>> GetAll();
    }
}
