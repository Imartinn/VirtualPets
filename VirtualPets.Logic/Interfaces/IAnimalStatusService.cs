using System;
using System.Threading.Tasks;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Interfaces
{
    public interface IAnimalStatusService
    {
        Task<int> GetHappinessAsync(Guid userId, Guid animalId);
        Task<int> GetHungerAsync(Guid userId, Guid animalId);
        Task<Animal> GetFullAnimalInfoAsync(Guid userId, Guid animalId);
        Task LowerHunger(Guid animalId);
        Task LowerHappiness(Guid animalId);
    }
}