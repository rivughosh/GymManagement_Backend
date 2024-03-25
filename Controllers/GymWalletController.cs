using AutoMapper;
using GymManagementWebAPI.BLL.DTOs.Requests;
using GymManagementWebAPI.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymWalletController : ControllerBase
    {
        private readonly IGymWalletService gymWalletService;
        private readonly IMapper mapper;

        public GymWalletController(IGymWalletService gymWalletService, IMapper mapper)
        {
            this.gymWalletService = gymWalletService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.gymWalletService.GetAll();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(GymWalletRequestDTO GymWalletDTO)
        {
            var result = await this.gymWalletService.Add(GymWalletDTO);
            return Ok(result);
        }
        [HttpGet("{GymWalletId}")]
        public async Task<IActionResult> GetByID(int GymWalletId)
        {
            var result = await this.gymWalletService.GetById(GymWalletId);
            return Ok(result);
        }
        [HttpGet("Member/{MemberId}")]
        public IActionResult GetWithMembersID(int MemberId)
        {
            var result = this.gymWalletService.GetWithMemberId(MemberId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpDelete("{GymWalletId}")]
        //[Authorize(roleName = "Admin")]
        public async Task<IActionResult> Delete(int GymWalletId)
        {

            var result = await this.gymWalletService.Delete(GymWalletId);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GymWalletRequestDTO requestDTO)
        {
            var result = await this.gymWalletService.Update(id, requestDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("Package/{id}")]
        public async Task<IActionResult> UpdatePackage(int id, [FromQuery] int PackageId, [FromQuery] string transactionNo, [FromQuery] int price)
        {
            var result = await this.gymWalletService.UpdatePackageWithMemberId(id, PackageId, transactionNo, price);
            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
