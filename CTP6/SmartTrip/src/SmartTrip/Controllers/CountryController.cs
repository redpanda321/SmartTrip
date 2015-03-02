using System;
using System.Net;
using Microsoft.AspNet.Mvc;
using SmartTrip.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc.Rendering;

namespace SmartTrip.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CountryController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var countries = db.Countries.ToList();

            return View(countries);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = new Country
            {
                UserName = model.UserName,
                CountryName = model.CountryName,
             
            };

            db.Countries.Add(country);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
            var country = await db.Countries.SingleOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return HttpNotFound();
            }

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CountryEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = await db.Countries.SingleOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return HttpNotFound();
            }

            country.CountryName = model.CountryName;
            country.UserName = model.UserName;
      
            // TODO Exception handling
            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }

        // GET: Countries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Country country = await db.Countries.SingleOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Country country = await db.Countries.SingleOrDefaultAsync(x => x.Id == id);
            db.Countries.Remove(country);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}