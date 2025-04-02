using App.Domain.Core.Entities;
using App.Domain.Core.Interfaces.Repo;
using App.Infra.DB.SqlServer.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Repos
{
    public class EducationDistrictRepository : IEducationDistrictRepository
    {
        private readonly EducationDbContext _context;

        public EducationDistrictRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EducationDistrict>> GetAllAsync() => await _context.EducationDistricts.ToListAsync();
        public async Task<EducationDistrict?> GetByIdAsync(int id) => await _context.EducationDistricts.FindAsync(id);
        public async Task AddAsync(EducationDistrict educationDistrict) => await _context.EducationDistricts.AddAsync(educationDistrict);
        public void Update(EducationDistrict educationDistrict ) => _context.EducationDistricts.Update(educationDistrict);
        public void Delete(EducationDistrict educationDistrict) => _context.EducationDistricts.Remove(educationDistrict);
        public async Task<IEnumerable<EducationDistrict>> GetEducationDistrictWithDetailsAsync()
        {
            return await _context.EducationDistricts
                .Include(ed => ed.City)
                .ThenInclude(c => c.Province)
                .ToListAsync();
        }

    }
}
