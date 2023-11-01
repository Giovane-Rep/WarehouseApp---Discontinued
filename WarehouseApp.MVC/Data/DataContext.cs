using Microsoft.EntityFrameworkCore;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionMaterial> RequisitionMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Relationship between Requisition and Employee 'Meny to One'

            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Requisitions)
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

            //Relationship between Material and Category 'One to Many'

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Materials)
                .HasForeignKey(m => m.CategoryId);

            //Relationship between Employee and Login 'One to One'
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Login)
                .WithOne()
                .HasForeignKey<Employee>(e => e.LoginId);
        }
    }
}
