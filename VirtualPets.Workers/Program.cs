using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Services;

namespace VirtualPets.Workers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<VirtualPetsDbContext>(options =>
                    { 
                        options.UseSqlite("Filename=VirtualPets.db")
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();                        
                    });

                    services.AddHostedService<AnimalStatusWorker>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IAdoptionService, AdoptionService>();
                    services.AddScoped<IAnimalStatusService, AnimalStatusService>();
                    services.AddScoped<IFeedingService, FeedingService>();
                    services.AddScoped<IPlayingService, PlayingService>();
                });
    }
}
