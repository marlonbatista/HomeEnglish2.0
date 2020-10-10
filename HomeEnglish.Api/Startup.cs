using System;
using System.IO;
using HomeEnglish.Domain.DomainContext.Handlers;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Infra.StoreContext.ConnectionDB;
using HomeEnglish.Infra.StoreContext.Repositories;
using HomeEnglish.Shared.ConfigDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeEnglish.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors(options =>
            {
                options.AddPolicy("HomeEnglish", builder =>
                {
                    builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins(
                        "*"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(600))
                    .Build();
                });
            });

            services.AddResponseCompression();

            services.AddScoped<HomeEnglishDataContext, HomeEnglishDataContext>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<LessonHandler, LessonHandler>();
            services.AddTransient<StudentHandler, StudentHandler>();

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors();
            app.UseResponseCompression();
            // app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
