﻿// <auto-generated />
using API.Controllers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace fortest.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20231010075412_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fortest.Controllers.Module.Employees", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpPhone")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("fortest.Controllers.StudentModule.Students", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuId"));

                    b.Property<int>("EmpPhone")
                        .HasColumnType("int");

                    b.Property<string>("StuDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StuId");

                    b.HasIndex("EmpPhone");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("fortest.Controllers.StudentModule.Students", b =>
                {
                    b.HasOne("fortest.Controllers.Module.Employees", "employees")
                        .WithMany("Students")
                        .HasForeignKey("EmpPhone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");
                });

            modelBuilder.Entity("fortest.Controllers.Module.Employees", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
