using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class VisitVM
    {
        [Key]
        public long VisitId { get; set; }

        [Required(ErrorMessage = "Place ID is required")]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "Report ID is required")]
        public int ReportId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UTC offset is required")]
        public DateTime UTCoffset { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; } = DateTime.Now;

        public string POSPhoto { get; set; } = string.Empty;

        public string UnitsPhotobefore { get; set; } = string.Empty;

        public string UnitsPhotoAfter { get; set; } = string.Empty;

        public string PlaceName { get; set; } = string.Empty;

        public string PlaceChain { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Planned date is required")]
        public DateTime PlannedDate { get; set; }

        public string TaskId { get; set; } = string.Empty;

        public string TaskName { get; set; } = string.Empty;

        //public string RequestID  { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Units numbers must be greater than zero")]
        public int UnitsNumbers { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
