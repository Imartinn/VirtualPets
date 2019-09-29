using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Services;

namespace VirtualPets.Testing
{
    public static class ServiceProviderAccessor
    {
        public static IServiceScope GetServiceProviderScope()
        {
            var services = new ServiceCollection();

            services.AddDbContext<VirtualPetsDbContext>(options =>
            {
                options.UseInMemoryDatabase("VirtualPets")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            services.AddTransient<IAdoptionService, AdoptionService>();
            services.AddTransient<IAnimalStatusService, AnimalStatusService>();
            services.AddTransient<IFeedingService, FeedingService>();
            services.AddTransient<IPlayingService, PlayingService>();
            services.AddTransient<IUserService, UserService>();


            return services.BuildServiceProvider().CreateScope();
        }
    }
}
