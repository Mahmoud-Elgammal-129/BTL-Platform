using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Controllers
{
    public class PlacesController : Controller
    {
        PlacesRepository PlacesRepository;
        UnitTypeRepository UnitTypeRepository;
        BTLContext btlContext;
        public PlacesController(PlacesRepository _PlacesRepository, BTLContext btlContext, UnitTypeRepository _UnitTypeRepository)
        {
            PlacesRepository = _PlacesRepository;
            UnitTypeRepository = _UnitTypeRepository;
            this.btlContext = btlContext;
        }
        public IActionResult Index()
        {
            try
            {
                
                List<Places> Placess = PlacesRepository.GetPlacess();
                return View(Placess);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving places.");
            }
        }

        public IActionResult Create()
        {
            try
            {
                ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while loading the create view.");
            }
        }
        [HttpPost]
        public IActionResult Create(Places Placess)
        {
            try
            {
                if (Placess != null)
                {
                    PlacesRepository.Insert(Placess);
                    PlacesRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the place.");
            }

            return View("Create", Placess);
        }

        public IActionResult Details(string id)
        {
            try
            {
                Places Placesid = PlacesRepository.GetPlaces(id);
                return View(Placesid);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving place details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
                Places Placesid = PlacesRepository.GetPlaces(id);
                return View(Placesid);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while loading the edit view.");
            }
        }
        [HttpPost]
        public IActionResult Edit(Places Places, string id)
        {
            try
            {
                if (Places != null)
                {
                    PlacesRepository.Update(id, Places);
                    PlacesRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the place.");
            }

            return View(Places);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                PlacesRepository.Delete(id);
                PlacesRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the place.");
            }
        }
    }
}
