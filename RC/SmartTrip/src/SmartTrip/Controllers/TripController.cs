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
using Microsoft.AspNet.Builder;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections;
using MaxMind.GeoIP2;
using System.Security.Claims;

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

             // tripViewModel.Trip.StartTime = new DateTime( System.Convert.ToInt64( Context.Session.GetString("tripStartTime")) ) ;
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

                Context.Session.SetInt("countryId", id);
               

                return View(tripViewModel);
            }

            return View();
        }


        [HttpPost]
        public  IActionResult TripCity(TripViewModel model, string btnPrevious, string btnNext)
        {


            //List<City> cities = new List<City>();


            List<byte> arr = new List<byte>();

            foreach (var m in model.CheckedCities)
            { 
               if(m.Checked)
                {

                   arr.Add((byte)m.CityId);     
                // var city = await   db.Cities.FirstOrDefaultAsync(x => x.Id == m.CityId);
                //    cities.Add(city); 
                  
                }

            }

            Context.Session.Set("cities", arr.ToArray());

           // TempData["cities"] = cities;

            
            return RedirectToAction("TripOrderDays");
        }



    public IActionResult TripOrderDays()
        {
            TripViewModel tripViewModel = new TripViewModel();

            // suck with TempData
            // TempData["cities"].ToString();

            // tripViewModel.Cities =new List<City>( Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(TempData["cities"].ToString()) );

            List<byte> list =   Context.Session.Get("cities").ToList();

          

            for (int i = 0; i < list.Count; i++) {

                City city =  db.Cities.FirstOrDefault(x => x.Id == (int)list[i]);

                tripViewModel.Cities.Add(city);

            }
              

            return View(tripViewModel);
        }

        [HttpPost]
        public IActionResult TripOrderDays(TripViewModel model, string btnPrevious, string btnNext)
        {

            // Get start city
            var reader = new DatabaseReader(env.WebRootPath + "\\GeoLite2-City.mmdb");

            IHttpConnectionFeature connection = Context.GetFeature<IHttpConnectionFeature>();

            string ip = connection != null ? connection.RemoteIpAddress.ToString() : null;

            if (ip == "127.0.0.1")
                ip = "128.101.101.101";

            var startCity = reader.City(ip);

            //Get anonymous user Id

            string userId;
            
            if (Context.User.IsSignedIn())
            {
                userId = Context.User.GetUserId();


            }
            else { 


                 userId = Context.Request.Cookies["identity"];
                if (userId == null)
                {
                    userId = Guid.NewGuid().ToString();
                    Context.Response.Cookies.Append("identity", userId);
                }

            }

            Trip trip = new Trip();

            trip.StartCity = startCity.City.Name;
            trip.UserName = userId;
            trip.StartTime = new DateTime(System.Convert.ToInt64(Context.Session.GetString("tripStartTime")));

            int Days = 0;

            for (int i = 0; i < model.Cities.Count; i++) {

                trip.TripDays += model.Cities[i].Days + ">";
                trip.TripCities += model.Cities[i].CityName + ">";
                Days += model.Cities[i].Days;

            }

            trip.TripName = trip.TripCities + Days + "Day";

            db.Trips.Add(trip);
            db.SaveChanges();

            //todo fix a bug
            Trip myTrip =  db.Trips.FirstOrDefault(x => x.TripName == trip.TripName);

            for (int i = 0; i < model.Cities.Count; i++)
            {
                for (int j = 0; j < model.Cities[i].Days; j++) {

                    Schedule schedule = new Schedule();
                    schedule.ScheduleName = "Day" + (i+j+1);
                    schedule.StrCities = model.Cities[i].CityName + ">";
                    schedule.ScheduleDate = trip.StartTime.AddDays(i+j);
                    schedule.TripId = myTrip.Id;
                    schedule.CountryId = Context.Session.GetInt("countryId").Value;

                    db.Schedules.Add(schedule);
                    db.SaveChangesAsync();


                }
            }



            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var trips = db.Trips.ToList();

            return View(trips);
        }

        public IActionResult TripSchedule(int id)
        {
            var schedules = db.Schedules.Where(x => x.TripId == id).ToList() ;

            return View(schedules);
        }


        public IActionResult TripScheduleInfo(int id)
        {

            ScheduleViewModel scheduleViewModel = new ScheduleViewModel();

            scheduleViewModel.Schedule = db.Schedules.FirstOrDefault(x => x.Id == id);

            scheduleViewModel.Sceneries = db.Sceneries.Where(x => x.ScheduleId == id).ToList();

            Context.Session.SetInt("scheduleId", id);
           

            return View(scheduleViewModel);
        }

        public IActionResult AddScenery(int id) {

            Schedule schedule = db.Schedules.FirstOrDefault(x => x.Id == id);
            List<string> listCities = schedule.StrCities.Split('>').ToList();

            List<Scenery> sceneries = new List<Scenery>();
            for (int i = 0; i < listCities.Count; i++) {

                City city = db.Cities.FirstOrDefault(x => x.CityName == listCities[i]);

                sceneries.AddRange(db.Sceneries.Where(x => x.CityId == city.Id).ToList());

            }

            TripViewModel tripViewModel = new TripViewModel();
            tripViewModel.Sceneries = sceneries;

            return View(tripViewModel);
        }


        public IActionResult ScheduleCity(int id)
        {

            Schedule schedule = db.Schedules.FirstOrDefault(x => x.Id == id);

            List<string> listCities =  schedule.StrCities.Split('>').ToList();

            int countryId = schedule.CountryId.Value;

            List<City> cities = db.Cities.Where(x => x.CountryId == countryId).ToList();

            for (int i = 0; i < listCities.Count; i++) {

                City city = db.Cities.FirstOrDefault(x => x.CityName == listCities[i]);

                cities.Remove(city);

            }

            ScheduleViewModel scheduleViewModel = new ScheduleViewModel();

            scheduleViewModel.Schedule = schedule;
            scheduleViewModel.Cities = cities;

            for (int j = 0; j < cities.Count; j++) {

                CheckedCity checkedCity = new CheckedCity();
                checkedCity.CityId = cities[j].Id;
                checkedCity.Checked = false;

                scheduleViewModel.CheckedCities.Add(checkedCity);

            }


            return View(scheduleViewModel);
        }

        [HttpPost]
        public IActionResult ScheduleCity(ScheduleViewModel model, string btnPrevious,string btnNext)
        {
            int scheduleId = Context.Session.GetInt("scheduleId").Value;

            Schedule schedule = db.Schedules.FirstOrDefault(x => x.Id == scheduleId);

            for (int i = 0; i < model.CheckedCities.Count; i++) {

                if (model.CheckedCities[i].Checked)
                {
                    City city = db.Cities.FirstOrDefault(x => x.Id == model.CheckedCities[i].CityId);
                    schedule.StrCities += city.CityName + ">";
                }

            }

            db.SaveChanges();



            return RedirectToAction("TripScheduleInfo",new { id = scheduleId });
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