using BTL_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Employees employee)
        {
            return View();
        }
    }
}
