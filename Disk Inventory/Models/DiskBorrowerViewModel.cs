using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disk_Inventory.Models
{
    public class DiskBorrowerViewModel
    {
        public int DiskBorrowerId { get; set; }
        public int? BorrowerId { get; set; }
        public int? DiskId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Disk Disk { get; set; }

        public List<Borrower> Borrowers { get; set; }
        public List<Disk> Disks { get; set; }

    }
}
