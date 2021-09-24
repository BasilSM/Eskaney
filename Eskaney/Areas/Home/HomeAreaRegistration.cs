using System.Web.Mvc;

namespace Eskaney.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {


            //context.MapRoute(
            //    "Home_default",
            //    "{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);


            context.MapRoute(
                "Home_default",
                "Home",
                new { controller = "Home", action = "Home" }
            );

            context.MapRoute(
                "Login_default",
                "Login",
                new { controller = "Home", action = "Login" }
            );

            context.MapRoute(
                "Logout_default",
                "Logout",
                new { controller = "Home", action = "Logout" }
            );

        }
    }
}