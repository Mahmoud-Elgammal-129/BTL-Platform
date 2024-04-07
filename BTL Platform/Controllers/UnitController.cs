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
        BTLContext btlContext;

        public UnitController(UnitRepository _UnitRepository, BTLContext btlContext)
        {
            UnitRepository = _UnitRepository;
            this.btlContext = btlContext;
        }
        public IActionResult Index()
        {
            List<Unit> Units = UnitRepository.GetUnits();
            return View(Units);
        }
        public IActionResult Create()
        {
            ViewBag.InventoryList = btlContext.Inventories.Select(i => new SelectListItem
            {
                Value = i.InventoryId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.UnitTypeList = btlContext.UnitTypes.Select(u => new SelectListItem
            {
                Value = u.UnitTypeId.ToString(),
                Text = u.UnitTypeName
            }).ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Unit Units)
        {
            if (Units != null)
            {
                UnitRepository.Insert(Units);
                UnitRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Create", Units);
        }

        public IActionResult Details(long id)
        {
            Unit Unitid = UnitRepository.GetUnit(id);
            return View(Unitid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.InventoryList = btlContext.Inventories.Select(i => new SelectListItem
            {
                Value = i.InventoryId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.UnitTypeList = btlContext.UnitTypes.Select(u => new SelectListItem
            {
                Value = u.UnitTypeId.ToString(),
                Text = u.UnitTypeName
            }).ToList();


            Unit Unitid = UnitRepository.GetUnit(id);
            return View(Unitid);
        }
        [HttpPost]
        public IActionResult Edit(Unit Unit, long id)
        {
            if (Unit != null)
            {
                UnitRepository.Update(id, Unit);
                UnitRepository.Save();
                return RedirectToAction("Index");
            }
            return View(Unit);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            UnitRepository.Delete(id);
            UnitRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
