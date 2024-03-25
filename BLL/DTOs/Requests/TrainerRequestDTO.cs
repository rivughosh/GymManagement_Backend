namespace GymManagement.BLL.DTOs.Request
{
    public class TrainerRequestDTO
    {
        public string Name { get; set; } = null!;
        public string Slot { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
