using First2._0.Infra.Context;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First2._0.Tests.Integration.Utils
{
    public class CustomWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public MainContext Db { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescription = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<MainContext>));

                if (serviceDescription != null)
                {
                    services.Remove(serviceDescription);
                }

                services.AddDbContext<MainContext>(opt => { opt.UseInMemoryDatabase("FirstConnectionString"); });

                var sp = services.BuildServiceProvider();
                var scope = sp.CreateScope();

                var scopedServices = scope.ServiceProvider;
                Db = scopedServices.GetRequiredService<MainContext>();

                Db.Database.EnsureCreated();

                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
            });
        }
    }
}
