using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class VisitStatusController : Controller
    {
        VisitStatusRepository visitStatusRepository;

        public VisitStatusController(VisitStatusRepository _visitStatusRepository)
        {
           visitStatusRepository=_visitStatusRepository;

        }
        public IActionResult Index()
        {
            try
            {
                
                List<VisitStatus> visitStatus = visitStatusRepository.GetVisitStatuss();
                return View(visitStatus);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while retrieving visit statuses.");
                return View(new List<VisitStatus>()); // Return an empty list or handle the error in a way suitable for your application
            }
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(VisitStatus visitStatus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    visitStatusRepository.Insert(visitStatus);
                    visitStatusRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError("", "An error occurred while creating the visit status.");
                }
            }
            // If ModelState is not valid or an error occurred, return to the Create view with the posted model
            return View(visitStatus);
        }

        public IActionResult Details(string id)
        {
            try
            {
                VisitStatus visitStatus = visitStatusRepository.GetVisitStatus(id);
                if (visitStatus == null)
                {
                    return NotFound(); // Return a 404 Not Found if the visit status is not found
                }
                return View(visitStatus);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500); // Return a 500 Internal Server Error in case of an exception
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                VisitStatus visitStatus = visitStatusRepository.GetVisitStatus(id);
                if (visitStatus == null)
                {
                    return NotFound(); // Return a 404 Not Found if the visit status is not found
                }
                return View(visitStatus);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500); // Return a 500 Internal Server Error in case of an exception
            }
        }
        [HttpPost]
        public IActionResult Edit(VisitStatus visitStatus, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    visitStatusRepository.Update(id, visitStatus);
                    visitStatusRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError("", "An error occurred while updating the visit status.");
                }
            }
            // If ModelState is not valid or an error occurred, return to the Edit view with the posted model
            return View(visitStatus);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                visitStatusRepository.Delete(id);
                visitStatusRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500); // Return a 500 Internal Server Error in case of an exception
            }
        }
    }
}
