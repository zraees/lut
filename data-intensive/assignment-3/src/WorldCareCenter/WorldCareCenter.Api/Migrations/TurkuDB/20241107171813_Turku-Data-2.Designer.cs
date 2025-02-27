﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldCareCenter.Api.Models;

#nullable disable

namespace WorldCareCenter.Api.Migrations.TurkuDB
{
    [DbContext(typeof(TurkuDBContext))]
    [Migration("20241107171813_Turku-Data-2")]
    partial class TurkuData2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WorldCareCenter.Api.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorID = 1,
                            Email = "john.doe@email.com",
                            Name = "John Doe",
                            Specialty = "Neurologist"
                        },
                        new
                        {
                            DoctorID = 2,
                            Email = "smith.bruce@email.com",
                            Name = "Smith Bruce",
                            Specialty = "Psychiatrist"
                        },
                        new
                        {
                            DoctorID = 3,
                            Email = "peter.dam@email.com",
                            Name = "Peter Dam",
                            Specialty = "General Physician"
                        },
                        new
                        {
                            DoctorID = 4,
                            Email = "willaim.john@email.com",
                            Name = "William John",
                            Specialty = "Pediatrician"
                        },
                        new
                        {
                            DoctorID = 5,
                            Email = "amar.micheal@email.com",
                            Name = "Amar Micheal",
                            Specialty = "Dermatologist"
                        },
                        new
                        {
                            DoctorID = 6,
                            Email = "tom.hood@email.com",
                            Name = "Tom Hood",
                            Specialty = "Gynecologist"
                        },
                        new
                        {
                            DoctorID = 7,
                            Email = "joni.bob@email.com",
                            Name = "Joni Bob",
                            Specialty = "Ophthalmologist"
                        });
                });

            modelBuilder.Entity("WorldCareCenter.Api.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InvoiceAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientID")
                        .HasColumnType("INTEGER");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceID = 1,
                            Date = new DateOnly(2024, 8, 23),
                            InvoiceAmount = 980m,
                            PatientID = 2
                        },
                        new
                        {
                            InvoiceID = 2,
                            Date = new DateOnly(2024, 7, 3),
                            InvoiceAmount = 580m,
                            PatientID = 1
                        },
                        new
                        {
                            InvoiceID = 3,
                            Date = new DateOnly(2024, 6, 12),
                            InvoiceAmount = 740m,
                            PatientID = 2
                        },
                        new
                        {
                            InvoiceID = 4,
                            Date = new DateOnly(2024, 5, 6),
                            InvoiceAmount = 120m,
                            PatientID = 3
                        },
                        new
                        {
                            InvoiceID = 5,
                            Date = new DateOnly(2024, 3, 4),
                            InvoiceAmount = 156m,
                            PatientID = 5
                        });
                });

            modelBuilder.Entity("WorldCareCenter.Api.Entities.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InvoiceLineItem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("InvoiceDetailId");

                    b.ToTable("InvoiceDetails");

                    b.HasData(
                        new
                        {
                            InvoiceDetailId = 1,
                            InvoiceId = 1,
                            InvoiceLineItem = "First Item"
                        },
                        new
                        {
                            InvoiceDetailId = 2,
                            InvoiceId = 1,
                            InvoiceLineItem = "Second Item"
                        },
                        new
                        {
                            InvoiceDetailId = 3,
                            InvoiceId = 2,
                            InvoiceLineItem = "Second Item"
                        },
                        new
                        {
                            InvoiceDetailId = 4,
                            InvoiceId = 3,
                            InvoiceLineItem = "Medicine Item"
                        },
                        new
                        {
                            InvoiceDetailId = 5,
                            InvoiceId = 4,
                            InvoiceLineItem = "Planning Item"
                        },
                        new
                        {
                            InvoiceDetailId = 6,
                            InvoiceId = 5,
                            InvoiceLineItem = "Item 1"
                        },
                        new
                        {
                            InvoiceDetailId = 7,
                            InvoiceId = 2,
                            InvoiceLineItem = "Two Item"
                        },
                        new
                        {
                            InvoiceDetailId = 8,
                            InvoiceId = 3,
                            InvoiceLineItem = "3rd Item"
                        });
                });

            modelBuilder.Entity("WorldCareCenter.Api.Entities.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientFileNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientID = 1,
                            Email = "emily.johnson@example.com",
                            Gender = "Male",
                            PatientFileNo = "123-422",
                            PatientName = "Emily Johnson"
                        },
                        new
                        {
                            PatientID = 2,
                            Email = "michael.brown@example.com",
                            Gender = "Male",
                            PatientFileNo = "333-467",
                            PatientName = "Michael Brown"
                        },
                        new
                        {
                            PatientID = 3,
                            Email = "sarah.davis@example.com",
                            Gender = "Female",
                            PatientFileNo = "433-454",
                            PatientName = "Sarah Davis"
                        },
                        new
                        {
                            PatientID = 4,
                            Email = "laura.thomas@example.com",
                            Gender = "Female",
                            PatientFileNo = "553-344",
                            PatientName = "Laura Thomas"
                        },
                        new
                        {
                            PatientID = 5,
                            Email = "linda.martin@example.com",
                            Gender = "Female",
                            PatientFileNo = "983-124",
                            PatientName = "Linda Martin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
