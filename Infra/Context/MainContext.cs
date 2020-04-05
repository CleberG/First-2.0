using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contex
{
    public class MainContext : DbContext, IMainContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }

        public MainContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
