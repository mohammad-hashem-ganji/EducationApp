using App.Domain.Core.DTOs;
using App.Domain.Core.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.mvc.Controllers
{
    public class EducationDistrictController : Controller
    {
        private readonly IEducationDistrictAppService _educationDistrictAppService;

        public EducationDistrictController(IEducationDistrictAppService educationDistrictAppService)
        {
            _educationDistrictAppService = educationDistrictAppService;
        }


        public async Task<IActionResult> GetEducationDistrictDetails()
        {
            List<EducationDistrictDetailsDto> districts = await _educationDistrictAppService.GetEducationDistrictDetailsAsync();
            
            return View(districts);
        }
    }
}
