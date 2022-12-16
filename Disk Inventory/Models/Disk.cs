using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Disk_Inventory.Models
{
    public partial class Disk
    {
        public Disk()
        {
            DiskBorrower = new HashSet<DiskBorrower>();
        }

        public int DiskId { get; set; }
        public string DiskName { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DiskTypeId { get; set; }
        public int StatusId { get; set; }
        public int GenreId { get; set; }

        public virtual DiskType DiskType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<DiskBorrower> DiskBorrower { get; set; }
    }
}
