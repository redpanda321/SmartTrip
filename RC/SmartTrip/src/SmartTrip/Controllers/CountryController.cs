using System;
using System.Net;
using Microsoft.AspNet.Mvc;
using SmartTrip.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Hosting;
using System.IO;

namespace SmartTrip.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext db;

        private IHostingEnvironment env;

        public CountryController(ApplicationDbContext context,IHostingEnvironment hostingEnv)
        {
            db = context;
            env = hostingEnv;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

            string fileName = parsedContentDisposition.FileName.Trim('"');

            string filePath = Path.Combine(env.WebRootPath + "\\images\\" + fileName);

            await file.SaveAsAsync(filePath);

            //return filePath;
            return fileName;
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
        public async Task<IActionResult> Create(CountryViewModel model,IFormFile file)
        {
            //IFormFile
            var filePath = "";
            if (file != null)
                filePath = await SaveFile(file);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = new Country
            {
                CountryName = model.Country.CountryName,
                ImageUrl = (filePath.Length > 0) ? filePath : model.Country.ImageUrl

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
        public async Task<IActionResult> Edit(int id, Country model,IFormFile file)
        {
            //IFormFile
            var filePath = "";
            if (file != null)
                filePath = await SaveFile(file);


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

            country.ImageUrl = (filePath.Length > 0) ? filePath : model.ImageUrl;

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