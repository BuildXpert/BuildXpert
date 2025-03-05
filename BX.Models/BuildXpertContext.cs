using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BX.Models
{
    public class BuildXpertContext : IdentityDbContext<ApplicationUser>, IBuildXpertContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectState> ProjectStates { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }

        public BuildXpertContext() : base()
        {

        }

        public BuildXpertContext(DbContextOptions<BuildXpertContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 🔹 Configurar relación entre Project y Cliente (Usuario)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Configurar relación entre Project y Administrador (Usuario)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Admin)
                .WithMany(p => p.ProjectsAsAdmin)
                .HasForeignKey(p => p.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Configurar precisión para `decimal`
            modelBuilder.Entity<Project>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Property>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            // 🔹 Configurar relación entre `PedidoProveedor` y `Proveedor`
            modelBuilder.Entity<SupplierOrder>()
                .HasOne(p => p.Supplier)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Asegurar que `Material` sea tratado como un simple string y no como una relación
            modelBuilder.Entity<SupplierOrder>()
                .Property(p => p.Material)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            // 🔹 Configurar relación entre `PagoProveedor` y `Proveedor`
            modelBuilder.Entity<SupplierPayment>()
                .HasOne(p => p.Supplier)
                .WithMany(p => p.Payments)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

