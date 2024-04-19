using BTL_Platform.Models;
using BTL_Platform.Repository;
using BTL_Platform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Platform.Controllers
{
    public class RequestTypeController : Controller
    {
        RequestTypeRepository requestTypeRepository;

        public RequestTypeController(RequestTypeRepository _requestTypeRepository)
        {
            requestTypeRepository = _requestTypeRepository;

        }
        public IActionResult Index()
        {
            List<RequestType> requestType = requestTypeRepository.GetRequestTypes();
            return View(requestType);
        }

        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        public IActionResult Create(RequestType requestType)
        {


            if (requestType != null)
            {

                requestTypeRepository.Insert(requestType);
                requestTypeRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", requestType);
        }

        public IActionResult Details(string id)
        {
            RequestType requesttype = requestTypeRepository.GetRequestType(id);
            return View(requesttype);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            RequestType requesttypeid = requestTypeRepository.GetRequestType(id);
            return View(requesttypeid);
        }
        [HttpPost]
        public IActionResult Edit(RequestType requesttype, string id)
        {
            if (requesttype != null)
            {
                requestTypeRepository.Update(id, requesttype);
                requestTypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(requesttype);
        }

        
        public IActionResult Delete(string id)
        {

            requestTypeRepository.Delete(id);
            requestTypeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
