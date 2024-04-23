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
            List<Places> Placess = PlacesRepository.GetPlacess();
            return View( Placess); 
        }

        public IActionResult Create()
        {
            //ViewBag.UnitTypeList = btlContext.UnitTypes.Select(u => new SelectListItem
            //{
            //    Value = u.UnitTypeId.ToString(),
            //    Text = u.UnitTypeName
            //}).ToList();
            ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
            return View();

        }
        [HttpPost]
        public IActionResult Create(Places Placess)
        {


            if (Placess != null)
            {

                PlacesRepository.Insert(Placess);
                PlacesRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", Placess);
        }

        public IActionResult Details(string id)
        {
            Places Placesid = PlacesRepository.GetPlaces(id);
            return View(Placesid);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewData["UnitTypeList"] = UnitTypeRepository.GetUnitTypes();
            Places Placesid = PlacesRepository.GetPlaces(id);
            return View(Placesid);
        }
        [HttpPost]
        public IActionResult Edit(Places Places, string id)
        {
            if (Places != null)
            {
                PlacesRepository.Update(id, Places);
                PlacesRepository.Save();
                return RedirectToAction("Index");
            }
            return View(Places);
        }

        
        public IActionResult Delete(string id)
        {

            PlacesRepository.Delete(id);
            PlacesRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
