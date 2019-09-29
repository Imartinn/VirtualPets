using System;
using System.Threading.Tasks;

namespace VirtualPets.Logic.Interfaces
{
    public interface IPlayingService    
    {
        Task StrokeAnimalAsync(Guid userId, Guid animalId);
    }
}