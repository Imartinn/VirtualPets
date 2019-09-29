using System;
using VirtualPets.Logic.Enums;

namespace VirtualPets.Logic.Models
{
    public class Cat : Animal
    {
        public override int MAX_HUNGER { get => 30; }
        public override int MAX_HAPPINESS { get => 30; }
        public override int HUNGER_MOD { get => 5; }
        public override int HAPPINESS_MOD { get => 5; }

        public Cat(Guid ownerId, string name) : base(ownerId, name, AnimalType.Cat)
        {

        }
    }
}