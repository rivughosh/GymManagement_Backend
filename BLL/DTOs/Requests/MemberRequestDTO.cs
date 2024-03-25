namespace GymManagement.BLL.DTOs.Request
{
    public class MemberRequestDTO
    {
        public string UserId { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public int? TrainerId { get; set; }
        
    }
}
