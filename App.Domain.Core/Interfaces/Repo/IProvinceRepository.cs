using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Interfaces.Repo
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetAllAsync();
        Task<Province?> GetByIdAsync(int id);
        Task AddAsync(Province province);
        void Update(Province province);
        void Delete(Province province);
    }

}
