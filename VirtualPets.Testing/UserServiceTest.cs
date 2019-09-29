using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using VirtualPets.Logic.Interfaces;
using Xunit;

namespace VirtualPets.Testing
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateUserAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var newUserId = await userService.CreateUserAsync("Test user");

            var users = await userService.GetUsersAsync();

            Assert.NotNull(users.FirstOrDefault(x => x.Id == newUserId));
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            using var scope = ServiceProviderAccessor.GetServiceProviderScope();

            var userService = scope.ServiceProvider.GetService<IUserService>();
            var newUserId = await userService.CreateUserAsync("Test user");

            var users = await userService.GetUsersAsync();

            Assert.NotNull(users.First(x => x.Id == newUserId));

            await userService.RemoveUserAsync(newUserId);

            users = await userService.GetUsersAsync();

            Assert.Null(users.FirstOrDefault(x => x.Id == newUserId));
        }
    }
}
