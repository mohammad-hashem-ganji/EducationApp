using App.Domain.Core.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Interfaces.UOf
{
    public interface IUnitOfWork : IDisposable
    {
        IProvinceRepository Provinces { get; }
        ICityRepository Cities { get; }
        IEducationDistrictRepository EducationDistricts { get; }
        Task<int> CompleteAsync();
    }

}
