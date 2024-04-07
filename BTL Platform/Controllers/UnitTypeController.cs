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
            List<UnitType> UnitTypes = UnitTypeRepository.GetUnitTypes();
            return View(UnitTypes);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(UnitType UnitTypes)
        {


            if (UnitTypes != null)
            {

                UnitTypeRepository.Insert(UnitTypes);
                UnitTypeRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", UnitTypes);
        }

        public IActionResult Details(long id)
        {
            UnitType UnitTypeid = UnitTypeRepository.GetUnitType(id);
            return View(UnitTypeid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            UnitType UnitTypeid = UnitTypeRepository.GetUnitType(id);
            return View(UnitTypeid);
        }
        [HttpPost]
        public IActionResult Edit(UnitType UnitType, long id)
        {
            if (UnitType != null)
            {
                UnitTypeRepository.Update(id, UnitType);
                UnitTypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(UnitType);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {

            UnitTypeRepository.Delete(id);
            UnitTypeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
