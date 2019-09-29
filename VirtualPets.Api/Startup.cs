using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Services;

namespace VirtualPets.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<VirtualPetsDbContext>(options =>
            {
                options.UseSqlite("Filename=..\\VirtualPets.db")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdoptionService, AdoptionService>();
            services.AddScoped<IAnimalStatusService, AnimalStatusService>();
            services.AddScoped<IFeedingService, FeedingService>();
            services.AddScoped<IPlayingService, PlayingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            var dbContext = serviceProvider.GetService<VirtualPetsDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
