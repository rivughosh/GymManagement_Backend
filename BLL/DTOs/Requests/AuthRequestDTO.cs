namespace GymManagementWebAPI.BLL.DTOs.Requests
{
    public class AuthRequestDTO
    {
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
