﻿// <auto-generated />
using System;
using Bsd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bsd.Infrastructure.Migrations
{
    [DbContext(typeof(BsdDbContext))]
    [Migration("20240308113839_NewMigration01")]
    partial class NewMigration01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Bsd.Domain.Entities.BsdEntity", b =>
                {
                    b.Property<int>("BsdNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateService")
                        .HasColumnType("TEXT");

                    b.Property<int>("DayType")
                        .HasColumnType("INTEGER");

                    b.HasKey("BsdNumber");

                    b.ToTable("BsdEntities");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Registration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateService")
                        .HasColumnType("TEXT");

                    b.Property<int>("Digit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Registration");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.EmployeeBsdEntity", b =>
                {
                    b.Property<int>("EmployeeRegistration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BsdNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeRegistration", "BsdNumber");

                    b.HasIndex("BsdNumber");

                    b.ToTable("EmployeesBsdEntities");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.Rubric", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<int>("DayType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeBsdEntityBsdNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployeeBsdEntityEmployeeRegistration")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("HoursPerDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Code");

                    b.HasIndex("EmployeeBsdEntityEmployeeRegistration", "EmployeeBsdEntityBsdNumber");

                    b.ToTable("Rubrics");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.EmployeeBsdEntity", b =>
                {
                    b.HasOne("Bsd.Domain.Entities.BsdEntity", "BsdEntity")
                        .WithMany("EmployeeBsdEntities")
                        .HasForeignKey("BsdNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bsd.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeBsdEntities")
                        .HasForeignKey("EmployeeRegistration")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BsdEntity");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.Rubric", b =>
                {
                    b.HasOne("Bsd.Domain.Entities.EmployeeBsdEntity", null)
                        .WithMany("Rubrics")
                        .HasForeignKey("EmployeeBsdEntityEmployeeRegistration", "EmployeeBsdEntityBsdNumber");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.BsdEntity", b =>
                {
                    b.Navigation("EmployeeBsdEntities");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeBsdEntities");
                });

            modelBuilder.Entity("Bsd.Domain.Entities.EmployeeBsdEntity", b =>
                {
                    b.Navigation("Rubrics");
                });
#pragma warning restore 612, 618
        }
    }
}
