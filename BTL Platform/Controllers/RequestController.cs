
using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using DocumentFormat.OpenXml.Office.CustomUI;
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
        VisitRepository VisitRepository;

        VisitTypeRepository VisitTypeRepository;
        EmployeeRepository employeeRepository;
        VisitRepository visitRepository;
        UserManager<ApplicationUser> usermanager;
        public RequestController(RequestRepository _RequestRepository, RequestTypeRepository _requestTypeRepository, EmployeeRepository _employeeRepository, UserManager<ApplicationUser> usermanager, VisitTypeRepository visitTypeRepository, VisitRepository visitRepository)
        {
            RequestRepository = _RequestRepository;
            RequestTypeRepository = _requestTypeRepository;
            employeeRepository = _employeeRepository;
            this.usermanager = usermanager;
            VisitTypeRepository = visitTypeRepository;
            VisitRepository = visitRepository;
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
        public static DataTable ReadExcel(IFormFile excelFile, string sheetName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = excelFile.OpenReadStream())
            {
                DataTable excelDataTable;
                DataTable filteredDataTable;

                using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    // Get the DataSet from the Excel file
                    var dataSet = reader.AsDataSet(conf);

                    // Check if the specified sheet name exists in the DataSet
                    if (!dataSet.Tables.Contains(sheetName))
                    {
                        throw new ArgumentException("Invalid sheet name");
                    }

                    // Retrieve the DataTable corresponding to the specified sheet name
                    excelDataTable = dataSet.Tables[sheetName];

                    for (int i = 0; i < excelDataTable.Columns.Count; i++)
                    {
                        excelDataTable.Columns[i].ColumnName = excelDataTable.Columns[i].ColumnName.Trim();
                    }

                    // Create a new DataTable to store non-empty rows
                    //filteredDataTable = excelDataTable.Clone();

                    //// Iterate through rows and copy non-empty rows to the new DataTable
                    //foreach (DataRow row in excelDataTable.Rows)
                    //{
                    //    bool isRowEmpty = string.IsNullOrWhiteSpace(row["DC"].ToString());
                    //    if (!isRowEmpty)
                    //    {
                    //        filteredDataTable.Rows.Add(row.ItemArray); // Copy the non-empty row to the new DataTable
                    //    }
                    //}
                }

                return excelDataTable;
            }
        }

        private List<Visit> ConvertDataTableToVisitList(DataTable dataTable)
        {
            List<Visit> visits = new List<Visit>();

            foreach (DataRow row in dataTable.Rows)
            {
                Visit visit = new Visit();

                //if (row["Request_ID"] != null )
                //{
                //    visit.RequestID = row["Request_ID"].ToString();
                //}
                if (row["date"] != null && DateTime.TryParse(row["date"].ToString(), out DateTime date))
                {
                    visit.date = date;
                }
                if (row["UTC offset"] != null && DateTime.TryParse(row["UTC offset"].ToString(), out DateTime utcOffset))
                {
                    visit.UTCoffset = utcOffset;
                }
                if (row["place_id"] != null)
                {
                    visit.Place_Id = row["place_id"].ToString();
                }
                if (row["User_id"] != null)
                {
                    visit.Id = row["User_id"].ToString();
                }
                if (row["place_name"] != null)
                {
                    visit.placeName = row["place_name"].ToString();
                }
                if (row["place_chain"] != null)
                {
                    visit.placeChain = row["place_chain"].ToString();
                }
                if (row["report_id"] != null)
                {
                    visit.RequestID = row["report_id"].ToString();
                }
                if (row["POS Photo"] != null)
                {
                    visit.POSPhoto = row["POS Photo"].ToString();
                }
                if (row["Units Photo before"] != null)
                {
                    visit.UnitsPhotobefore = row["Units Photo before"].ToString();
                }
                if (row["Units Numbers"] != null)
                {
                    if (!string.IsNullOrEmpty(row["Units Numbers"].ToString()))
                        visit.UnitsNumbers = int.Parse(row["Units Numbers"].ToString());
                }

                if (row["Units Photo After"] != null)
                {
                    visit.UnitsPhotoAfter = row["Units Photo After"].ToString();
                }
                if (row["Status"] != null)
                {
                    visit.Status = row["Status"].ToString();
                }
                if (row["Notes"] != null)
                {
                    visit.Notes = row["Notes"].ToString();
                }
                if (row["User_name"] != null)
                {
                    visit.UserName = row["User_name"].ToString();
                }
                if (row["Task_id"] != null)
                {
                    visit.TaskId = row["Task_id"].ToString();
                }
                if (row["Task_name"] != null)
                {
                    visit.TaskName = row["Task_name"].ToString();
                }

                // Continue setting other properties similarly

                visits.Add(visit);
            }

            return visits;
        }
    }
}

