﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnBoarding.Infrastructure.Data;

#nullable disable

namespace Onboarding.Infrastructure.Migrations
{
    [DbContext(typeof(OnBoardDbContext))]
    [Migration("20230504062929_InitialCreate.")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Onboarding.ApplicationCore.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("EmployeeCategoryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeStatusCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeCategoryId");

                    b.HasIndex("EmployeeRoleId");

                    b.HasIndex("EmployeeStatusId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Onboarding.ApplicationCore.Entity.EmployeeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("employeeCategories");
                });

            modelBuilder.Entity("Onboarding.ApplicationCore.Entity.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ABBR")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("Onboarding.ApplicationCore.Entity.EmployeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ABBR")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeStatuses");
                });

            modelBuilder.Entity("Onboarding.ApplicationCore.Entity.Employee", b =>
                {
                    b.HasOne("Onboarding.ApplicationCore.Entity.EmployeeCategory", "EmployeeCategory")
                        .WithMany()
                        .HasForeignKey("EmployeeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onboarding.ApplicationCore.Entity.EmployeeRole", "EmployeeRole")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onboarding.ApplicationCore.Entity.EmployeeStatus", "EmployeeStatus")
                        .WithMany()
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeCategory");

                    b.Navigation("EmployeeRole");

                    b.Navigation("EmployeeStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
