using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disk_Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace DiskInventory.Controllers
{
    public class DiskController : Controller
    {
        private Disk_InventoryKH2Context context { get; set; }

        public DiskController(Disk_InventoryKH2Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            List<Disk> disks = context.Disk.OrderBy(d => d.DiskId).Include(g => g.Genre).Include(s => s.Status).Include(t => t.DiskType).ToList();
            return View(disks);
        }

        //Add To database
        [HttpGet]
        public IActionResult Add()
        {
            //sets all options from the SQL server to the view bag accordingly to be used on the ADD page
            ViewBag.Action = "Add";
            ViewBag.Genre = context.Genre.OrderBy(g => g.Genre1).ToList();
            ViewBag.Status = context.Status.OrderBy(s => s.IsBorrowed).ToList();
            ViewBag.DiskType = context.DiskType.OrderBy(t => t.Type).ToList();

            return View("Edit", new Disk());
        }
        //Edit Database --------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //sets all options from the SQL server to the view bag accordingly to be used on the Add() Class
            ViewBag.Action = "Add";
            ViewBag.Genre = context.Genre.OrderBy(g => g.Genre1).ToList();
            ViewBag.Status = context.Status.OrderBy(s => s.IsBorrowed).ToList();
            ViewBag.DiskType = context.DiskType.OrderBy(t => t.Type).ToList();
            var disk = context.Disk.Find(id);

            return View(disk);
        }
        //ADD to Database
        [HttpPost]
        public IActionResult Edit(Disk disk)
        {
            if (ModelState.IsValid)
            {
                if (disk.DiskId == 0)
                {
                    context.Add(disk);
                }
                else
                {
                    context.Disk.Update(disk);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Disk");
            }
            else
            {
                ViewBag.Action = (disk.DiskId == 0) ? "Add" : "Edit";
                ViewBag.Genre = context.Genre.OrderBy(g => g.Genre1).ToList();
                ViewBag.Status = context.Status.OrderBy(s => s.IsBorrowed).ToList();
                ViewBag.DiskType = context.DiskType.OrderBy(t => t.Type).ToList();

                return View(disk);
            }
        }
        //Deletes entry based off the DiskID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var disk = context.Disk.Find(id);
            return View(disk);
        }

        [HttpPost]
        public IActionResult Delete(Disk disk)
        {
            context.Disk.Remove(disk);
            context.SaveChanges();
            return RedirectToAction("index", "Disk");
        }
    }
}
