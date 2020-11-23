using First2._0.Infra.Context;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace First2._0.Infra.Repositories
{
    public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MainContext dbContext) : base(dbContext)
        {

        }
        public async Task<bool> VerificaSeFuncionarioExiste(string name, Guid? id)
        {
            return await _dbContext.Set<Funcionario>().AnyAsync(x => x.Nome == name && x.Id != id);
        }
    }
}
