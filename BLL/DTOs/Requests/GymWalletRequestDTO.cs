namespace GymManagementWebAPI.BLL.DTOs.Requests
{
    public class GymWalletRequestDTO
    {
        public int PackageId { get; set; }
        public int MemberId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string TransactionNo { get; set; } = null!;
    }
}