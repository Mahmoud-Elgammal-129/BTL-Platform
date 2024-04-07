using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class RequestVM
    {
        [Key]
        public long RequestID { get; set; }

        [Required(ErrorMessage = "Request date is required")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Channel is required")]
        public string Channel { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Assignee is required")]
        public string Assignee { get; set; }

        [Required(ErrorMessage = "Warehouse movements are required")]
        public string WH_movements { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "POS number is required")]
        public int POSNumber { get; set; }

        [Required(ErrorMessage = "Number of on-ground teams is required")]
        public int OnGroundTeams { get; set; }

        [Required(ErrorMessage = "Number of trucks needed is required")]
        public int TrucksNeeded { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
