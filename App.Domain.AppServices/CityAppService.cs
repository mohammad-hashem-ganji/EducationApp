using App.Domain.Core.Entities;
using App.Domain.Core.Interfaces.AppServices;
using App.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class CityAppService : ICityAppService
    {
        private readonly ICityService _cityService;

        public CityAppService(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task AddAsync(City city)
        {
            await _cityService.AddAsync(city);
        }

        public async Task DeleteAsync(int id) => await _cityService.DeleteAsync(id);

        public async Task<IEnumerable<City>> GetAllAsync() => await _cityService.GetAllAsync();

        public async Task<City?> GetByIdAsync(int id) => await _cityService.GetByIdAsync(id);

        public async Task UpdateAsync(City city) => await _cityService.UpdateAsync(city);
    }
}
