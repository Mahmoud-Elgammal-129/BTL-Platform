using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class InventoryController : Controller
    {
        InventoryRepository InventoryRepository;

        public InventoryController(InventoryRepository _InventoryRepository)
        {
            InventoryRepository = _InventoryRepository;

        }
        public IActionResult Index()
        {
            try
            {
                ViewData["IsInventoryActive"] = true;
                List<Inventory> Inventorys = InventoryRepository.GetInventorys();
                return View(Inventorys);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory data.");
            }
        }

        public IActionResult Create()
        {
            try
            {
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
        public IActionResult Create(Inventory Inventorys)
        {
            try
            {
                if (Inventorys != null)
                {
                    InventoryRepository.Insert(Inventorys);
                    InventoryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the inventory.");
            }

            return View("Create", Inventorys);
        }

        public IActionResult Details(string id)
        {
            try
            {
                Inventory Inventoryid = InventoryRepository.GetInventory(id);
                return View(Inventoryid);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving inventory details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                Inventory Inventoryid = InventoryRepository.GetInventory(id);
                return View(Inventoryid);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while loading the edit view.");
            }
        }
        [HttpPost]
        public IActionResult Edit(Inventory Inventory, string id)
        {
            try
            {
                if (Inventory != null)
                {
                    InventoryRepository.Update(id, Inventory);
                    InventoryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the inventory.");
            }

            return View(Inventory);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                InventoryRepository.Delete(id);
                InventoryRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the inventory.");
            }
        }
    }
}
