using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt2._0.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : EntidadeBase
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
        Task<bool> VerificarExistencia(Guid id);
        Task InserirListaDeRegistros(IList<TEntity> entity);
        Task AlterarListaDeRegistros(IList<TEntity> entity);

    }
}
