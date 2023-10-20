using Microsoft.EntityFrameworkCore;
using WarehouseApp.Domain.Entities;

namespace WarehouseApp.Infra.Data.DataContext {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionEmployee> RequisitionEmployees { get; set; }
        public DbSet<RequisitionMaterial> RequisitionMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Relationship between Requisition and Employee 'Many to Many'
            modelBuilder.Entity<RequisitionEmployee>()
                .HasKey(re => new { re.RequisitionId, re.EmployeeId });

            modelBuilder.Entity<RequisitionEmployee>()
                .HasOne(e => e.Requisition)
                .WithMany(re => re.RequisitionEmployees)
                .HasForeignKey(e => e.RequisitionId);

            modelBuilder.Entity<RequisitionEmployee>()
                .HasOne(r => r.Employee)
                .WithMany(re => re.RequisitionEmployees)
                .HasForeignKey(r => r.EmployeeId);

            //Relationship between Requisition and Material 'Many to Many'
            modelBuilder.Entity<RequisitionMaterial>()
                .HasKey(rm => new {rm.RequisitionId, rm.MaterialId});

            modelBuilder.Entity<RequisitionMaterial>()
                .HasOne(m => m.Requisition)
                .WithMany(rm => rm.RequisitionMaterials)
                .HasForeignKey(m => m.RequisitionId);

            modelBuilder.Entity<RequisitionMaterial>()
                .HasOne(r => r.Material)
                .WithMany(rm => rm.RequisitionMaterials)
                .HasForeignKey(r => r.MaterialId);

            //Relationship between Material and Category 'Many to Many'
            modelBuilder.Entity<MaterialCategory>()
                .HasKey(mc => new {mc.MaterialId, mc.CategoryId});

            modelBuilder.Entity<MaterialCategory>()
                .HasOne(c => c.Material)
                .WithMany(mc => mc.MaterialCategories)
                .HasForeignKey(c => c.MaterialId);

            modelBuilder.Entity<MaterialCategory>()
                .HasOne(m => m.Category)
                .WithMany(mc => mc.MaterialCategories)
                .HasForeignKey(m => m.CategoryId);

            //Relationship between Employee and Login 'One to Many'
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Logins)
                .WithOne(l => l.Employee)
                .HasForeignKey(l => l.EmployeeId); 
        }
    }
}
