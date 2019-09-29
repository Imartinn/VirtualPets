using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VirtualPets.Logic.Data;
using VirtualPets.Logic.Interfaces;

namespace VirtualPets.Workers
{
    public class AnimalStatusWorker : BackgroundService
    {
        private readonly ILogger<AnimalStatusWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AnimalStatusWorker(ILogger<AnimalStatusWorker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int secondsInterval = 10;

            using var scope = _serviceProvider.CreateScope();
            
            var dbContext = scope.ServiceProvider.GetService<VirtualPetsDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            var _animalStatusService = scope.ServiceProvider.GetRequiredService<IAnimalStatusService>();
            var _adoptionService = scope.ServiceProvider.GetRequiredService<IAdoptionService>();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var animals = await _adoptionService.GetAnimalsAsync().ConfigureAwait(false);

                foreach (var animalId in animals.Select(x => x.Id))
                {
                    await _animalStatusService.LowerHappiness(animalId).ConfigureAwait(false);
                    await _animalStatusService.LowerHunger(animalId).ConfigureAwait(false);
                }

                await Task.Delay(1000 * secondsInterval, stoppingToken);
            }
        }
    }
}
