
using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
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
        VisitRepository VisitRepository;

        VisitTypeRepository VisitTypeRepository;
        EmployeeRepository employeeRepository;
        VisitRepository visitRepository;
        UserManager<ApplicationUser> usermanager;
        public RequestController(RequestRepository _RequestRepository, RequestTypeRepository _requestTypeRepository, EmployeeRepository _employeeRepository, UserManager<ApplicationUser> usermanager)
        {
            RequestRepository = _RequestRepository;
            RequestTypeRepository = _requestTypeRepository;
            employeeRepository = _employeeRepository;
            this.usermanager = usermanager;
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

        [HttpPost]
        public IActionResult Upload(IFormFile excelFile, string id)
        {
            if (excelFile != null && excelFile.Length > 0)
            {
                string sheetName = "Reports";
                var dataTable = ReadExcel(excelFile, sheetName);

                var visits = ConvertDataTableToVisitList(dataTable);

                var RequestData = RequestRepository.GetRequest(id);

                #region passing Values to Table visit
                foreach (var item in visits)
                {
                    item.Id = null; // you will rememove it 
                    //item.Place_Id = RequestData.
                    item.Place_Id = null;    // you will remove it and add taht after adding placeid to requet  ;// you will add place id after adding it to request 
                    
                    
                    item.RequestID = RequestData.RequestID;
                    

                    item.date = RequestData.RequestDate;// ensure from the data specific 

                }
                #endregion

                VisitRepository.Insert(visits);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Upload");
            }
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


        //    return PartialView("_CatogriesTablePartial", allUsers); // Assuming you have a partial view for the table body
        //}
    }
}

