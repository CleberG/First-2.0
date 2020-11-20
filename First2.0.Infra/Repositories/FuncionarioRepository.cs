using First2._0.Infra.Context;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Infra.Repositories
{
    public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
