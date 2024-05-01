using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Controllers
{
    public class VisitDetailController : Controller
    {
        VisitDetailRepository VisitDetailRepository;
        VisitRepository visitRepository;
        UnitRepository UnitRepository;
        public VisitDetailController(VisitDetailRepository _VisitDetailRepository, UnitRepository unitRepository, VisitRepository visitRepository)
        {
            VisitDetailRepository = _VisitDetailRepository;
            UnitRepository = unitRepository;
            this.visitRepository = visitRepository;
        }
        public IActionResult Index(string id)
        {
            try
            {
                var visit = visitRepository.GetVisit(id);
                ViewBag.Id = id;
                

                List<VisitDetail> VisitDetails = VisitDetailRepository.GetVisitDetails(id);
                return View(VisitDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving VisitDetails.");
            }
        }
        public IActionResult Create(string id)
        {
            try
            {
                var visit = visitRepository.GetVisit(id);
                ViewBag.Id = id;
   
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory or VisitDetail types for creating VisitDetail.");
            }
        }
        [HttpPost]
        public IActionResult Create(VisitDetail VisitDetail)
        {
            try
            {
                if (VisitDetail != null)
                {
                    // for only trying 
                    VisitDetailRepository.Insert(VisitDetail);
                    VisitDetailRepository.Save();
                    return RedirectToAction("Index", new { id = VisitDetail.VisitId });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the VisitDetail.");
            }

            return View("Create", VisitDetail);
        }
    }
}
