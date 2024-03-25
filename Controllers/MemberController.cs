using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagementWebAPI.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;
        private readonly IMapper mapper;

        public MemberController(IMemberService memberService, IMapper mapper)
        {
            this.memberService = memberService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MemberRequestDTO MemberDTO)
        {
            var result = await this.memberService.Add(MemberDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.memberService.GetAll();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByID(int id)
        //{
        //    var result = await this.memberService.GetById(id);
        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithTrainer(int id)
        {
            var result = await this.memberService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await this.memberService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MemberRequestDTO requestDTO)
        {
            var result = await this.memberService.Update(id, requestDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut("UpdateTrainer/{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, int trainerId)
        {
            var result = await this.memberService.UpdtaeWithTrainer(id, trainerId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
