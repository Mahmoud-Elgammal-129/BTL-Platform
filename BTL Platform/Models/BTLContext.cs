using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Models
{
    public class BTLContext:DbContext
    {
        public BTLContext(DbContextOptions<BTLContext> options) : base(options)
        {
        }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<VisitStatus> VisitStatuses { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }
        
       
    }
}
