using Domain.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:EntityBase
    {
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
    }
}
