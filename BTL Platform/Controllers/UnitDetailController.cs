using BTL_Platform.Models;
using BTL_Platform.Repository;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class UnitDetailController : Controller
    {
        UnitDetailRepository UnitDetailRepository;
        UnitRepository UnitRepository;
        public UnitDetailController(UnitDetailRepository _UnitDetailRepository, UnitRepository unitRepository)
        {
            UnitDetailRepository = _UnitDetailRepository;
            UnitRepository = unitRepository;
        }
        public IActionResult Index(string id)
        {
            try
            {
                var unit=UnitRepository.GetUnit(id);
                ViewBag.Id = id;
                ViewBag.Name= unit.UnitName;

                List<UnitDetail> UnitDetails = UnitDetailRepository.GetUnitDetails(id);
                return View(UnitDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving UnitDetails.");
            }
        }
        public IActionResult Create(string Id)
        {
            try
            {
                var unit = UnitRepository.GetUnit(Id);
                ViewBag.Id = Id;
                ViewBag.Name = unit.UnitName;

                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory or UnitDetail types for creating UnitDetail.");
            }
        }
        [HttpPost]
        public IActionResult Create(UnitDetail UnitDetail)
        {
            try
            {
                if (UnitDetail != null)
                {
                    UnitDetail.TypeInserted = "Add";
                    UnitDetailRepository.Add(UnitDetail);
                    UnitDetailRepository.Save();
                    return RedirectToAction("Index", new { id = UnitDetail.UnitId });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the UnitDetail.");
            }

            return View("Create", UnitDetail);
        }

        public IActionResult Details(string id)
        {
            try
            {
                UnitDetail UnitDetail = UnitDetailRepository.GetUnitDetail(id);
                return View(UnitDetail);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving UnitDetail details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {

                UnitDetail UnitDetail = UnitDetailRepository.GetUnitDetail(id);
                return View(UnitDetail);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving UnitDetail details for editing.");
            }
        }
        [HttpPost]
        public IActionResult Edit(UnitDetail UnitDetail, string id)
        {
            try
            {
                if (UnitDetail != null)
                {
                    UnitDetailRepository.Update(id, UnitDetail);
                    UnitDetailRepository.Save();
                    return RedirectToAction("Index", new { id = UnitDetail.UnitId });

                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the UnitDetail.");
            }

            return View(UnitDetail);
        }


        public IActionResult Delete(string id)
        {
            try
            {
                UnitDetailRepository.Delete(id);
                UnitDetailRepository.Save();
                return RedirectToAction("Index", new { id = id });

            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the UnitDetail.");
            }
        }
    }
}
