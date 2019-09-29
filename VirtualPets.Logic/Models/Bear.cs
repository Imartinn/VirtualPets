using System;
using VirtualPets.Logic.Enums;

namespace VirtualPets.Logic.Models
{
    public class Bear : Animal
    {
        public override int MAX_HUNGER { get => 100; }
        public override int MAX_HAPPINESS { get => 100; }
        public override int HUNGER_MOD { get => 25; }
        public override int HAPPINESS_MOD { get => 25; }

        public Bear(Guid ownerId, string name) : base(ownerId, name, AnimalType.Bear)
        {

        }        
    }
}