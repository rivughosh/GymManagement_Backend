namespace GymManagement.BLL.DTOs.Request
{
    public class PackageRequestDTO
    {
        public string Name { get; set; } = null!;
        public int Duration { get; set; }
        public int Cost { get; set; }
    }
}
