using First2._0.Infra.Context;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fisrt2._0.Domain.Entidades
{
    class PessoaFisicaRepository : GenericRepository<PessoaFisica>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
