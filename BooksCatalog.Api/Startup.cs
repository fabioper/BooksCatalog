using System;
using System.IO;
using System.Reflection;
using BooksCatalog.Api.Services;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Infra.Data;
using BooksCatalog.Infra.Data.Repositories;
using BooksCatalog.Infra.Services.Messaging;
using BooksCatalog.Infra.Services.Storage;
using BooksCatalog.Infra.Services.Storage.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
                options.UseNpgsql(_configuration.GetConnectionString("DbConnection")));
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            /*services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:15450";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });*/
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BooksCatalog API",
                    Description = "API for manage book catalog"
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #region Services

            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IAuthorsService, AuthorsService>();
            services.AddScoped<IPublishersService, PublishersService>();
            services.AddScoped<IGenresService, GenresService>();
            
            services.AddSingleton<IMessagePublisher, MessagePublisher>();
            services.AddSingleton<IStorageService>(
                new BlobStorage(_configuration.GetConnectionString("BlobConnection")));

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

            /*app.UseHttpsRedirection();*/
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksCatalog API");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}