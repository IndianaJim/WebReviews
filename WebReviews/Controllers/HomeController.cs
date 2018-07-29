using System;
using System.Linq;
using System.Web.Mvc;
using WebReviews.Models;

namespace WebReviews.Controllers
{
    public class HomeController : Controller
    {
        WebReviewsDB _db = new WebReviewsDB();

        public ActionResult Index(string searchTerm = null)
        {


            var model =
                _db.Restaurants
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()
                    }
                    );

            return View(model);
        }

        public ActionResult About()
        {

            var model = new AboutModel
            {
                Name = "Jim",
                Location = "Indianapolis, IN"
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}