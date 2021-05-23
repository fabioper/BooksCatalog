using BooksCatalog.Application;
using BooksCatalog.Application.Services;
using BooksCatalog.Application.Services.Contracts;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Infra.Data;
using BooksCatalog.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BooksCatalog.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<BooksCatalogContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            
            services.AddAutoMapper(typeof(Startup).Assembly);

            #region Services

            services.AddScoped<IBooksService, BooksService>();

            #endregion

            #region Repositories

            services.AddScoped<IBookRepository, BooksRepository>();
            services.AddScoped<IAuthorRepository, AuthorsRepository>();
            services.AddScoped<IGenreRepository, GenresRepository>();
            services.AddScoped<IPublisherRepository, PublishersRepository>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}