using System;
using System.Threading.Tasks;

namespace Fisrt2._0.Domain.Interfaces
{
    public interface IFuncionarioRepository : IGenericRepository<Funcionario>
    {
        Task<bool> VerificaSeFuncionarioExiste(string name, Guid? id);
    }
}
