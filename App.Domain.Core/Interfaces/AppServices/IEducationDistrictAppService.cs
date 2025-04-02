using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Interfaces.AppServices
{
    public interface IEducationDistrictAppService
    {
        Task<IEnumerable<EducationDistrict>> GetAllAsync();
        Task<EducationDistrict?> GetByIdAsync(int id);
        Task AddAsync(EducationDistrict educationDistrict);
        Task UpdateAsync(EducationDistrict educationDistrict);
        Task DeleteAsync(int id);
        Task<List<EducationDistrictDetailsDto>> GetEducationDistrictDetailsAsync();
    }
}
