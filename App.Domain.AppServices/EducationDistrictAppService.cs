using App.Domain.Core.DTOs;
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
    public class EducationDistrictAppService : IEducationDistrictAppService
    {
        private readonly IEducationDistrictService _educationDistrictService;

        public EducationDistrictAppService(IEducationDistrictService educationDistrictService)
        {
            _educationDistrictService = educationDistrictService;
        }

        public async Task AddAsync(EducationDistrict educationDistrict) => await _educationDistrictService.AddAsync(educationDistrict);
        public async Task DeleteAsync(int id) => await _educationDistrictService.DeleteAsync(id);
        public async Task<IEnumerable<EducationDistrict>> GetAllAsync() => await _educationDistrictService.GetAllAsync();
        public async Task<EducationDistrict?> GetByIdAsync(int id) => await _educationDistrictService.GetByIdAsync(id);

        public async Task<List<EducationDistrictDetailsDto>> GetEducationDistrictDetailsAsync() => await _educationDistrictService.GetEducationDistrictDetailsAsync();

        public async Task UpdateAsync(EducationDistrict educationDistrict) => await _educationDistrictService.UpdateAsync(educationDistrict);
    }
}
