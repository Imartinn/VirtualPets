using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualPets.Logic.Dtos;
using VirtualPets.Logic.Interfaces;

namespace VirtualPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayingController : ControllerBase
    {
        private readonly ILogger<PlayingController> _logger;
        private readonly IPlayingService _playingService;

        public PlayingController(ILogger<PlayingController> logger, IPlayingService playingService)
        {
            _logger = logger;
            _playingService = playingService;
        }

        /// <summary>
        /// Strokes the animal
        /// </summary>
        [HttpPost]
        public async Task StrokeAsync([FromQuery]UserAnimalIdsDto data)
        {
            await _playingService.StrokeAnimalAsync(data.UserId, data.AnimalId);
        }
    }
}
