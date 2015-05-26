using System;
using System.Net;
using Microsoft.AspNet.Mvc;
using SmartTrip.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Hosting;
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Mvc.Rendering;

namespace SmartTrip.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext db;

        private IHostingEnvironment env;

        public CityController(ApplicationDbContext context,IHostingEnvironment hostingEnv )
        {
            db = context;
            env = hostingEnv;
        }

        public IActionResult Index()
        {
            var cities = db.Cities.ToList();
           return View(cities);
        }
  
        public IActionResult Create()
        {
           
            var cityViewModel = new CityViewModel();
            cityViewModel.Countries = new SelectList(db.Countries.ToList(), "Id", "CountryName");
            return View(cityViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,CityViewModel model)
        {

            //IFormFile
            var filePath = "";
            if (file != null)
                filePath = await SaveFile(file);


            //CityViewModel

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var city = new City
            {

                CityName = model.City.CityName,
                ImageUrl = (filePath.Length > 0) ? filePath : model.City.ImageUrl,
                Summary = model.City.Summary,
                CountryId = model.City.CountryId

            };

            db.Cities.Add(city);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {

           
            var city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }

            var cityViewModel = new CityViewModel {
                City = city
            };
            cityViewModel.Countries = new SelectList(db.Countries.ToList(), "Id", "CountryName");
            
            return View(cityViewModel);
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


        [HttpPost]
        public async Task<IActionResult> Edit(int id, CityViewModel model,IFormFile file)
        {

            //IFormFile
            var filePath = "";
            if (file != null)
                filePath = await SaveFile(file);
           
            //CityViewModel
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }


            
            city.CityName = model.City.CityName;
            city.ImageUrl = (filePath.Count()>0)? filePath : model.City.ImageUrl;
            city.Summary = model.City.Summary;
            city.CountryId = model.City.CountryId;
            

            // TODO Exception handling
            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }

        // GET: Cities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            City city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            City city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            db.Cities.Remove(city);
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