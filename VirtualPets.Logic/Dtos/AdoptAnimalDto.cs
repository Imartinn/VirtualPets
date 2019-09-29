using System;

namespace VirtualPets.Logic.Dtos
{
    public class AdoptAnimalDto
    {
        public Guid AdopterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}