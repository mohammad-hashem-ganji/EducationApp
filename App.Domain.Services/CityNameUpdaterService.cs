using App.Domain.Core.Interfaces.Repo;
using App.Domain.Core.Interfaces.UOf;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CityNameUpdaterService : BackgroundService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CityNameUpdaterService> _logger;

        public CityNameUpdaterService(IUnitOfWork unitOfWork, ILogger<CityNameUpdaterService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Run the task at 8 AM daily
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                if (now.Hour == 8 && now.Minute == 0)
                {
                    await AddStarToCityNames();
                }

        
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        
        private async Task AddStarToCityNames()
        {
            var cities = _unitOfWork.Cities.GetAllAsync();
            foreach (var city in cities.Result)
            {
                city.Name = "*" + city.Name;
                _unitOfWork.Cities.Update(city);
            }
            await _unitOfWork.CompleteAsync(); 

            _logger.LogInformation("City names updated with a star at {time}", DateTimeOffset.Now);
        }
    }
}
