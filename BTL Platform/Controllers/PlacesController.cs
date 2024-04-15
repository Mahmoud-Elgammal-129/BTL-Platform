using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class PlacesController : Controller
    {
        PlacesRepository PlacesRepository;

        public PlacesController(PlacesRepository _PlacesRepository)
        {
            PlacesRepository = _PlacesRepository;

        }
        public IActionResult Index()
        {
            List<Places> Placess = PlacesRepository.GetPlacess();
            return View( Placess); 
        }

        public IActionResult Create()
        {


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

        [HttpPost]
        public IActionResult Delete(string id)
        {

            PlacesRepository.Delete(id);
            PlacesRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
