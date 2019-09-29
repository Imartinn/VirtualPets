using System;
using System.Collections.Generic;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateNullAndOwnerOrThrow(Guid userId, Animal animal)
        {
            if (animal is null)
                throw new KeyNotFoundException("We don't have that animal");
            else if (userId != animal.OwnerId)
                throw new UnauthorizedAccessException("That animal isn't yours");
        }
    }
}
