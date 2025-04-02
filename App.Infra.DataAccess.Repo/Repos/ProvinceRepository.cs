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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly EducationDbContext _context;

        public ProvinceRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Province>> GetAllAsync() => await _context.Provinces.ToListAsync();
        public async Task<Province?> GetByIdAsync(int id) => await _context.Provinces.FindAsync(id);
        public async Task AddAsync(Province province) => await _context.Provinces.AddAsync(province);
        public void Update(Province province) => _context.Provinces.Update(province);
        public void Delete(Province province) => _context.Provinces.Remove(province);
    }

}
