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
using Microsoft.AspNet.Session;

using System.Globalization;

namespace SmartTrip.Controllers
{
    public class TripController : Controller
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

       
        public TripController(ApplicationDbContext context,IHostingEnvironment hostingEnv )
        {
            db = context;
            env = hostingEnv;
        }


        public IActionResult TripStartTime()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult TripStartTime(TripStartTimeEditModel model, string btnPrevious, string btnNext)
        {
            
             if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    Context.Session.SetString("tripStartTime", model.StartTime.ToString());
                    return View("TripCountry");
                }
            }
            return View();
        }




        public IActionResult Index()
        {
            var trips = db.Trips.ToList();

            return View(trips);
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

            var trip = new Trip
            {
                
               
                UserName = model.UserName

            };

            db.Trips.Add(trip);
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
            var trip = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }

            return View(trip);
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

            var trip = await db.Trips.SingleOrDefaultAsync(x => x.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }

            
            trip.UserName = model.UserName;


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
            Trip trip = await db.Trips.SingleOrDefaultAsync(x => x.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Sceneries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trip trip = await db.Trips.SingleOrDefaultAsync(x => x.Id == id);
            db.Trips.Remove(trip);
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