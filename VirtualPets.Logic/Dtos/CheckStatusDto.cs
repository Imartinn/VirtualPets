using System;

namespace VirtualPets.Logic.Dtos
{
    public class UserAnimalIdsDto
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
    }
}