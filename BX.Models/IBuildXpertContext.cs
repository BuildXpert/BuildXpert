using Microsoft.EntityFrameworkCore;

namespace BX.Models
{
    public interface IBuildXpertContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ProjectTask> ProjectTask { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierPayment> SupplierPayment { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }
    }
}