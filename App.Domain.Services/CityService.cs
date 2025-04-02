using App.Domain.Core.Entities;
using App.Domain.Core.Interfaces.Services;
using App.Domain.Core.Interfaces.UOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<City>> GetAllAsync() => await _unitOfWork.Cities.GetAllAsync();

        public async Task<City?> GetByIdAsync(int id) => await _unitOfWork.Cities.GetByIdAsync(id);

        public async Task AddAsync(City city)
        {
            await _unitOfWork.Cities.AddAsync(city);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(City city)
        {
            _unitOfWork.Cities.Update(city);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city != null)
            {
                _unitOfWork.Cities.Delete(city);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
