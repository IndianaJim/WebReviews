using System;
using System.Linq;
using System.Web.Mvc;
using WebReviews.Models;

namespace WebReviews.Controllers
{
    public class HomeController : Controller
    {
        WebReviewsDB _db = new WebReviewsDB();

        public ActionResult Index()
        {

            var model = _db.Restaurants.ToList();
            return View(model);
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

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}