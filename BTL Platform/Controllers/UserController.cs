using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository;

        public UserController(UserRepository _UserRepository)
        {
            userRepository = _UserRepository;

        }
        public IActionResult Index()
        {
            List<User> user = userRepository.GetUsers();
            return View(user);
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(User user)
        {


            if (user != null)
            {

                userRepository.Insert(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", user);
        }

        public IActionResult Details(long id)
        {
            User userid = userRepository.GetUser(id);
            return View(userid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            User userid = userRepository.GetUser(id);
            return View(userid);
        }
        [HttpPost]
        public IActionResult Edit(User user, long id)
        {
            if (user != null)
            {
                userRepository.Update(id, user);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            userRepository.Delete(id);
            userRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
