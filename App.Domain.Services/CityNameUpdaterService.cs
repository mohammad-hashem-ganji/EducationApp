﻿using App.Domain.Core.Interfaces.Repo;
using App.Domain.Core.Interfaces.UOf;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CityNameUpdaterService> _logger;

        public CityNameUpdaterService(IServiceProvider serviceProvider, ILogger<CityNameUpdaterService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
         
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
         
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var cities = await unitOfWork.Cities.GetAllAsync();
                foreach (var city in cities)
                {
                    city.Name = "*" + city.Name; 
                    unitOfWork.Cities.Update(city); 
                }
                await unitOfWork.CompleteAsync(); 

                _logger.LogInformation("City names updated with a star at {time}", DateTimeOffset.Now);
            }
        }
    }
}
