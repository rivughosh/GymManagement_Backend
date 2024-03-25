using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagementWebAPI.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService trainerService;
        private readonly IMapper mapper;

        public TrainerController(ITrainerService trainerService, IMapper mapper)
        {
            this.trainerService = trainerService;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(TrainerRequestDTO TrainerDTO)
        {
            var result = await this.trainerService.Add(TrainerDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.trainerService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await this.trainerService.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await this.trainerService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrainerRequestDTO requestDTO)
        {
            var result = await this.trainerService.Update(id, requestDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
