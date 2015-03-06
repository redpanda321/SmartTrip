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

using System.Globalization;

namespace SmartTrip.Controllers
{
    public class TransitController : Controller
    {
        private readonly ApplicationDbContext db;

        private IHostingEnvironment env;

       public void InitCity()
        {

            var cities = db.Cities.AsEnumerable();
            List<string> citiesList = new List<string>();
            foreach (var city in cities)
            {
                citiesList.Add(city.CityName);
            }
            ViewBag.cities = new SelectList(citiesList.AsEnumerable());

        }

        public  void InitCategory()
        {
            var category = new Category();
            ViewBag.categories = new SelectList ( category.CategoryType.AsEnumerable());
             
        }

        public  void InitCurrency()
        {
          
            List<string> currencies = new List<string>();
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo ri;

                try {

                    ri = new RegionInfo(cultureInfo.LCID);
                }
                catch
                {

                    ri = null;
                }

                if(ri != null)
                currencies.Add(ri.ISOCurrencySymbol);
            }
            
            ViewBag.currencies = new SelectList(currencies.AsEnumerable());    
        }

        public async Task<List<string>> SaveFiles(IEnumerable<IFormFile> files)
        {

            List<string> imageUrlList = new List<string>();

            foreach (var file in files)
            {

                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                string fileName = parsedContentDisposition.FileName.Trim('"');

                string filePath = Path.Combine(env.WebRoot + "\\images\\" + fileName);

                await file.SaveAsAsync(filePath);

                imageUrlList.Add(filePath);
            }

            return imageUrlList;
        }

        public TransitController(ApplicationDbContext context,IHostingEnvironment hostingEnv )
        {
            db = context;
            env = hostingEnv;
        }

        public IActionResult Index()
        {
            var transits = db.Transits.ToList();

            return View(transits);
        }
   
        public IActionResult Create()
        {

            InitCity();
            InitCategory();
            InitCurrency();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransitEditModel model)
        {
           

            //SceneryEditModel
   /*       if (!ModelState.IsValid)
            {
                return View(model);
            }
  */

            var transit = new Transit
            {
                
                TransitName = model.TransitName,
                TransitType = model.TransitType,
                TransitNumber = model.TransitNumber,
                StartingCity = model.StartingCity,
                DestinationCity = model.DestinationCity,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Price = model.Price,
                Currency = model.Currency,   //
                Amount = model.Amount,
                Memo = model.Memo,
                UserName = model.UserName

            };

            db.Transits.Add(transit);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
            //ViewBag
            InitCity();
            InitCategory();
            InitCurrency();
            
            //Edit
            var transit = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (transit == null)
            {
                return HttpNotFound();
            }

            return View(transit);
        }


       

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TransitEditModel model)
        {

            
            //SceneryEditModel
            /*
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            */

            var transit = await db.Transits.SingleOrDefaultAsync(x => x.Id == id);
            if (transit == null)
            {
                return HttpNotFound();
            }

            transit.TransitName = model.TransitName;
            transit.TransitType= model.TransitType;
            transit.TransitNumber = model.TransitNumber;
            transit.StartingCity =  model.StartingCity;
            transit.DestinationCity= model.DestinationCity;
            transit.StartTime = model.StartTime;
            transit.EndTime = model.EndTime;
            transit.Price = model.Price;
            transit.Currency = model.Currency;
            transit.Amount = model.Amount;
            transit.Memo = model.Memo;
            transit.UserName = model.UserName;


            // TODO Exception handling
            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }

        // GET: Sceneries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Transit transit = await db.Transits.SingleOrDefaultAsync(x => x.Id == id);
            if (transit == null)
            {
                return HttpNotFound();
            }
            return View(transit);
        }

        // POST: Sceneries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transit transit = await db.Transits.SingleOrDefaultAsync(x => x.Id == id);
            db.Transits.Remove(transit);
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