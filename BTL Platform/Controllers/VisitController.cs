using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Controllers
{
    public class VisitController : Controller
    {
        VisitRepository VisitRepository;
        UserRepository UserRepository;
        VisitTypeRepository VisitTypeRepository;
        VisitStatusRepository VisitStatusRepository;
        PlacesRepository PlacesRepository;
        

        public VisitController(VisitRepository _VisitRepository, VisitTypeRepository visitTypeRepository, UserRepository userRepository, PlacesRepository placesRepository, VisitStatusRepository visitStatusRepository)
        {
            VisitRepository = _VisitRepository;
            VisitTypeRepository = visitTypeRepository;
            UserRepository = userRepository;
            PlacesRepository = placesRepository;
            VisitStatusRepository = visitStatusRepository;
        }
        public IActionResult Index()
        {
            List<Visit> Visits = VisitRepository.GetVisits();
            return View(Visits);
        }
        public IActionResult Create()
        {
            ViewBag.User = UserRepository.GetUsers().Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UserName }).ToList();
            ViewBag.VisitTypes = VisitTypeRepository.GetVisitTypes().Select(vt => new SelectListItem { Value = vt.VisitTypeId.ToString(), Text = vt.VisitTypeName }).ToList();
            ViewBag.VisitStatus = VisitStatusRepository.GetVisitStatuss().Select(vs => new SelectListItem { Value = vs.VisitStatusId.ToString(), Text = vs.VisitStatusName }).ToList();
            ViewBag.Places = PlacesRepository.GetPlacess().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.DisplayName }).ToList();




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

        public IActionResult Details(string id)
        {
            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Users = UserRepository.GetUsers();
            ViewBag.VisitTypes = VisitTypeRepository.GetVisitTypes();
            ViewBag.VisitStatus = VisitStatusRepository.GetVisitStatuss();
            ViewBag.Places = PlacesRepository.GetPlacess();
            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpPost]
        public IActionResult Edit(Visit Visit, string id)
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
        public IActionResult Delete(string id)
        {

            VisitRepository.Delete(id);
            VisitRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
