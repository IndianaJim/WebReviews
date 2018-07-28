using System;
using System.Web.Mvc;
using WebReviews.Models;

namespace WebReviews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = String.Format("{0}::{1}  {2}", controller, action, id);

            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {

            var model = new AboutModel();
            model.Name = "Jim";
            model.Location = "Indianapolis, IN";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}