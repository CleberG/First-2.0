using First2._0.Infra.Context;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Infra.Repositories
{
    public class UsuarioRepository
        : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
