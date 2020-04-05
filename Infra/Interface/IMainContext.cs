using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Interface
{
    public interface IMainContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
