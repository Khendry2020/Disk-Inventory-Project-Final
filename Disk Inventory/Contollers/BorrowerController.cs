using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disk_Inventory.Models;

namespace DiskInventory.Controllers
{
    public class BorrowerController : Controller
    {
        private Disk_InventoryKH2Context context { get; set; }

        public BorrowerController(Disk_InventoryKH2Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            List<Borrower> borrowers = context.Borrower.OrderBy(b => b.LastName).ThenBy(b => b.FirstName).ToList();
            return View(borrowers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Borrower());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Add";
            var borrower = context.Borrower.Find(id);
            return View(borrower);
        }

        [HttpPost]
        public IActionResult Edit(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                if (borrower.BorrowerId == 0)
                {
                    context.Add(borrower);
                }
                else
                {
                    context.Borrower.Update(borrower);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Borrower");
            }
            else
            {
                ViewBag.Action = (borrower.BorrowerId == 0) ? "Add" : "Edit";

                return View(borrower);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var borrower = context.Borrower.Find(id);
            return View(borrower);
        }

        [HttpPost]
        public IActionResult Delete(Borrower borrower)
        {
            context.Borrower.Remove(borrower);
            context.SaveChanges();
            return RedirectToAction("Index", "Borrower");
        }
    }
}
