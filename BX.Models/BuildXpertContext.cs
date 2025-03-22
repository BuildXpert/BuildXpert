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
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ProjectTask> ProjectTask { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierPayment> SupplierPayment { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }

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

            #region PROJECT MODEL CONFIGURATION
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

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Property)
                .WithOne(p => p.Project)
                .HasForeignKey<Project>(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Status)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ProjectStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(p => p.Project)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

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

