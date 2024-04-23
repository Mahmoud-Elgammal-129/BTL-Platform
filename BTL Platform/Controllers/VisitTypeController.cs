using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class VisitTypeController : Controller
    {
        VisitTypeRepository visitTypeRepository;

        public VisitTypeController(VisitTypeRepository _visitTypeRepository)
        {
            visitTypeRepository = _visitTypeRepository;

        }
        public IActionResult Index()
        {
            try
            {
               
                List<VisitType> visitTypes = visitTypeRepository.GetVisitTypes();
                return View(visitTypes);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while retrieving visit types.");
                return View(new List<VisitType>());
            }
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(VisitType visitType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    visitTypeRepository.Insert(visitType);
                    visitTypeRepository.Save();
                    return RedirectToAction("Index");
                }
                return View(visitType);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while creating the visit type.");
                return View(visitType);
            }
        }

        public IActionResult Details(string id)
        {
            try
            {
                VisitType visitType = visitTypeRepository.GetVisitType(id);
                if (visitType == null)
                {
                    return NotFound(); // VisitType not found
                }
                return View(visitType);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while retrieving the visit type details.");
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                VisitType visitType = visitTypeRepository.GetVisitType(id);
                if (visitType == null)
                {
                    return NotFound(); // VisitType not found
                }
                return View(visitType);
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while retrieving the visit type for editing.");
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(VisitType visitType, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    visitTypeRepository.Update(id, visitType);
                    visitTypeRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError("", "An error occurred while updating the visit type.");
                }
            }
            return View(visitType);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                visitTypeRepository.Delete(id);
                visitTypeRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError("", "An error occurred while deleting the visit type.");
                return RedirectToAction("Index");
            }
        }
    }
}
