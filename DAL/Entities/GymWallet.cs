using System;
using System.Collections.Generic;

namespace GymManagementWebAPI.DAL.Entities
{
    public partial class GymWallet
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int MemberId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string TransactionNo { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;
        public virtual Package Package { get; set; } = null!;
    }
}
