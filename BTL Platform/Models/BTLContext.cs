using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Models
{
    public class BTLContext:IdentityDbContext<ApplicationUser>
    {
        private DbSet<User> users;

        public BTLContext(DbContextOptions<BTLContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitDetail> UnitDetails { get; set; }
        public virtual DbSet<VisitDetail> VisitDetails { get; set; }
        public virtual DbSet<PlacesDetail> PlacesDetails { get; set; }


        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<User> Users { get => users; set => users = value; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<VisitStatus> VisitStatuses { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }
        public virtual DbSet<InventoryUnit> InventoryUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "employee", NormalizedName = "EMPLOYEE" }
            );

            // Seed a user
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    Name="Zaghlol",
                    UserName = "Zaghlol",
                    NormalizedUserName = "zaghlol",
                    Email = "zaghlol@gmail.com",
                    NormalizedEmail = "zaghlol@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd")
                }
            );

            // Assign role to the user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" }
            );
        }


    }
}
