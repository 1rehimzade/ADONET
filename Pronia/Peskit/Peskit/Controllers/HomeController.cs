using Microsoft.AspNetCore.Mvc;

namespace Peskit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
