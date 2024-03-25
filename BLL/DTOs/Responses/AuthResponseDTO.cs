namespace GymManagementWebAPI.BLL.DTOs.Responses
{
    public class AuthResponseDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? RoleName { get; set; }
        public string? LoginToken { get; set; }
    }
}
