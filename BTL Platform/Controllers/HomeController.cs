using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace BTL_Platform.Controllers
{
    [Authorize(Roles = "employee")]
    public class HomeController : Controller
    {
        
        public IActionResult Home()
        {
            return View();
        }
    }
}
