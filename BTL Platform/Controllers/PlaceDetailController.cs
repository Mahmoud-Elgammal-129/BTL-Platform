using BTL_Platform.Models;
using BTL_Platform.Repository;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Controllers
{
    public class PlaceDetailController : Controller
    {
        PlacesDetailRepository PlacesDetailRepository;
        PlacesRepository PlacesRepository;
        UnitRepository UnitRepository;
        public PlaceDetailController(PlacesDetailRepository _PlacesDetailRepository, UnitRepository unitRepository, PlacesRepository placesRepository)
        {
            PlacesDetailRepository = _PlacesDetailRepository;
            UnitRepository = unitRepository;
            PlacesRepository = placesRepository;
        }
        public IActionResult Index(string id)
        {
            try
            {
                var place = PlacesRepository.GetPlaces(id);
                ViewBag.Id = id;
                ViewBag.Name = place.DisplayName;

                List<PlacesDetail> PlacesDetails = PlacesDetailRepository.GetPlacesDetails(id);
                return View(PlacesDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving PlacesDetails.");
            }
        }
        public IActionResult Create(string id)
        {
            try
            {
                var place = PlacesRepository.GetPlaces(id);
                ViewBag.Id = id;
                ViewBag.Name = place.DisplayName;
                ViewBag.units = UnitRepository.GetUnits().Select(vt => new SelectListItem { Value = vt.UnitId.ToString(), Text = vt.UnitName }).ToList();
                ViewBag.Places = PlacesRepository.GetPlacess().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.DisplayName }).ToList();

                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory or PlacesDetail types for creating PlacesDetail.");
            }
        }
        [HttpPost]
        public IActionResult Create(PlacesDetail PlacesDetail)
        {
            try
            {
                if (PlacesDetail != null)
                {
                    // for only trying 
                    PlacesDetailRepository.Insert(PlacesDetail);
                    PlacesDetailRepository.Save();
                    return RedirectToAction("Index", new { id = PlacesDetail.PlacesId });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the PlacesDetail.");
            }

            return View("Create", PlacesDetail);
        }


    }
}
