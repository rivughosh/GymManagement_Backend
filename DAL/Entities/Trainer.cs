using System;
using System.Collections.Generic;

namespace GymManagementWebAPI.DAL.Entities
{
    public partial class Trainer
    {
        public Trainer()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slot { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Member> Members { get; set; }
    }
}
