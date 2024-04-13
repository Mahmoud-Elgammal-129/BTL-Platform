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
            List<VisitStatus> visitStatus = visitStatusRepository.GetVisitStatuss();
            return View(visitStatus);
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(VisitStatus visitStatus)
        {


            if (visitStatus != null)
            {

                visitStatusRepository.Insert(visitStatus);
                visitStatusRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", visitStatus);
        }

        public IActionResult Details(long id)
        {
            VisitStatus visitStatus = visitStatusRepository.GetVisitStatus(id);
            return View(visitStatus);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            VisitStatus visitTypeid = visitStatusRepository.GetVisitStatus(id);
            return View(visitTypeid);
        }
        [HttpPost]
        public IActionResult Edit(VisitStatus visitStatus, long id)
        {
            if (visitStatus != null)
            {
                visitStatusRepository.Update(id, visitStatus);
                visitStatusRepository.Save();
                return RedirectToAction("Index");
            }
            return View(visitStatus);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            visitStatusRepository.Delete(id);
            visitStatusRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
