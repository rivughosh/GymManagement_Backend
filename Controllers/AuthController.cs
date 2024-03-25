using GymManagementWebAPI.BLL.DTOs.Requests;
using GymManagementWebAPI.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthRequestDTO requestDTO)
        {
            var result = await authService.ValidateUsers(requestDTO);
            if(result != null)
            {
                return Ok(result);
            }
            return Unauthorized(new {message = "Wrong user input" });
        }
    }
}
