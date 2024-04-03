using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class RequestController : Controller
    {
        RequestRepository RequestRepository;
        public RequestController(RequestRepository _RequestRepository)
        {
            RequestRepository = _RequestRepository;
        }
        public IActionResult Index()
        {
            List<Request> requests = RequestRepository.GetRequests();
            return View("RequestPage", requests); ;
        }

        public IActionResult Create()
        {
            List<Request> Requesttype = RequestRepository.GetRequests();
            //onexecuted
            return View(Requesttype);
           
        }
        [HttpPost]
        public IActionResult Create(Request requests)
        {
            if (requests != null)
            {
                RequestRepository.Insert(requests);
                RequestRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", requests);
        }

        public IActionResult Details(long id)
        {
            Request requestid = RequestRepository.GetRequest(id);
            return View(requestid);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Request requestid = RequestRepository.GetRequest(id);
            return View(requestid);
        }
        [HttpPost]
        public IActionResult Edit(Request request, long id)
        {
            if (request != null)
            {
                RequestRepository.Update(id, request);
                RequestRepository.Save();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Delete(long id)
        {

            RequestRepository.Delete(id);
            RequestRepository.Save();
            return RedirectToAction("Index");
        }
        //public IActionResult Search(string searchValue)
        //{
        //    var filteredUsers = RequestRepository.SearchCategories(searchValue);


        //    return PartialView("_CatogriesTablePartial", filteredUsers); // Assuming you have a partial view for the table body
        //}

        // GET: /User/ResetSearch
        //public IActionResult ResetSearch()
        //{
        //    var allUsers = caterepo.GetCategories();


        //    return PartialView("_CatogriesTablePartial", allUsers); // Assuming you have a partial view for the table body
        //}
    }
}

