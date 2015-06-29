using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context) {

            db = context;

        }

        public IActionResult Index()
        {
            var trips = db.Trips.ToList();
            return View(trips);
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your best trip planner!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Contact ";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
