namespace GymManagementWebAPI.BLL.DTOs.Responses
{
    public class PackageResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Duration { get; set; }
        public int Cost { get; set; }
    }
}
