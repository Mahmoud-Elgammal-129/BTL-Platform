using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Controllers
{
    public class UnitController : Controller
    {
        UnitRepository UnitRepository;
        InventoryRepository InventoryRepository;
        UnitTypeRepository UnitTypeRepository;
        BTLContext btlContext;

        public UnitController(UnitRepository _UnitRepository, BTLContext btlContext
            , InventoryRepository _InventoryRepository, UnitTypeRepository _UnitTypeRepository
            )
        {
            UnitRepository = _UnitRepository;
            this.btlContext = btlContext;
            this.InventoryRepository = _InventoryRepository;
            UnitTypeRepository = _UnitTypeRepository;
        }
        public IActionResult Index()
        {
            try
            {
                
                List<Unit> units = UnitRepository.GetUnits();
                return View(units);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving units.");
            }
        }
        public IActionResult Create()
        {
            try
            {
                ViewData["InventoryList"] = InventoryRepository.GetInventorys();
                ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory or unit types for creating unit.");
            }
        }
        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                if (unit != null)
                {
                    UnitRepository.Insert(unit);
                    UnitRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the unit.");
            }

            return View("Create", unit);
        }

        public IActionResult Details(string id)
        {
            try
            {
                Unit unit = UnitRepository.GetUnit(id);
                return View(unit);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving unit details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                ViewData["InventoryList"] = InventoryRepository.GetInventorys();
                ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
                Unit unit = UnitRepository.GetUnit(id);
                return View(unit);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving unit details for editing.");
            }
        }
        [HttpPost]
        public IActionResult Edit(Unit unit, string id)
        {
            try
            {
                if (unit != null)
                {
                    UnitRepository.Update(id, unit);
                    UnitRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the unit.");
            }

            return View(unit);
        }

       
        public IActionResult Delete(string id)
        {
            try
            {
                UnitRepository.Delete(id);
                UnitRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the unit.");
            }
        }
    }
}
