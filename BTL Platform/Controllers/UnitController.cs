using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class UnitController : Controller
    {
        UnitRepository unitRepository;
        UnitTypeRepository unitTypeRepository;
        EmployeeRepository employeeRepository;
        public UnitController(UnitRepository _unitRepository, UnitTypeRepository _unitTypeRepository)
        {
           unitRepository = _unitRepository;
            unitTypeRepository = _unitTypeRepository;
        }
        public IActionResult Index()
        {
            List<Unit> units = unitRepository.GetUnits();
            return View("Index", units); ;
        }

        public IActionResult Create()
        {
            ViewData["unitTypesList"] = unitTypeRepository.GetUnitTypes();
            return View();

        }
        [HttpPost]
        public IActionResult Create(Unit unit)
        {


            if (unit != null)
            {
                unit.InventoryId = 1;
                unitRepository.Insert(unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", unit);
        }

        public IActionResult Details(long id)
        {
            Unit unitid = unitRepository.GetUnit(id);
            return View(unitid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Unit unitid = unitRepository.GetUnit(id);
            ViewData["unitList"] = unitRepository.GetUnits();
            return View(unitid);



        }
        [HttpPost]
        public IActionResult Edit(Unit unit, long id)
        {
            if (unit != null)
            {
                unitRepository.Update(id, unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            unitRepository.Delete(id);
            unitRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
