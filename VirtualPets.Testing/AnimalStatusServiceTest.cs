using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using Xunit;

namespace VirtualPets.Testing
{
    public class AnimalStatusServiceTest
    {
        [Fact]
        public async Task LowerHungerAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var adoptionService = scope.ServiceProvider.GetService<IAdoptionService>();            
            var animalStatusService = scope.ServiceProvider.GetService<IAnimalStatusService>();

            var newUserId = await userService.CreateUserAsync("Test user");
            var newAnimalId = await adoptionService.AdoptAnimalAsync(newUserId, "Test dog", AnimalType.Dog);

            var initHunger = await animalStatusService.GetHungerAsync(newUserId, newAnimalId);
            await animalStatusService.LowerHunger(newAnimalId);
            var afterHunger = await animalStatusService.GetHungerAsync(newUserId, newAnimalId);

            Assert.True(afterHunger < initHunger);
        }

        [Fact]
        public async Task LowerHappinessAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var adoptionService = scope.ServiceProvider.GetService<IAdoptionService>();
            var animalStatusService = scope.ServiceProvider.GetService<IAnimalStatusService>();

            var newUserId = await userService.CreateUserAsync("Test user");
            var newAnimalId = await adoptionService.AdoptAnimalAsync(newUserId, "Test dog", AnimalType.Dog);

            var initHappiness = await animalStatusService.GetHappinessAsync(newUserId, newAnimalId);
            await animalStatusService.LowerHappiness(newAnimalId);
            var afterHappiness = await animalStatusService.GetHappinessAsync(newUserId, newAnimalId);

            Assert.True(afterHappiness < initHappiness);
        }
    }
}
