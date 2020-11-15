using First2._0.Application.Models.PessoaFisica;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Application.Services
{
    public interface IPessoaFisicaService
    {
        Task Create(PessoaFisicaRequestModel request);
        Task Update(Guid id, PessoaFisicaRequestModel request);
        Task Delete(Guid id);
        Task<PessoaFisicaResponseModel> GetById(Guid id);
        Task<IList<PessoaFisicaResponseModel>> GetAll();
    }
}
