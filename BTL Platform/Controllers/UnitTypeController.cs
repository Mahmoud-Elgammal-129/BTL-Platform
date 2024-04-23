using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class UnitTypeController : Controller
    {
        UnitTypeRepository UnitTypeRepository;

        public UnitTypeController(UnitTypeRepository _UnitTypeRepository)
        {
            UnitTypeRepository = _UnitTypeRepository;

        }
        public IActionResult Index()
        {
            try
            {
                
                List<UnitType> unitTypes = UnitTypeRepository.GetUnitTypes();
                return View(unitTypes);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving unit types.");
            }
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(UnitType unitType)
        {
            try
            {
                if (unitType != null)
                {
                    UnitTypeRepository.Insert(unitType);
                    UnitTypeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the unit type.");
            }

            return View("Create", unitType);
        }

        public IActionResult Details(string id)
        {
            try
            {
                UnitType unitType = UnitTypeRepository.GetUnitType(id);
                return View(unitType);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving unit type details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                UnitType unitType = UnitTypeRepository.GetUnitType(id);
                return View(unitType);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving unit type details for editing.");
            }
        }
        [HttpPost]
        public IActionResult Edit(UnitType unitType, string id)
        {
            try
            {
                if (unitType != null)
                {
                    UnitTypeRepository.Update(id, unitType);
                    UnitTypeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the unit type.");
            }

            return View(unitType);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                UnitTypeRepository.Delete(id);
                UnitTypeRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the unit type.");
            }
        }
    }
}
