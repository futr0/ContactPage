using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactPage.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}