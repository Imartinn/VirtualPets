using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualPets.Logic.Dtos;
using VirtualPets.Logic.Interfaces;

namespace VirtualPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedingController : ControllerBase
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly IFeedingService _feedingService;

        public FeedingController(ILogger<FeedingController> logger, IFeedingService feedingService)
        {
            _logger = logger;
            _feedingService = feedingService;
        }

        [HttpPost]
        public async Task FeedAsync([FromQuery]UserAnimalIdsDto data)
        {
            await _feedingService.FeedAnimalAsync(data.UserId, data.AnimalId);
        }
    }
}
