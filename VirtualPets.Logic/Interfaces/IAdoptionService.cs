using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Projections;

namespace VirtualPets.Logic.Interfaces
{
    public interface IAdoptionService
    {
        Task<Guid> AdoptAnimalAsync(Guid userId, string animalName, AnimalType animalType);
        Task<Guid> AdoptAnimalAsync(Guid userId, string animalName, string animalType);
        Task<IEnumerable<AnimalBasicInfo>> GetAnimalsAsync();
    }
}