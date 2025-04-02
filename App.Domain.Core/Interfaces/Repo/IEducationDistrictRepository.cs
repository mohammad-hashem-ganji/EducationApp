using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Interfaces.Repo
{
    public interface IEducationDistrictRepository
    {
        Task<IEnumerable<EducationDistrict>> GetAllAsync();
        Task<EducationDistrict?> GetByIdAsync(int id);
        Task AddAsync(EducationDistrict district);
        void Update(EducationDistrict district);
        void Delete(EducationDistrict district);
        Task<IEnumerable<EducationDistrict>> GetEducationDistrictWithDetailsAsync();
    }

}
