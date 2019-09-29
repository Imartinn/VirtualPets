using System;
using System.Threading.Tasks;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Helpers;
using VirtualPets.Logic.Interfaces;

namespace VirtualPets.Logic.Services
{
    public class FeedingService : IFeedingService
    {
        private readonly VirtualPetsDbContext _virtualPetsDbContext;

        public FeedingService(VirtualPetsDbContext virtualPetsDbContext)
        {
            _virtualPetsDbContext = virtualPetsDbContext;
        }

        public async Task FeedAnimalAsync(Guid userId, Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.FindAsync(animalId).ConfigureAwait(false);

            ValidationHelper.ValidateNullAndOwnerOrThrow(userId, animal);

            animal.Feed();

            await _virtualPetsDbContext.SaveChangesAsync();
        }
    }
}