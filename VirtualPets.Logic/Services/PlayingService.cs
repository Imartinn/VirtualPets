using System;
using System.Threading.Tasks;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Helpers;
using VirtualPets.Logic.Interfaces;

namespace VirtualPets.Logic.Services
{
    public class PlayingService : IPlayingService
    {
        private readonly VirtualPetsDbContext _virtualPetsDbContext;

        public PlayingService(VirtualPetsDbContext virtualPetsDbContext)
        {
            _virtualPetsDbContext = virtualPetsDbContext;
        }

        public async Task StrokeAnimalAsync(Guid userId, Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.FindAsync(animalId).ConfigureAwait(false);

            ValidationHelper.ValidateNullAndOwnerOrThrow(userId, animal);

            animal.Stroke();

            await _virtualPetsDbContext.SaveChangesAsync();
        }
    }
}