using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly VirtualPetsDbContext _virtualPetsDbContext;

        public UserService(VirtualPetsDbContext virtualPetsDbContext)
        {
            _virtualPetsDbContext = virtualPetsDbContext;
        }

        public async Task<Guid> CreateUserAsync(string name)
        {
            var user = _virtualPetsDbContext.Users.Add(new User(name));
            await _virtualPetsDbContext.SaveChangesAsync().ConfigureAwait(false);

            return user.Entity.Id;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _virtualPetsDbContext.Users.AsNoTracking().ToArrayAsync().ConfigureAwait(false);
        }

        public async Task RemoveUserAsync(Guid userId)
        {
            var user = await _virtualPetsDbContext.Users.FindAsync(userId).ConfigureAwait(false);
            
            if (user is null)
                throw new ArgumentException("The provided user doesn't exist");

            _virtualPetsDbContext.Users.Remove(user);
            await _virtualPetsDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}