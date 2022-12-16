using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Disk_Inventory.Models;

namespace Disk_Inventory.Contollers
{
    public class DiskBorrowerController : Controller
    {
        private Disk_InventoryKH2Context context { get; set; }

        public DiskBorrowerController(Disk_InventoryKH2Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var diskBorrower = context.DiskBorrower.Include(d => d.Disk).OrderBy(d => d.Disk.DiskName).Include(b => b.Borrower).ToList();
            return View(diskBorrower);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            DiskBorrowerViewModel checkout = new DiskBorrowerViewModel();
            checkout.BorrowedDate = DateTime.Now;
            checkout.Disks = context.Disk.OrderBy(d => d.DiskName).ToList();
            checkout.Borrowers = context.Borrower.OrderBy(b => b.LastName).ToList();
            return View("Edit", checkout);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var diskborrower = context.DiskBorrower.Find(id);
            DiskBorrowerViewModel checkout = new DiskBorrowerViewModel();
            checkout.Disks = context.Disk.OrderBy(d => d.DiskName).ToList();
            checkout.Borrowers = context.Borrower.OrderBy(b => b.LastName).ToList();
            checkout.DiskBorrowerId = diskborrower.DiskBorrowerId;
            checkout.BorrowerId = diskborrower.BorrowerId;
            checkout.DiskId = diskborrower.DiskId;
            checkout.BorrowedDate = diskborrower.BorrowedDate;
            checkout.ReturnedDate = diskborrower.ReturnedDate;
            return View(checkout);
        }

        [HttpPost]
        public IActionResult Edit(DiskBorrowerViewModel diskborrowerViewModel)
        {
            DiskBorrower checkout = new DiskBorrower();
            if (ModelState.IsValid)
            {
                checkout.DiskBorrowerId = diskborrowerViewModel.DiskBorrowerId;
                checkout.BorrowerId = diskborrowerViewModel.BorrowerId;
                checkout.DiskId = diskborrowerViewModel.DiskId;
                checkout.BorrowedDate = diskborrowerViewModel.BorrowedDate;
                checkout.ReturnedDate = diskborrowerViewModel.ReturnedDate;
                if (checkout.DiskBorrowerId == 0)
                {
                    context.DiskBorrower.Add(checkout);
                }
                else
                {
                    context.DiskBorrower.Update(checkout);
                }
                context.SaveChanges();

                return RedirectToAction("Index", "DiskBorrower");
            }
                ViewBag.Action = (diskborrowerViewModel.BorrowerId == 0) ? "Add" : "Edit";
            return View(diskborrowerViewModel);
        }
    }
}
