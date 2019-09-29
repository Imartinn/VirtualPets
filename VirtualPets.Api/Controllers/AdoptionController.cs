using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualPets.Logic.Dtos;
using VirtualPets.Logic.Enums;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Projections;

namespace VirtualPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdoptionController : ControllerBase
    {
        private readonly ILogger<AdoptionController> _logger;
        private readonly IAdoptionService _adoptionService;

        public AdoptionController(ILogger<AdoptionController> logger, IAdoptionService adoptionService)
        {
            _logger = logger;
            _adoptionService = adoptionService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<AnimalBasicInfo>> GetAnimalsBasicInfoAsync()
        {
            return await _adoptionService.GetAnimalsAsync();
        }

        [HttpGet]
        [Route("GetTypes")]
        public IEnumerable<string> GetAnimalTypes()
        {
            return Enum.GetNames(typeof(AnimalType));
        }

        [HttpPost]
        public async Task<Guid> AdoptAnimalAsync([FromBody]AdoptAnimalDto data)
        {
            return await _adoptionService.AdoptAnimalAsync(data.AdopterId, data.Name, data.Type);
        }
    }
}
