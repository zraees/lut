using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.Entities;

namespace WorldCareCenter.Api.Models;

public class LahtiDBContext: DbContext
{
    public LahtiDBContext(DbContextOptions<LahtiDBContext> options) : base(options)
    {
        
    }

    public DbSet<Doctor> Doctors { get; set; } 

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 1, Name = "John Doe", Email = "john.doe@email.com", Specialty = "Neurologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 2, Name = "Smith Bruce", Email = "smith.bruce@email.com", Specialty = "Psychiatrist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 3, Name = "Peter Dam", Email = "peter.dam@email.com", Specialty = "General Physician" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 4, Name = "William John", Email = "willaim.john@email.com", Specialty = "Pediatrician" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 5, Name = "Amar Micheal", Email = "amar.micheal@email.com", Specialty = "Dermatologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 6, Name = "Tom Hood", Email = "tom.hood@email.com", Specialty = "Gynecologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 7, Name = "Joni Bob", Email = "joni.bob@email.com", Specialty = "Ophthalmologist" });

        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 1, PatientFileNo = "951-522", PatientName = "Joseph Hall", Gender = "Male", Email = "joseph.hall@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 2, PatientFileNo = "951-497", PatientName = "Thomas Scott", Gender = "Male", Email = "thomas.scott@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 3, PatientFileNo = "147-404", PatientName = "Barbara Green", Gender = "Female", Email = "barbara.green@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 4, PatientFileNo = "741-314", PatientName = "Jennifer White", Gender = "Female", Email = "jennifer.white@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 5, PatientFileNo = "256-024", PatientName = "Jessica Taylor", Gender = "Female", Email = "jessica.taylor@example.com" });

        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 1, Date = new DateOnly(2023, 01, 03), InvoiceAmount = 180, PatientID = 1 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 2, Date = new DateOnly(2024, 02, 13), InvoiceAmount = 500, PatientID = 2 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 3, Date = new DateOnly(2024, 06, 02), InvoiceAmount = 240, PatientID = 3 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 4, Date = new DateOnly(2024, 07, 16), InvoiceAmount = 620, PatientID = 4 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 5, Date = new DateOnly(2024, 05, 14), InvoiceAmount = 146, PatientID = 5 });

        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 1, InvoiceId = 1, InvoiceLineItem = "Three Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 2, InvoiceId = 1, InvoiceLineItem = "Mid Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 3, InvoiceId = 2, InvoiceLineItem = "Top Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 4, InvoiceId = 3, InvoiceLineItem = "Medicine Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 5, InvoiceId = 4, InvoiceLineItem = "Item 1" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 6, InvoiceId = 5, InvoiceLineItem = "Planning Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 7, InvoiceId = 2, InvoiceLineItem = "Two 2 Item" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 8, InvoiceId = 3, InvoiceLineItem = "13th Item" });

    }
}
