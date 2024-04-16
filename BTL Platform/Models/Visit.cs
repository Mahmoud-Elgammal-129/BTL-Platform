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
        public string PlaceId { get; set; } = null;
        public string ReportId { get; set; } = null;
        public string UserId { get; set; } = null;
        public DateTime UTCoffset { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string POSPhoto { get; set; } = string.Empty;
        public string UnitsPhotobefore { get; set; } = string.Empty;
        public int UnitsNumbers { get; set; } 
        public string UnitsType { get; set; } = string.Empty;
        public string UnitsPhotoAfter { get; set; } = string.Empty;
        public string placeName { get; set; } = string.Empty;
        public string placeChain { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string UserName  { get; set; } = string.Empty;
        public DateTime PlannedDate { get; set; } 
        public string TaskId { get; set; } = string.Empty;
        public string TaskName { get; set; } = string.Empty;
        //public string RequestID  { get; set; } = string.Empty;
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
        [ForeignKey(nameof(request))]
        public string RequestID { get; set; }
        public virtual Request? request { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey(nameof(VisitStatus))]
        public string VisitStatusId { get; set; }
        public virtual VisitStatus? VisitStatus { get; set; }

        [ForeignKey(nameof(VisitType))]
        public string VisitTypeId { get; set; }
        public virtual VisitType? VisitType { get; set; }

        [ForeignKey(nameof(Place))]
        public string Place_Id { get; set; }
        public virtual Places? Place { get; set; }
    }
}
