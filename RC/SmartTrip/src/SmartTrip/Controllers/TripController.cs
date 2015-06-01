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

using Microsoft.AspNet.Mvc;

using System.Globalization;
using Microsoft.AspNet.Builder;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections;

namespace SmartTrip.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext db;

        private IHostingEnvironment env;

        

        public TripController( ApplicationDbContext context,IHostingEnvironment hostingEnv )
        {
            db = context;
            env = hostingEnv;
       
        }

        public IActionResult TripStartTime()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult TripStartTime(TripViewModel model, string btnPrevious, string btnNext)
        {
            
             if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                
                 
                       
                 Context.Session.SetString("tripStartTime", model.Trip.StartTime.Ticks.ToString());
                   
                 return RedirectToAction("TripCountry");


                }
            }
            return View();
        }

        public IActionResult TripCountry()
        {
 
              var tripViewModel = new TripViewModel();

              tripViewModel.Trip.StartTime = new DateTime( System.Convert.ToInt64( Context.Session.GetString("tripStartTime")) ) ;
              tripViewModel.Countries = db.Countries.ToList();

             return View(tripViewModel);
        }

        
        public IActionResult TripCity(int  id)
        {
            if (ModelState.IsValid)
            {

                var tripViewModel = new TripViewModel();

                tripViewModel.Cities = db.Cities.Where(c => c.CountryId == id).ToList();
                for (int i = 0; i < tripViewModel.Cities.Count; i++)
                {

                    CheckedCity city = new CheckedCity();
                    city.CityId = tripViewModel.Cities[i].Id;
                    city.Checked = false;

                    tripViewModel.CheckedCities.Add(city);
                }



                return View(tripViewModel);
            }

            return View();
        }


        [HttpPost]
        public  async Task<IActionResult> TripCity(TripViewModel model, string btnPrevious, string btnNext)
        {


            List<City> cities = new List<City>();

          
            foreach (var m in model.CheckedCities)
            { 
               if(m.Checked)
                {
                   
                 var city = await   db.Cities.FirstOrDefaultAsync(x => x.Id == m.CityId);
                    cities.Add(city); 
                  
                }

            }
            
            TempData["cities"] = cities;

            
            return RedirectToAction("TripOrderDays");
        }


       
    


    public IActionResult TripOrderDays()
        {
            TripViewModel tripViewModel = new TripViewModel();

            TempData["cities"].ToString();

         tripViewModel.Cities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(TempData["cities"].ToString());
            

            return View(tripViewModel);
        }


        public IActionResult Index()
        {
            var trips = db.Trips.ToList();

            return View(trips);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripViewModel model)
        {
         
         if (!ModelState.IsValid)
            {
                return View(model);
            }
  

            var trip = new Trip
            {
     
            };

            db.Trips.Add(trip);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
            
            //Edit
            var trip = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }

            return View(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TripViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
          

            var trip = await db.Trips.SingleOrDefaultAsync(x => x.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }

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