using App.Domain.Core.Interfaces.Repo;
using App.Domain.Core.Interfaces.UOf;
using App.Infra.DataAccess.Repo.Repos;
using App.Infra.DB.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Uof
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationDbContext _context;

        public UnitOfWork(EducationDbContext context)
        {
            _context = context;
            Provinces = new ProvinceRepository(_context);
            Cities = new CityRepository(_context);
            EducationDistricts = new EducationDistrictRepository(_context);
        }

        public IProvinceRepository Provinces { get; }
        public ICityRepository Cities { get; }
        public IEducationDistrictRepository EducationDistricts { get; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
