using First2._0.Infra.Context;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Infra.Repositories
{
    public class HistoricoRepository 
        : GenericRepository<Historico>,IHistoricoRepository
    {
        public HistoricoRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
