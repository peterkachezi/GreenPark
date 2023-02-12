using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.DAL.Models;


namespace ParkingSystem.DAL.DbContext
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<ParkingSlot> ParkingSlots { get; set; } = null!;
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
