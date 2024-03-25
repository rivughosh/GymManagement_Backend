using GymManagementWebAPI.DAL.Entities;

namespace GymManagementWebAPI.BLL.DTOs.Responses
{
    public class MemberResponseDTO
    {
        public int Id { get; set; }
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
        public string? TrainerName { get; set; }

        //public List<GymWalletDTO> Wallet { get; set; } = null!;
    }
    //public class GymWalletDTO
    //{
    //    public int Id { get; set; }
    //    public string Status { get; set; } = null!;
    //    public DateTime CreatedAt { get; set; }
    //    public int Price { get; set; }
    //    public string TransactionNo { get; set; } = null!;
    //}
}