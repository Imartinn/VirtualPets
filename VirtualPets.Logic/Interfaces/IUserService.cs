using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(string name);
        Task RemoveUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}