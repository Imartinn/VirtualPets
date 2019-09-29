using System;

namespace VirtualPets.Logic.Projections
{
    public class AnimalBasicInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AnimalBasicInfo(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
