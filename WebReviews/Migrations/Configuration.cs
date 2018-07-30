namespace WebReviews.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebReviews.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebReviews.Models.WebReviewsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebReviews.Models.WebReviewsDB";
        }

        protected override void Seed(WebReviews.Models.WebReviewsDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Restaurants.AddOrUpdate(r => r.Name,
                new Models.Restaurant { Name = "Giordano's", City = "Indianapolis", Country = "USA" },
                new Models.Restaurant { Name = "BruBurger", City = "Carmel", Country = "USA" },
                new Models.Restaurant
                {
                    Name = "BoomBozz",
                    City = "Indianapolis",
                    Country = "USA",
                    Reviews =
                        new List<RestaurantReview>
                        {
                            new RestaurantReview { Rating = 9, Body="Yummy pizza!", ReviewerName = "Bob"}
                        }
                });
            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" });
            }
        }
    }
}
