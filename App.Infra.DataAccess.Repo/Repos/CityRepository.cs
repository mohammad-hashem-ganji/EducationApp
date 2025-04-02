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
    public class CityRepository : ICityRepository
    {
        private readonly EducationDbContext _context;

        public CityRepository(EducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetAllAsync() => await _context.Cities.ToListAsync();
        public async Task<City?> GetByIdAsync(int id) => await _context.Cities.FindAsync(id);
        public async Task AddAsync(City city) => await _context.Cities.AddAsync(city);
        public void Update(City city) => _context.Cities.Update(city);
        public void Delete(City city) => _context.Cities.Remove(city);
    }
}
