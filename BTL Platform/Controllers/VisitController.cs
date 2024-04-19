using BTL_Platform.Models;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO.Packaging;
using System.Xml.Linq;
using System.Data;
using ExcelDataReader;

namespace BTL_Platform.Controllers
{
    public class VisitController : Controller
    {
        VisitRepository VisitRepository;
        UserRepository UserRepository;
        VisitTypeRepository VisitTypeRepository;
        VisitStatusRepository VisitStatusRepository;
        PlacesRepository PlacesRepository;
        public VisitController(VisitRepository _VisitRepository, VisitTypeRepository visitTypeRepository, UserRepository userRepository, PlacesRepository placesRepository, VisitStatusRepository visitStatusRepository)
        {
            VisitRepository = _VisitRepository;
            VisitTypeRepository = visitTypeRepository;
            UserRepository = userRepository;
            PlacesRepository = placesRepository;
            VisitStatusRepository = visitStatusRepository;
        }
        public IActionResult Index()
        {
            List<Visit> Visits = VisitRepository.GetVisits();
            return View(Visits);
        }
        public IActionResult Create()
        {
            ViewBag.User = UserRepository.GetUsers().Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UserName }).ToList();
            ViewBag.VisitTypes = VisitTypeRepository.GetVisitTypes().Select(vt => new SelectListItem { Value = vt.VisitTypeId.ToString(), Text = vt.VisitTypeName }).ToList();
            ViewBag.VisitStatus = VisitStatusRepository.GetVisitStatuss().Select(vs => new SelectListItem { Value = vs.VisitStatusId.ToString(), Text = vs.VisitStatusName }).ToList();
            ViewBag.Places = PlacesRepository.GetPlacess().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.DisplayName }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Visit Visits)
        {
            if (Visits != null)
            {
                VisitRepository.Insert(Visits);
                VisitRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Create", Visits);
        }
        public IActionResult Details(string id)
        {
            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Users = UserRepository.GetUsers();
            ViewBag.VisitTypes = VisitTypeRepository.GetVisitTypes();
            ViewBag.VisitStatus = VisitStatusRepository.GetVisitStatuss();
            ViewBag.Places = PlacesRepository.GetPlacess();
            Visit Visitid = VisitRepository.GetVisit(id);
            return View(Visitid);
        }
        [HttpPost]
        public IActionResult Edit(Visit Visit, string id)
        {
            if (Visit != null)
            {
                VisitRepository.Update(id, Visit);
                VisitRepository.Save();
                return RedirectToAction("Index");
            }
            return View(Visit);
        }
        
        public IActionResult Delete(string id)
        {

            VisitRepository.Delete(id);
            VisitRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Upload(IFormFile excelFile)
        {
            if (excelFile != null && excelFile.Length > 0)
            {
                string sheetName = "Reports"; 
                var dataTable = ReadExcel(excelFile, sheetName);
                
                var visits = ConvertDataTableToVisitList(dataTable);
                //**************************** we should remove that bf  ********************************************************
                foreach (var item in visits)
                {
                    item.Place_Id = null;
                    item.RequestID = null;
                    item.Id = null;
                    item.VisitStatusId = null;
                    item.VisitTypeId = null;
                }

                VisitRepository.Insert(visits);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Upload");
            }
        }

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
