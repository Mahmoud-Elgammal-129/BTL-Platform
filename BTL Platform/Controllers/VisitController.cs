using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Controllers
{
    public class VisitController : Controller
    {
        VisitRepository VisitRepository;
        BTLContext btlContext;

        public VisitController(VisitRepository _VisitRepository, BTLContext btlContext)
        {
            VisitRepository = _VisitRepository;
            this.btlContext = btlContext;
        }
        public IActionResult Index()
        {
            List<Visit> Visits = VisitRepository.GetVisits();
            return View(Visits);
        }
        public IActionResult Create()
        {
            ViewBag.InventoryList = btlContext.Inventories.Select(i => new SelectListItem
            {
                Value = i.InventoryId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.VisitTypeList = btlContext.VisitTypes.Select(u => new SelectListItem
            {
                Value = u.VisitTypeId.ToString(),
                Text = u.VisitTypeName
            }).ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Visit Visits)
        {
            if (Visits != null)
            {
                VisitRepository.Insert(Visits);
                VisitRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Create", Visits);
        }

        public IActionResult Details(long id)
        {
            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.InventoryList = btlContext.Inventories.Select(i => new SelectListItem
            {
                Value = i.InventoryId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.VisitTypeList = btlContext.VisitTypes.Select(u => new SelectListItem
            {
                Value = u.VisitTypeId.ToString(),
                Text = u.VisitTypeName
            }).ToList();


            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpPost]
        public IActionResult Edit(Visit Visit, long id)
        {
            if (Visit != null)
            {
                VisitRepository.Update(id, Visit);
                VisitRepository.Save();
                return RedirectToAction("Index");
            }
            return View(Visit);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            VisitRepository.Delete(id);
            VisitRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
