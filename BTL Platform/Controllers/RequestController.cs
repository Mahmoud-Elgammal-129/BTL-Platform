﻿
using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using ExcelDataReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BTL_Platform.Controllers
{
    public class RequestController : Controller
    {
        RequestRepository RequestRepository;
        RequestTypeRepository RequestTypeRepository;
        EmployeeRepository employeeRepository;
        VisitRepository visitRepository;
        UserManager<ApplicationUser> usermanager;
        public RequestController(RequestRepository _RequestRepository, RequestTypeRepository _requestTypeRepository,
            EmployeeRepository _employeeRepository, UserManager<ApplicationUser> usermanager, VisitRepository _visitRepository)
        {
            RequestRepository = _RequestRepository;
            RequestTypeRepository = _requestTypeRepository;
            employeeRepository = _employeeRepository;
            this.usermanager = usermanager;
            this.visitRepository = _visitRepository;
        }
        public IActionResult Index()
        {
            List<Request> requests = RequestRepository.GetRequests();
            return View("RequestPage", requests); ;
        }

        public IActionResult Create()
        {
            ViewData["RequestTypesList"] = RequestTypeRepository.GetRequestTypes();
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Request requests)
        {
            var user = await usermanager.GetUserAsync(User);

            if (requests != null)
            {
                requests.Employee_Id = user.Id;
                RequestRepository.Insert(requests);
                RequestRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", requests);
        }

        public IActionResult Details(string id)
        {
            Request requestid = RequestRepository.GetRequest(id);
            return View(requestid);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            Request requestid = RequestRepository.GetRequest(id);
            ViewData["RequestTypesList"] = RequestTypeRepository.GetRequestTypes();

            return View(requestid);
        }
        [HttpPost]
        public IActionResult Edit(Request request, string id)
        {
            if (request != null)
            {
                RequestRepository.Update(id, request);
                RequestRepository.Save();
                return RedirectToAction("Index");
            }
            return View(request);
        }
     
        
        public IActionResult Delete(string id)
        {

            RequestRepository.Delete(id);
            RequestRepository.Save();
            return RedirectToAction("RequestPage");
        }

      
        public IActionResult Search(string searchValue)
        {
            var filteredUsers = RequestRepository.SearchRequest(searchValue);


            return View("RequestPage", filteredUsers); // Assuming you have a partial view for the table body
        }

        //GET: /User/ResetSearch
        public IActionResult ResetSearch()
        {
            var allUsers = RequestRepository.GetRequests();


            return View("RequestPage", allUsers); // Assuming you have a partial view for the table body
        }
    }
}

