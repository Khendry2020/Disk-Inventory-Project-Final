using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Disk_Inventory.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Disk = new HashSet<Disk>();
        }

        public int GenreId { get; set; }
        public string Genre1 { get; set; }

        public virtual ICollection<Disk> Disk { get; set; }
    }
}
