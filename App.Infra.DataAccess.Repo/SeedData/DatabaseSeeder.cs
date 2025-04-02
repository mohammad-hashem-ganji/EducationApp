using App.Domain.Core.Entities;
using App.Infra.DB.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.SeedData
{
    public class DatabaseSeeder
    {
        private readonly EducationDbContext _context;

        public DatabaseSeeder(EducationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Provinces.Any())
            {
                var tehranProvince = new Province { Name = "Tehran" };
                var farsProvince = new Province { Name = "Fars" };

                // Add provinces and save changes to generate their Ids
                _context.Provinces.AddRange(tehranProvince, farsProvince);
                _context.SaveChanges();  // Save to generate Ids for the Provinces
            }

            // Now, since the Ids are generated for Provinces, use them in the Cities
            if (!_context.Cities.Any())
            {
                var tehranProvinceId = _context.Provinces.First(p => p.Name == "Tehran").Id;
                var farsProvinceId = _context.Provinces.First(p => p.Name == "Fars").Id;

                _context.Cities.AddRange(
                    new City { Name = "Tehran City", ProvinceId = tehranProvinceId },
                    new City { Name = "Shiraz", ProvinceId = farsProvinceId }
                );
                _context.SaveChanges();  // Save Cities after ensuring valid ProvinceId
            }

            // Now, insert EducationDistricts with valid CityId references
            if (!_context.EducationDistricts.Any())
            {
                var tehranCityId = _context.Cities.First(c => c.Name == "Tehran City").Id;
                var shirazCityId = _context.Cities.First(c => c.Name == "Shiraz").Id;

                _context.EducationDistricts.AddRange(
                    new EducationDistrict { Name = "District 1", CityId = tehranCityId },
                    new EducationDistrict { Name = "District 2", CityId = shirazCityId }
                );
                _context.SaveChanges();  // Save EducationDistricts
            }
        }
    }
}
