using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Disk_Inventory.Models
{
    public partial class Status
    {
        public Status()
        {
            Disk = new HashSet<Disk>();
        }

        public int StatusId { get; set; }
        public bool IsBorrowed { get; set; }

        public virtual ICollection<Disk> Disk { get; set; }
    }
}
