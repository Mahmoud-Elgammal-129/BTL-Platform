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
            try
            {
                
                List<User> users = userRepository.GetUsers();
                return View(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving user data.");
            }
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                if (user != null)
                {
                    userRepository.Insert(user);
                    userRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the user.");
            }

            return View("Create", user);
        }

        public IActionResult Details(string id)
        {
            try
            {
                User user = userRepository.GetUser(id);
                return View(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving user details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                User user = userRepository.GetUser(id);
                return View(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving user details for editing.");
            }
        }
        [HttpPost]
        public IActionResult Edit(User user, string id)
        {
            try
            {
                if (user != null)
                {
                    userRepository.Update(id, user);
                    userRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the user.");
            }

            return View(user);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                userRepository.Delete(id);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
