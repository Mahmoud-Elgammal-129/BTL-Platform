using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Visit
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Visit()
        {
            VisitId = GenerateUniqueId();
        }
        [Key]
        public string VisitId { get; set; }

        [Required(ErrorMessage = "UTC offset is required")]
        public DateTime? UTCoffset { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Date is required")]
        public DateTime date { get; set; } = DateTime.Now;
        public string POSPhoto { get; set; } = string.Empty;
        public string UnitsPhotobefore { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Units numbers must be greater than zero")]

        public int UnitsNumbers { get; set; } = 0;
        public string UnitsType { get; set; } = string.Empty;
        public string UnitsPhotoAfter { get; set; } = string.Empty;
        public string placeName { get; set; } = string.Empty;
        public string placeChain { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
       
        
        public string UserName  { get; set; } = string.Empty;
        [Required(ErrorMessage = "Planned date is required")]

        public DateTime? PlannedDate { get; set; } = DateTime.Now;
        public string TaskId { get; set; } = string.Empty;
        public string TaskName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        [ForeignKey(nameof(request))]
        public string? RequestID { get; set; } = null;
        public virtual Request? request { get; set; }

        [ForeignKey(nameof(User))]
        [Required(ErrorMessage = "User ID is required")]

        public string? Id { get; set; } = null;
        public virtual User? User { get; set; }

        [ForeignKey(nameof(visitStatus))]
        //[Required(ErrorMessage = "Visit Status ID is required")]

        public string? VisitStatusId { get; set; } = null;
        public virtual VisitStatus? visitStatus { get; set; }

        [ForeignKey(nameof(visitType))]
        //[Required(ErrorMessage = "Visit Type ID is required")]

        public string? VisitTypeId { get; set; } = null;
        public virtual VisitType? visitType { get; set; }

        [ForeignKey(nameof(Place))]
        //[Required(ErrorMessage = "Place ID is required")]

        public string? Place_Id { get; set; } = null;
        public virtual Places? Place { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey(nameof(user))]
        public string CreatedBy { get; set; }
        public ApplicationUser user { get; set; }
    }
}
