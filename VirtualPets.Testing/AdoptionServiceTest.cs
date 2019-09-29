using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using Xunit;

namespace VirtualPets.Testing
{
    public class AdoptionServiceTest
    {
        [Fact]
        public async Task AdoptAnimalAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var adoptionService = scope.ServiceProvider.GetService<IAdoptionService>();
            
            var newUserId = await userService.CreateUserAsync("Test user");
            var newAnimalId = await adoptionService.AdoptAnimalAsync(newUserId, "Test dog", AnimalType.Dog);

            var animals = await adoptionService.GetAnimalsAsync();

            Assert.NotNull(animals.FirstOrDefault(x => x.Id == newAnimalId));
        }
    }
}
