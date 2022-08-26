﻿// <auto-generated />
using System;
using BstEnvanter.Dal.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    [DbContext(typeof(EfContext))]
    partial class EfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Campus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.CLocation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CLocation");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Common", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("cLocationId")
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cLocationId");

                    b.HasIndex("departmentId");

                    b.ToTable("Common");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Cpu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cpu");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Gpu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Gpu");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.HardDrive", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("HardDrive");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Model", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Personel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("cLocationId")
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("eMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sexId")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("cLocationId");

                    b.HasIndex("departmentId");

                    b.HasIndex("sexId");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int?>("cpuId")
                        .HasColumnType("int");

                    b.Property<int?>("gpuId")
                        .HasColumnType("int");

                    b.Property<int?>("hardDriveId")
                        .HasColumnType("int");

                    b.Property<string>("inventoryNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("modelId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ramId")
                        .HasColumnType("int");

                    b.Property<string>("serialNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("brandId");

                    b.HasIndex("categoryId");

                    b.HasIndex("cpuId");

                    b.HasIndex("gpuId");

                    b.HasIndex("hardDriveId");

                    b.HasIndex("modelId");

                    b.HasIndex("ramId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Ram", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Ram");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("issue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<int>("processNumber")
                        .HasColumnType("int");

                    b.Property<string>("specialist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Sex", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bstId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("campusId")
                        .HasColumnType("int");

                    b.Property<int?>("commonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("personelId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("campusId");

                    b.HasIndex("commonId");

                    b.HasIndex("personelId");

                    b.HasIndex("productId");

                    b.HasIndex("serviceId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Common", b =>
                {
                    b.HasOne("BstEnvanter.Entity.Concrete.CLocation", "CLocation")
                        .WithMany("common")
                        .HasForeignKey("cLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Department", "department")
                        .WithMany("common")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CLocation");

                    b.Navigation("department");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Personel", b =>
                {
                    b.HasOne("BstEnvanter.Entity.Concrete.CLocation", "CLocation")
                        .WithMany("personel")
                        .HasForeignKey("cLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Department", "Department")
                        .WithMany("personel")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Sex", "Sex")
                        .WithMany("personel")
                        .HasForeignKey("sexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CLocation");

                    b.Navigation("Department");

                    b.Navigation("Sex");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Product", b =>
                {
                    b.HasOne("BstEnvanter.Entity.Concrete.Brand", "Brand")
                        .WithMany("product")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Category", "Category")
                        .WithMany("product")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Cpu", "Cpu")
                        .WithMany("product")
                        .HasForeignKey("cpuId");

                    b.HasOne("BstEnvanter.Entity.Concrete.Gpu", "Gpu")
                        .WithMany("product")
                        .HasForeignKey("gpuId");

                    b.HasOne("BstEnvanter.Entity.Concrete.HardDrive", "HardDrive")
                        .WithMany("product")
                        .HasForeignKey("hardDriveId");

                    b.HasOne("BstEnvanter.Entity.Concrete.Model", "Model")
                        .WithMany("product")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Ram", "Ram")
                        .WithMany("product")
                        .HasForeignKey("ramId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Cpu");

                    b.Navigation("Gpu");

                    b.Navigation("HardDrive");

                    b.Navigation("Model");

                    b.Navigation("Ram");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Status", b =>
                {
                    b.HasOne("BstEnvanter.Entity.Concrete.Campus", "Campus")
                        .WithMany("status")
                        .HasForeignKey("campusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Common", "Common")
                        .WithMany("status")
                        .HasForeignKey("commonId");

                    b.HasOne("BstEnvanter.Entity.Concrete.Personel", "Personel")
                        .WithMany("status")
                        .HasForeignKey("personelId");

                    b.HasOne("BstEnvanter.Entity.Concrete.Product", "Product")
                        .WithMany("status")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BstEnvanter.Entity.Concrete.Service", "Service")
                        .WithMany("status")
                        .HasForeignKey("serviceId");

                    b.Navigation("Campus");

                    b.Navigation("Common");

                    b.Navigation("Personel");

                    b.Navigation("Product");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Brand", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Campus", b =>
                {
                    b.Navigation("status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Category", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.CLocation", b =>
                {
                    b.Navigation("common");

                    b.Navigation("personel");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Common", b =>
                {
                    b.Navigation("status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Cpu", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Department", b =>
                {
                    b.Navigation("common");

                    b.Navigation("personel");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Gpu", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.HardDrive", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Model", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Personel", b =>
                {
                    b.Navigation("status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Product", b =>
                {
                    b.Navigation("status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Ram", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Service", b =>
                {
                    b.Navigation("status");
                });

            modelBuilder.Entity("BstEnvanter.Entity.Concrete.Sex", b =>
                {
                    b.Navigation("personel");
                });
#pragma warning restore 612, 618
        }
    }
}
