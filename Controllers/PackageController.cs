using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagementWebAPI.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;
        private readonly IMapper mapper;

        public PackageController(IPackageService packageService, IMapper mapper)
        {
            this.packageService = packageService;
            this.mapper = mapper;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PackageRequestDTO PackageDTO)
        {
            var result = await this.packageService.Add(PackageDTO);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.packageService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await this.packageService.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await this.packageService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PackageRequestDTO requestDTO)
        {
            var result = await this.packageService.Update(id, requestDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
