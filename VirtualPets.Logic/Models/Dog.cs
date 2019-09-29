using System;
using VirtualPets.Logic.Enums;

namespace VirtualPets.Logic.Models
{
    public class Dog : Animal
    {
        public override int MAX_HUNGER { get => 50; }
        public override int MAX_HAPPINESS { get => 50; }
        public override int HUNGER_MOD { get => 10; }
        public override int HAPPINESS_MOD { get => 10; }

        public Dog(Guid ownerId, string name) : base(ownerId, name, AnimalType.Dog)
        {

        }
    }
}