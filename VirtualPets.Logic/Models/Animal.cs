using System;
using VirtualPets.Logic.Enums;

namespace VirtualPets.Logic.Models
{
    public abstract class Animal
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public User Owner { get; }
        public AnimalType Type { get; }
        public string Name { get; }
        
        private int _hunger;
        public int Hunger { 
            get { return _hunger; } 
            private set { if (value == 0) IsAlive = false; _hunger = value; }
        }
        public int Happiness { get; private set; }
        public bool IsAlive { get; private set; }

        abstract public int MAX_HUNGER { get; }
        abstract public int MAX_HAPPINESS { get; }
        abstract public int HUNGER_MOD { get; }
        abstract public int HAPPINESS_MOD { get; }


        public Animal(Guid ownerId, string name, AnimalType animalType)
        {
            OwnerId = ownerId;
            Id = Guid.NewGuid();
            Name = name;
            Type = animalType;
            Hunger = MAX_HUNGER / 2;
            Happiness = MAX_HAPPINESS / 2;
            IsAlive = true;
        }

        public virtual void Feed()
        {
            if (!IsAlive)
                throw new InvalidOperationException("Dead animals don't eat");
            if (Hunger == MAX_HUNGER)
                throw new InvalidOperationException("The animal can't eat more!");

            if (Hunger + HUNGER_MOD > MAX_HUNGER)
                Hunger = MAX_HUNGER;
            else
                Hunger += HUNGER_MOD;
        }

        public virtual void Stroke()
        {
            if (!IsAlive)
                throw new InvalidOperationException("You shouldn't touch a dead animal");
            if (Happiness == MAX_HAPPINESS)
                throw new InvalidOperationException("The animal needs some alone time");

            if (Happiness + HAPPINESS_MOD > MAX_HAPPINESS)
                Happiness = MAX_HAPPINESS;
            else
                Happiness += HAPPINESS_MOD;
        }

        public virtual void LowerHunger()
        {
            if (!IsAlive)
                throw new InvalidOperationException("Dead animals don't eat");

            if (Hunger - HUNGER_MOD < 0)
                Hunger = 0;
            else
                Hunger -= HUNGER_MOD;
        }

        public virtual void LowerHappiness()
        {
            if (!IsAlive)
                throw new InvalidOperationException("You shouldn't touch a dead animal");

            if (Happiness - HAPPINESS_MOD < 0)
                Happiness = 0;
            else
                Happiness -= HAPPINESS_MOD;
        }
    }
}