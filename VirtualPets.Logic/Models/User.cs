using System;
using System.Collections.Generic;

namespace VirtualPets.Logic.Models
{
    public class User
    {
        public Guid Id { get; set; }      
        public string Name { get; set; }  
        public ICollection<Animal> Pets {get; set;}

        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;            
        }
    }
}