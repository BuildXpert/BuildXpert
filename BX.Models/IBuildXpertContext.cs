using Microsoft.EntityFrameworkCore;

namespace BX.Models
{
    public interface IBuildXpertContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectState> ProjectStates { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
    }
}