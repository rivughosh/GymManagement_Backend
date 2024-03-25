using System;
using System.Collections.Generic;

namespace GymManagementWebAPI.DAL.Entities
{
    public partial class Member
    {
        public Member()
        {
            GymWallets = new HashSet<GymWallet>();
        }

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

        public virtual Trainer? Trainer { get; set; }
        public virtual ICollection<GymWallet> GymWallets { get; set; }
    }
}
