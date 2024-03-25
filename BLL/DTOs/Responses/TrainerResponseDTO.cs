namespace GymManagementWebAPI.BLL.DTOs.Responses
{
    public class TrainerResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slot { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
