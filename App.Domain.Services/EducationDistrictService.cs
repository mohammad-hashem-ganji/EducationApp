using App.Domain.Core.DTOs;
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
    public class EducationDistrictService : IEducationDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationDistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EducationDistrict>> GetAllAsync() => await _unitOfWork.EducationDistricts.GetAllAsync();

        public async Task<EducationDistrict?> GetByIdAsync(int id) => await _unitOfWork.EducationDistricts.GetByIdAsync(id);

        public async Task AddAsync(EducationDistrict educationDistrict)
        {
            await _unitOfWork.EducationDistricts.AddAsync(educationDistrict);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(EducationDistrict educationDistrict)
        {
            _unitOfWork.EducationDistricts.Update(educationDistrict);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var educationDistrict = await _unitOfWork.EducationDistricts.GetByIdAsync(id);
            if (educationDistrict != null)
            {
                _unitOfWork.EducationDistricts.Delete(educationDistrict);
                await _unitOfWork.CompleteAsync();
            }
        }
        public async Task<List<EducationDistrictDetailsDto>> GetEducationDistrictDetailsAsync()
        {
            var result = await _unitOfWork.EducationDistricts.GetEducationDistrictWithDetailsAsync();
            return result.Select(ed => new EducationDistrictDetailsDto
            {
                ProvinceName = ed.City.Province.Name,
                CityName = ed.City.Name,
                EducationDistrictName = ed.Name
            }).ToList();
        }
    }

}
