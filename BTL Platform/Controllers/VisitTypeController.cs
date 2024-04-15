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
            List<VisitType> visitType = visitTypeRepository.GetVisitTypes();
            return View(visitType);
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(VisitType visitType)
        {


            if (visitType != null)
            {

                visitTypeRepository.Insert(visitType);
                visitTypeRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", visitType);
        }

        public IActionResult Details(string id)
        {
            VisitType visitType = visitTypeRepository.GetVisitType(id);
            return View(visitType);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            VisitType visitTypeid = visitTypeRepository.GetVisitType(id);
            return View(visitTypeid);
        }
        [HttpPost]
        public IActionResult Edit(VisitType visitType, string id)
        {
            if (visitType != null)
            {
                visitTypeRepository.Update(id, visitType);
                visitTypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(visitType);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {

            visitTypeRepository.Delete(id);
            visitTypeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
