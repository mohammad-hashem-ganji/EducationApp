using App.Domain.Core.Entities;
using App.Domain.Core.Interfaces.AppServices;
using App.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class ProvinceAppService : IProvinceAppService
    {
        private readonly IProvinceService _provinceService;

        public ProvinceAppService(IProvinceService provinceAppService)
        {
            _provinceService = provinceAppService;
        }
        public async Task AddAsync(Province province) => await _provinceService.AddAsync(province);
        public async Task DeleteAsync(int id) => await _provinceService.DeleteAsync(id);
        public async Task<IEnumerable<Province>> GetAllAsync() => await _provinceService.GetAllAsync();
        public async Task<Province?> GetByIdAsync(int id) => await _provinceService.GetByIdAsync(id);
        public async Task UpdateAsync(Province province) => await _provinceService.UpdateAsync(province);
        public void GenerateRandomProvinces()
        {
            Random random = new Random();
            string[] provinceNames = new string[] { "Tehran", "Fars", "Isfahan", "Kerman", "Mazandaran", "Kurdistan", "Lorestan", "Khuzestan", "East Azerbaijan", "West Azerbaijan" };

            foreach (var name in provinceNames)
            {
                var province = new Province
                {
                    Name = $"{name} {random.Next(1000, 9999)}" 
                };
                _provinceService.AddAsync(province);
            }
        }
        public async void AddStarToProvinceName(int provinceId)
        {
            var province = await _provinceService.GetByIdAsync(provinceId); 

            if (province != null)
            {
                province.Name = "*" + province.Name; 
                await _provinceService.UpdateAsync(province);
            }
            
        }
    }
}
