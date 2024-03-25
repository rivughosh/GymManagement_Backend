using AutoMapper;
using GymManagementWebAPI.BLL.DTOs.Requests;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Repository;
using GymManagementWebAPI.Infrastructure;

namespace GymManagementWebAPI.BLL.Services
{
    public interface IAuthService
    {
        public Task<AuthResponseDTO?> ValidateUsers(AuthRequestDTO authRequestDTO);
    }
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;
        private IMapper mapper;

        public AuthService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration, IMapper mapper) 
        {
            this.repositoryWrapper = repositoryWrapper;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<AuthResponseDTO?> ValidateUsers(AuthRequestDTO authRequestDTO)
        {
            var user = await this.repositoryWrapper.MemberRepository.ValidateUser(authRequestDTO.UserId, authRequestDTO.Password);
            if (user != null)
            {
                var issuer = configuration["JWT:ValidIssuer"];
                var audience = configuration["JWT:ValidAudiance"];
                var secret = configuration["JWT:Secret"];
                var roleName = user.IsAdmin ? "Admin" : "User";
                var token = JWTGenerator.GenerateToken(issuer, audience, user.Id.ToString(), user.UserId, roleName, secret);
                var result = new AuthResponseDTO
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    RoleName = roleName,
                    LoginToken = token,
                };
                return result;
            }
            return null;
        }

    }
}
