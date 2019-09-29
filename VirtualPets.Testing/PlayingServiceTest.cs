using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using Xunit;

namespace VirtualPets.Testing
{
    public class PlayingServiceTest
    {
        [Fact]
        public async Task StrokeAnimalAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var adoptionService = scope.ServiceProvider.GetService<IAdoptionService>();
            var playingService = scope.ServiceProvider.GetService<IPlayingService>();
            var animalStatusService = scope.ServiceProvider.GetService<IAnimalStatusService>();

            var newUserId = await userService.CreateUserAsync("Test user");
            var newAnimalId = await adoptionService.AdoptAnimalAsync(newUserId, "Test dog", AnimalType.Dog);

            var initHappiness = await animalStatusService.GetHappinessAsync(newUserId, newAnimalId);
            await playingService.StrokeAnimalAsync(newUserId, newAnimalId);
            var afterHappiness = await animalStatusService.GetHappinessAsync(newUserId, newAnimalId);

            Assert.True(afterHappiness > initHappiness);
        }
    }
}
