﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseApp.Infra.Data.DataContext;

#nullable disable

namespace WarehouseApp.MVC.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Delegation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntrieDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FabricationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaterialsInStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OutputDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.MaterialCategory", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("MaterialId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MaterialCategories");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Requisition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.RequisitionEmployee", b =>
                {
                    b.Property<int>("RequisitionId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("RequisitionId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("RequisitionEmployees");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.RequisitionMaterial", b =>
                {
                    b.Property<int>("RequisitionId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("RequisitionId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("RequisitionMaterials");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Login", b =>
                {
                    b.HasOne("WarehouseApp.Domain.Entities.Employee", "Employee")
                        .WithMany("Logins")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.MaterialCategory", b =>
                {
                    b.HasOne("WarehouseApp.Domain.Entities.Category", "Category")
                        .WithMany("MaterialCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseApp.Domain.Entities.Material", "Material")
                        .WithMany("MaterialCategories")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.RequisitionEmployee", b =>
                {
                    b.HasOne("WarehouseApp.Domain.Entities.Employee", "Employee")
                        .WithMany("RequisitionEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseApp.Domain.Entities.Requisition", "Requisition")
                        .WithMany("RequisitionEmployees")
                        .HasForeignKey("RequisitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Requisition");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.RequisitionMaterial", b =>
                {
                    b.HasOne("WarehouseApp.Domain.Entities.Material", "Material")
                        .WithMany("RequisitionMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseApp.Domain.Entities.Requisition", "Requisition")
                        .WithMany("RequisitionMaterials")
                        .HasForeignKey("RequisitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Requisition");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Category", b =>
                {
                    b.Navigation("MaterialCategories");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Logins");

                    b.Navigation("RequisitionEmployees");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Material", b =>
                {
                    b.Navigation("MaterialCategories");

                    b.Navigation("RequisitionMaterials");
                });

            modelBuilder.Entity("WarehouseApp.Domain.Entities.Requisition", b =>
                {
                    b.Navigation("RequisitionEmployees");

                    b.Navigation("RequisitionMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}
