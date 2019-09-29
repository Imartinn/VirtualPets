using System;
using VirtualPets.Logic.Enums;

namespace VirtualPets.Logic.Models
{
    public class Parrot : Animal
    {
        public override int MAX_HUNGER { get => 10; }
        public override int MAX_HAPPINESS { get => 10; }
        public override int HUNGER_MOD { get => 2; }
        public override int HAPPINESS_MOD { get => 2; }

        public Parrot(Guid ownerId, string name) : base(ownerId, name, AnimalType.Parrot)
        {

        }
    }
}