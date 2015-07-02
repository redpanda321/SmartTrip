using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SmartTrip.Models;
using System.Security.Claims;
using Microsoft.AspNet.Http;

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

            string userId;

            if (Context.User.IsSignedIn())
            {
                userId = Context.User.GetUserId();
                Context.Response.Cookies.Append("identity", userId);
                Context.Session.SetString("identity", userId);
            }
            else
            {


                userId = Context.Request.Cookies["identity"];
                if (userId == null)
                {
                    userId = Guid.NewGuid().ToString();
                    Context.Response.Cookies.Append("identity", userId);
                    Context.Session.SetString("identity", userId);
                }

            }


            var trips = db.Trips.ToList();
            return View(trips);
        }

        public IActionResult About()
        {
            ViewBag.Message = "夏天来了，我们去旅游吧！我带着你，你带着钱，三亚也好，长江也罢，横穿唐古拉山口，暴走腾格里沙漠。让我们来一场说走就走的旅行！我带着你，你带着钱，哪怕是天涯，哪怕是海角！";

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
