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
    public class SceneryController : Controller
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
            // CurrentCulture.NumberFormat.CurrencySymbol

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

        private async Task<List<string>> SaveFiles(IEnumerable<IFormFile> files)
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

        public SceneryController(ApplicationDbContext context,IHostingEnvironment hostingEnv )
        {
            db = context;
            env = hostingEnv;
        }

        public IActionResult Index()
        {
            var sceneries = db.Sceneries.ToList();

            return View(sceneries);
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
        public async Task<IActionResult> Create(IEnumerable<IFormFile> files,SceneryEditModel model)
        {
            //IFormFile

            List<string> imageUrlList = await SaveFiles(files);

            //SceneryEditModel
   /*       if (!ModelState.IsValid)
            {
                return View(model);
            }
  */

            var scenery = new Scenery
            {
                
                SceneryName = model.SceneryName,
                ImageUrls = (imageUrlList.Count > 0) ? imageUrlList : model.ImageUrls,
                Star = model.Star,
                Summary = model.Summary,
                Ticket = model.Ticket,
                OpenTime = model.OpenTime,
                Traffic = model.Traffic,
                WebUrl = model.WebUrl,
                Category = model.Category,   //
                Telephone = model.Telephone,
                Price = model.Price,
                Currency = model.Currency,  //
                CityName = model.CityName,
                UserName = model.UserName

            };

            db.Sceneries.Add(scenery);
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
            var scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (scenery == null)
            {
                return HttpNotFound();
            }

            return View(scenery);
        }


       

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SceneryEditModel model,IEnumerable<IFormFile> files)
        {

            //IFormFile
            List<string> imageUrlList = await SaveFiles(files);

            //SceneryEditModel
            /*
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            */

            var scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (scenery == null)
            {
                return HttpNotFound();
            }

            scenery.SceneryName = model.SceneryName;
            scenery.ImageUrls = (imageUrlList.Count>0)?imageUrlList : model.ImageUrls;
            scenery.Star = model.Star;
            scenery.Summary =  model.Summary;
            scenery.Ticket = model.Ticket;
            scenery.OpenTime = model.OpenTime;
            scenery.Traffic = model.Traffic;
            scenery.WebUrl = model.WebUrl;
            scenery.Category = model.Category;
            scenery.Telephone = model.Telephone;
            scenery.Price = model.Price;
            scenery.Currency = model.Currency;
            scenery.CityName = model.CityName;
            scenery.UserName = model.UserName;


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
            Scenery scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (scenery == null)
            {
                return HttpNotFound();
            }
            return View(scenery);
        }

        // POST: Sceneries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Scenery scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            db.Sceneries.Remove(scenery);
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