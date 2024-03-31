using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
