using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Helpers;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Services
{
    public class AnimalStatusService : IAnimalStatusService
    {
        private readonly VirtualPetsDbContext _virtualPetsDbContext;

        public AnimalStatusService(VirtualPetsDbContext virtualPetsDbContext)
        {
            _virtualPetsDbContext = virtualPetsDbContext;
        }

        public async Task<int> GetHappinessAsync(Guid userId, Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.AsNoTracking().FirstAsync(x => x.Id == animalId).ConfigureAwait(false);

            ValidationHelper.ValidateNullAndOwnerOrThrow(userId, animal);

            return animal.Happiness;
        }

        public async Task<int> GetHungerAsync(Guid userId, Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.AsNoTracking().FirstAsync(x => x.Id == animalId).ConfigureAwait(false);

            ValidationHelper.ValidateNullAndOwnerOrThrow(userId, animal);

            return animal.Hunger;
        }

        public async Task<Animal> GetFullAnimalInfoAsync(Guid userId, Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.AsNoTracking().FirstAsync(x => x.Id == animalId).ConfigureAwait(false);

            ValidationHelper.ValidateNullAndOwnerOrThrow(userId, animal);

            return animal;
        }
        
        #region internal 
        public async Task RaiseHunger(Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.FindAsync(animalId).ConfigureAwait(false);

            animal.RaiseHunger();

            await _virtualPetsDbContext.SaveChangesAsync();
        }
        
        public async Task LowerHappiness(Guid animalId)
        {
            var animal = await _virtualPetsDbContext.Animals.FindAsync(animalId).ConfigureAwait(false);

            animal.LowerHappiness();

            await _virtualPetsDbContext.SaveChangesAsync();
        }        
        #endregion internal 
    }
}