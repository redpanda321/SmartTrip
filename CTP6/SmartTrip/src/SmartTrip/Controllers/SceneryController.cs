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

       public IEnumerable<SelectListItem> InitCity()
        {

            return  new SelectList(db.Cities.ToList(),"Id","CityName");

        }

        public  IEnumerable<SelectListItem> InitCategory()
        {
            var category = new Category();

            return new SelectList( category.CategoryType.AsEnumerable());
         
        }

        public  IEnumerable<SelectListItem> InitCurrency()
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
            
           return new SelectList(currencies.AsEnumerable());    
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
           var sceneryViewModel = new SceneryViewModel();
          
           sceneryViewModel.Cities =  InitCity();
           sceneryViewModel.Categories = InitCategory();
           sceneryViewModel.Currencies = InitCurrency();

            return View(sceneryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IEnumerable<IFormFile> files,SceneryViewModel model)
        {
            //IFormFile
            List<string> imageUrlList = new List<string>();

            if (files != null)
              imageUrlList = await SaveFiles(files);

            //SceneryEditModel
         if (!ModelState.IsValid)
            {
                return View(model);
            }
  
            var scenery = new Scenery
            {
                
                SceneryName = model.Scenery.SceneryName,
                Star = model.Scenery.Star,
                Summary = model.Scenery.Summary,
                Ticket = model.Scenery.Ticket,
                OpenTime = model.Scenery.OpenTime,
                Traffic = model.Scenery.Traffic,
                WebUrl = model.Scenery.WebUrl,
                Category = model.Scenery.Category,   //
                Telephone = model.Scenery.Telephone,
                Price = model.Scenery.Price,
                Currency = model.Scenery.Currency,  //
                CityId = model.Scenery.CityId    //
              

            };

            db.Sceneries.Add(scenery);
            await db.SaveChangesAsync();


            foreach (var imageUrl in imageUrlList) {

                var image = new Image
                {

                    ImageUrl = imageUrl,
                    SceneryId = scenery.Id
                };

                db.Images.Add(image);
                await db.SaveChangesAsync();


            }


            return RedirectToAction("Index");
           }

        public async Task<IActionResult> Edit(int id)
        {
            //
            var sceneryViewModel = new SceneryViewModel();
            sceneryViewModel.Cities = InitCity();
            sceneryViewModel.Categories = InitCategory();
            sceneryViewModel.Currencies = InitCurrency();
            
            //Edit
            var scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (scenery == null)
            {
                return HttpNotFound();
            }

            sceneryViewModel.Scenery = scenery;

            return View(sceneryViewModel);
        }


       

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SceneryViewModel model,IEnumerable<IFormFile> files)
        {

            //IFormFile
            List<string> imageUrlList = await SaveFiles(files);

            //SceneryEditModel
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            var scenery = await db.Sceneries.SingleOrDefaultAsync(x => x.Id == id);
            if (scenery == null)
            {
                return HttpNotFound();
            }

            scenery.SceneryName = model.Scenery.SceneryName;
           
            scenery.Star = model.Scenery.Star;
            scenery.Summary =  model.Scenery.Summary;
            scenery.Ticket = model.Scenery.Ticket;
            scenery.OpenTime = model.Scenery.OpenTime;
            scenery.Traffic = model.Scenery.Traffic;
            scenery.WebUrl = model.Scenery.WebUrl;
            scenery.Category = model.Scenery.Category;
            scenery.Telephone = model.Scenery.Telephone;
            scenery.Price = model.Scenery.Price;
            scenery.Currency = model.Scenery.Currency;
            scenery.CityId = model.Scenery.CityId;
           
            // TODO Exception handling
            db.SaveChanges();


            foreach (var imageUrl in imageUrlList)
            {

                var image = new Image
                {

                    ImageUrl = imageUrl,
                    SceneryId = scenery.Id
                };

                db.Images.Add(image);
                await db.SaveChangesAsync();


            }



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