using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualPets.Logic.Dtos;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Models;

namespace VirtualPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalStatusController : ControllerBase
    {
        private readonly ILogger<AnimalStatusController> _logger;
        private readonly IAnimalStatusService _animalStatusService;

        public AnimalStatusController(ILogger<AnimalStatusController> logger, IAnimalStatusService animalStatusService)
        {
            _logger = logger;
            _animalStatusService = animalStatusService;
        }

        [HttpGet]
        [Route("GetHappiness")]
        public async Task<int> GetHappinessAsync([FromQuery]UserAnimalIdsDto data)
        {
            return await _animalStatusService.GetHappinessAsync(data.UserId, data.AnimalId);
        }

        [HttpGet]
        [Route("GetHunger")]
        public async Task<int> GetHungerAsync([FromQuery]UserAnimalIdsDto data)
        {
            return await _animalStatusService.GetHungerAsync(data.UserId, data.AnimalId);
        }
        
        [HttpGet]
        [Route("GetFullInfo")]
        public async Task<Animal> GetFullAnimalInfoAsync([FromQuery]UserAnimalIdsDto data)
        {
            return await _animalStatusService.GetFullAnimalInfoAsync(data.UserId, data.AnimalId);
        }
    }
}
