using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Models;
using VirtualPets.Logic.Projections;

namespace VirtualPets.Logic.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly VirtualPetsDbContext _virtualPetsDbContext;

        public AdoptionService(VirtualPetsDbContext virtualPetsDbContext)
        {
            _virtualPetsDbContext = virtualPetsDbContext;
        }

        public async Task<Guid> AdoptAnimalAsync(Guid userId, string animalName, string animalType)
        {
            if (!Enum.TryParse<AnimalType>(animalType, out var enumAnimalType))
                throw new InvalidOperationException("We don't sell that kind of animal");

            return await AdoptAnimalAsync(userId, animalName, enumAnimalType).ConfigureAwait(false);
        }

        public async Task<Guid> AdoptAnimalAsync(Guid userId, string animalName, AnimalType animalType)
        {
            if (await _virtualPetsDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false) == null)
                throw new ArgumentException("The provided user does not exist");
            
            Animal newAnimal;

            switch (animalType)
            {
                case AnimalType.Dog:
                    newAnimal = new Dog(userId, animalName);
                    break;
                case AnimalType.Cat:
                    newAnimal = new Cat(userId, animalName);
                    break;
                case AnimalType.Bear:
                    newAnimal = new Bear(userId, animalName);
                    break;
                case AnimalType.Parrot:
                    newAnimal = new Parrot(userId, animalName);
                    break;
                default:
                    throw new InvalidOperationException("We don't sell that kind of animal");
            }

            await _virtualPetsDbContext.Animals.AddAsync(newAnimal).ConfigureAwait(false);
            await _virtualPetsDbContext.SaveChangesAsync().ConfigureAwait(false);

            return newAnimal.Id;
        }

        public async Task<IEnumerable<AnimalBasicInfo>> GetAnimalsAsync()
        {
            return await _virtualPetsDbContext.Animals.Select(x => new AnimalBasicInfo(x.Id, x.Name)).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<AnimalBasicInfo>> GetAliveAnimalsAsync()
        {
            return await _virtualPetsDbContext.Animals.Where(x => x.IsAlive).Select(x => new AnimalBasicInfo(x.Id, x.Name)).ToArrayAsync().ConfigureAwait(false);
        }
    }
}