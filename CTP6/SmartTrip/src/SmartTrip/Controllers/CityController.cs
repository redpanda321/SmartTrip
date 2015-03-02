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
            
            var countries =  db.Countries.AsEnumerable();

            List<string> countriesList = new List<string>();

           foreach  ( var  country  in  countries)
            {
                countriesList.Add(country.CountryName);
            }

            ViewBag.countries = new SelectList(countriesList);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,CityEditModel model)
        {

            //IFormFile
            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

            string fileName = parsedContentDisposition.FileName.Trim('"');

            string filePath = Path.Combine(env.WebRoot + "\\images\\" + fileName);

            await file.SaveAsAsync(filePath);

       
            //CityEditModel

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var city = new City
            {
                UserName = model.UserName,
                CityName = model.CityName,
                ImageUrl = (filePath.Length > 0) ? filePath : model.ImageUrl,
                Summary = model.Summary,
                CountryName = model.CountryName

            };

            db.Cities.Add(city);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
            //ViewBag
            var countries = db.Countries.AsEnumerable();

            List<string> countriesList = new List<string>();

            foreach (var country in countries)
            {
                countriesList.Add(country.CountryName);
            }
            
            ViewBag.countries = new SelectList(countriesList);
            
            
            var city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CityEditModel model,IFormFile file)
        {

            //IFormFile
            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

            string fileName = parsedContentDisposition.FileName.Trim('"');

            string filePath = Path.Combine(env.WebRoot + "\\images\\" + fileName);

            await file.SaveAsAsync(filePath);

           
            //CityEditModel
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var city = await db.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }


            city.UserName = model.UserName;
            city.CityName = model.CityName;
            city.ImageUrl = (filePath.Count()>0)? filePath : model.ImageUrl;
            city.Summary = model.Summary;
            city.CountryName = model.CountryName;
            

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