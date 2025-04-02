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
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Province>> GetAllAsync() => await _unitOfWork.Provinces.GetAllAsync();

        public async Task<Province?> GetByIdAsync(int id) => await _unitOfWork.Provinces.GetByIdAsync(id);

        public async Task AddAsync(Province province)
        {
            await _unitOfWork.Provinces.AddAsync(province);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Province province)
        {
            _unitOfWork.Provinces.Update(province);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var province = await _unitOfWork.Provinces.GetByIdAsync(id);
            if (province != null)
            {
                _unitOfWork.Provinces.Delete(province);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
