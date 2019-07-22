using APILogin.HyperMedia;
using APILogin.MODEL.CONTEXT;
using APILogin.REPOSITORY;
using APILogin.SERVICE.Implementattions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Tapioca.HATEOAS;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace APILogin
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

           
            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "BD" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }


            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new LoginEnricher());
            services.AddSingleton(filterOptions);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "RESTful API With ASP.NET Core 2.0", Version = "v1" });
            });

            //Injeção de dependencia
            services.AddScoped<ILoginService, LoginServiceImpl>();
            services.AddScoped<ILoginRepository, LoginRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            var option = new RewriteOptions();

            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);


            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });

        }
    }
}
