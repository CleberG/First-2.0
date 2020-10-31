using First2._0.Application.Services;
using First2._0.Infra.Context;
using First2._0.Infra.Filter;
using First2._0.Infra.Repositories;
using Fisrt2._0.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace First2._0.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
               options.Filters.Add(typeof(JsonExceptionFilter))
           ).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<MainContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("FirstConnectionString")));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MainContext>();
                context.Database.Migrate();
            }

            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        }

        private void ConfigureDbContextCollection(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("FirstConnectionString")));
        }
    }
}
