using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Visit
    {
        [Key]
        public long VisitId { get; set; }
        public int PlaceId { get; set; }
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public DateTime UTCoffset { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string POSPhoto { get; set; } = string.Empty;
        public string UnitsPhotobefore { get; set; } = string.Empty;
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
        public int UnitsNumbers { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
        [ForeignKey(nameof(request))]
        public long RequestID { get; set; }
        public virtual Request? request { get; set; }

        [ForeignKey(nameof(User))]
        public long Id { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey(nameof(VisitStatus))]
        public long VisitStatusId { get; set; }
        public virtual VisitStatus? VisitStatus { get; set; }

        [ForeignKey(nameof(VisitType))]
        public long VisitTypeId { get; set; }
        public virtual VisitType? VisitType { get; set; }

        [ForeignKey(nameof(Place))]
        public long Place_Id { get; set; }
        public virtual Places? Place { get; set; }
    }
}
