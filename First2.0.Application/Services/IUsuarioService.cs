using First2._0.Application.Models.UsuarioModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace First2._0.Application.Services
{
    public interface IUsuarioService
    {
        Task Create(UsuarioRequestModel request);
        Task Update(Guid id, UsuarioRequestModel request);
        Task Delete(Guid id);
        Task<UsuarioResponseModel> GetById(Guid id);
        Task<IList<UsuarioResponseModel>> GetAll();
    }
}
