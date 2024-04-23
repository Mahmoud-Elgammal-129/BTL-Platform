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
            try
            {
                ViewData["IsRequestTypeActive"] = true;
                List<RequestType> requestType = requestTypeRepository.GetRequestTypes();
                return View(requestType);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving request types.");
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
        public IActionResult Create(RequestType requestType)
        {
            try
            {
                if (requestType != null)
                {
                    requestTypeRepository.Insert(requestType);
                    requestTypeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while creating the request type.");
            }

            return View("Create", requestType);
        }

        public IActionResult Details(string id)
        {
            try
            {
                RequestType requestType = requestTypeRepository.GetRequestType(id);
                return View(requestType);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while retrieving request type details.");
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                RequestType requestType = requestTypeRepository.GetRequestType(id);
                return View(requestType);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while loading the edit view.");
            }
        }
        [HttpPost]
        public IActionResult Edit(RequestType requestType, string id)
        {
            try
            {
                if (requestType != null)
                {
                    requestTypeRepository.Update(id, requestType);
                    requestTypeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while updating the request type.");
            }

            return View(requestType);
        }

        
        public IActionResult Delete(string id)
        {
            try
            {
                requestTypeRepository.Delete(id);
                requestTypeRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally, you can return an error view or redirect to an error page
                return StatusCode(500, "An error occurred while deleting the request type.");
            }
        }
    }
}
