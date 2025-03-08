using System.Web.Mvc;

namespace TestProject.Areas.TestAreaBIT
{
    public class TestAreaBITAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestAreaBIT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestAreaBIT_default",
                "TestAreaBIT/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}