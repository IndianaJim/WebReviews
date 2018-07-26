using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebReviews.Startup))]
namespace WebReviews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
