using Microsoft.AspNetCore.Mvc;

namespace ContactPage.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
