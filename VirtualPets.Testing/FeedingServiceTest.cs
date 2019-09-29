using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using Xunit;

namespace VirtualPets.Testing
{
    public class FeedingServiceTest
    {
        [Fact]
        public async Task FeedAnimalAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var adoptionService = scope.ServiceProvider.GetService<IAdoptionService>();
            var feedingService = scope.ServiceProvider.GetService<IFeedingService>();
            var animalStatusService = scope.ServiceProvider.GetService<IAnimalStatusService>();

            var newUserId = await userService.CreateUserAsync("Test user");
            var newAnimalId = await adoptionService.AdoptAnimalAsync(newUserId, "Test dog", AnimalType.Dog);

            var initHunger = await animalStatusService.GetHungerAsync(newUserId, newAnimalId);
            await feedingService.FeedAnimalAsync(newUserId, newAnimalId);
            var afterHunger = await animalStatusService.GetHungerAsync(newUserId, newAnimalId);

            Assert.True(afterHunger > initHunger);
        }
    }
}
