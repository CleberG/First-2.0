using Microsoft.EntityFrameworkCore;

namespace First2._0.Infra.Context
{
    public class MainContext
        : DbContext
    {
        public MainContext(DbContextOptions options)
            : base(options)
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("DefaultConnection");
            }
        }
    }
}
