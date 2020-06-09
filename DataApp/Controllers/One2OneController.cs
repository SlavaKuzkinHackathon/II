using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataApp.Controllers
{
    public class One2OneController : Controller
    {
        private EFDatabaseContext context;

        public One2OneController(EFDatabaseContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return View(context.Set<ContactDetails>().Include(cd => cd.Supplier));
        }

        public IActionResult Create() => View("ContactEditor");

        public IActionResult Edit(long id) {
            return View("ContactEditor",
                context.Set<ContactDetails>()
                .Include(cd => cd.Supplier).First(cd => cd.Id == id));
        }

        [HttpPost]
        public IActionResult Update(ContactDetails details) {
            if (details.Id == 0) {
                context.Add<ContactDetails>(details);
            }else {
                context.Update<ContactDetails>(details);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
