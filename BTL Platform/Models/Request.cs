using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Request
    {
            
        [Key]
        public long RequestID { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string Channel { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string WH_movements { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public int POSNumber { get; set; }
        public int OnGroundTeams { get; set; }
        public int TrucksNeeded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(Employee))]
        public string Employee_Id { get; set; }
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(Request_type))]
        public long RequestTypeID { get; set; }
        public virtual RequestType Request_type { get; set; }
    }
}
