using System.Text.Json.Serialization;

namespace GymManagementWebAPI.BLL.DTOs.Responses
{
    public class GymWalletResponseDTO
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public int MemberId { get; set; }
        public int PackageDuration { get; set; }

        [JsonIgnore]
        public string MemberFirstName { get; set; } = string.Empty;

        [JsonIgnore]
        public string MemberLastName { get; set; } = string.Empty;

        public string FullName => MemberFirstName + " " + MemberLastName;
        //Func<string, string, string> FullName = (FirstName, LastName) => $"{FirstName} {LastName}";

        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string TransactionNo { get; set; } = null!;
    }
}
