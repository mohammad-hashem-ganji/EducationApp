using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Interfaces.AppServices
{
    public interface IProvinceAppService
    {
        Task<IEnumerable<Province>> GetAllAsync();
        Task<Province?> GetByIdAsync(int id);
        Task AddAsync(Province province);
        Task UpdateAsync(Province province);
        Task DeleteAsync(int id);
    }
}
