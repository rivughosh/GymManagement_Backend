using System;
using System.Collections.Generic;

namespace GymManagementWebAPI.DAL.Entities
{
    public partial class Package
    {
        public Package()
        {
            GymWallets = new HashSet<GymWallet>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Duration { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<GymWallet> GymWallets { get; set; }
    }
}
