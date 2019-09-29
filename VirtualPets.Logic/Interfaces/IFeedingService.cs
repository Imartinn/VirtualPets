using System;
using System.Threading.Tasks;

namespace VirtualPets.Logic.Interfaces
{
    public interface IFeedingService
    {
        Task FeedAnimalAsync(Guid userId, Guid animalId);
    }
}