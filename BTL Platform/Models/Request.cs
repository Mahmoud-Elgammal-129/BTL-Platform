using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Request
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Request()
        {
            RequestID = GenerateUniqueId();
        }

        [Key]
        public string RequestID { get; set; }
        [Required(ErrorMessage = "Request date is required")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Channel is required")]
        public string Channel { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }= string.Empty;

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

        [ForeignKey(nameof(Employee))]

        public string? Employee_Id { get; set; }
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(Request_type))]
        [Required(ErrorMessage = "Request Type ID is required")]

        public string? RequestTypeID { get; set; }
        public virtual RequestType Request_type { get; set; }
    }
}
