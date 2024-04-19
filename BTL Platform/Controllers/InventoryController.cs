﻿using BTL_Platform.Models;
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
            List<Inventory> Inventorys = InventoryRepository.GetInventorys();
            return View(Inventorys);
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(Inventory Inventorys)
        {


            if (Inventorys != null)
            {

                InventoryRepository.Insert(Inventorys);
                InventoryRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", Inventorys);
        }

        public IActionResult Details(string id)
        {
            Inventory Inventoryid = InventoryRepository.GetInventory(id);
            return View(Inventoryid);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            Inventory Inventoryid = InventoryRepository.GetInventory(id);
            return View(Inventoryid);
        }
        [HttpPost]
        public IActionResult Edit(Inventory Inventory, string id)
        {
            if (Inventory != null)
            {
                InventoryRepository.Update(id, Inventory);
                InventoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(Inventory);
        }

        
        public IActionResult Delete(string id)
        {

            InventoryRepository.Delete(id);
            InventoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
