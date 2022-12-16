using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Disk_Inventory.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            DiskBorrower = new HashSet<DiskBorrower>();
        }

        public int BorrowerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<DiskBorrower> DiskBorrower { get; set; }
    }
}
