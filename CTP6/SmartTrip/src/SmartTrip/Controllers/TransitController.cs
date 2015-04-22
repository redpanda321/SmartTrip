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

        public IEnumerable<SelectListItem> InitCity()
        {

            return new SelectList(db.Cities.ToList(), "Id", "CityName");

        }


        public IEnumerable<SelectListItem> InitTransitType()
        {
            var category = new TransitClass();

            return new SelectList(category.TransitType);

        }

        public IEnumerable<SelectListItem> InitCurrency()
        {
            // CurrentCulture.NumberFormat.CurrencySymbol

            List<string> currencies = new List<string>();
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo ri;

                try
                {

                    ri = new RegionInfo(cultureInfo.LCID);
                }
                catch
                {

                    ri = null;
                }

                if (ri != null)
                    currencies.Add(ri.ISOCurrencySymbol);
            }

            return new SelectList(currencies);
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

            var transitViewModel = new TransitViewModel();
           transitViewModel.Cities = InitCity();
           transitViewModel.TransitTypes = InitTransitType();
           transitViewModel.Currencies = InitCurrency();

            return View(transitViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransitViewModel model)
        {
           

            //SceneryEditModel

            /*
        if (!ModelState.IsValid)
            {
                return View(model);
            }
            */

            var transit = new Transit
            {
                
                TransitName = model.Transit.TransitName,
                TransitType = model.Transit.TransitType,
                TransitNumber = model.Transit.TransitNumber,
                StartingCity = model.Transit.StartingCity,
                DestinationCity = model.Transit.DestinationCity,
                StartTime = model.Transit.StartTime,
                EndTime = model.Transit.EndTime,
                Price = model.Transit.Price,
                Currency = model.Transit.Currency,   //
                Amount = model.Transit.Amount,
                Memo = model.Transit.Memo,
             

            };

            db.Transits.Add(transit);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
           
            var transitViewModel = new TransitViewModel();
            transitViewModel.Cities = InitCity();
            transitViewModel.TransitTypes = InitTransitType();
            transitViewModel.Currencies = InitCurrency();


            //Edit
            var transit = await db.Transits.SingleOrDefaultAsync(x => x.Id == id);
            if (transit == null)
            {
                return HttpNotFound();
            }

            transitViewModel.Transit = transit;

            return View(transitViewModel);
        }

        

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TransitViewModel model)
        {

            
           
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           

            var transit = await db.Transits.SingleOrDefaultAsync(x => x.Id == id);
            if (transit == null)
            {
                return HttpNotFound();
            }

            transit.TransitName = model.Transit.TransitName;
            transit.TransitType= model.Transit.TransitType;
            transit.TransitNumber = model.Transit.TransitNumber;
            transit.StartingCity =  model.Transit.StartingCity;
            transit.DestinationCity= model.Transit.DestinationCity;
            transit.StartTime = model.Transit.StartTime;
            transit.EndTime = model.Transit.EndTime;
            transit.Price = model.Transit.Price;
            transit.Currency = model.Transit.Currency;
            transit.Amount = model.Transit.Amount;
            transit.Memo = model.Transit.Memo;
          

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