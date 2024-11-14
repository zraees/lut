using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.Entities;

namespace WorldCareCenter.Api.Models;

public class HelsinkiDBContext : DbContext
{
    public HelsinkiDBContext(DbContextOptions<HelsinkiDBContext> options) : base(options)
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

        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 8, Name = "Sarah Johnson", Email = "sarah.johnson@example.com", Specialty = "Pediatrician" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 9, Name = "Michael Smith", Email = "michael.smith@example.com", Specialty = "Cardiologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 10, Name = "Emily Davis", Email = "emily.davis@example.com", Specialty = "Dermatologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 11, Name = "David Brown", Email = "david.brown@example.com", Specialty = "Orthopedic Surgeon" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 12, Name = "Jessica Wilson", Email = "jessica.wilson@example.com", Specialty = "Neurologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 13, Name = "Laura Martinez", Email = "laura.martinez@example.com", Specialty = "General Practitioner" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 14, Name = "Daniel Anderson", Email = "daniel.anderson@example.com", Specialty = "Endocrinologist" });
        modelBuilder.Entity<Doctor>().HasData(new Doctor() { DoctorID = 15, Name = "Olivia Thomas", Email = "olivia.thomas@example.com", Specialty = "Gynecologist" });
        
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 1, PatientFileNo = "513-001", PatientName = "Robert Lee", Gender = "Male", Email = "robert.lee@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 2, PatientFileNo = "633-957", PatientName = "David Wilson", Gender = "Male", Email = "david.wilson@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 3, PatientFileNo = "413-104", PatientName = "Margaret Young", Gender = "Female", Email = "margaret.young@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 4, PatientFileNo = "952-204", PatientName = "Charles King", Gender = "Male", Email = "charles.king@example.com" });
        modelBuilder.Entity<Patient>().HasData(new Patient() { PatientID = 5, PatientFileNo = "145-304", PatientName = "Thomas Scott", Gender = "Male", Email = "thomas.scott@example.com" });

        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 1, Date = new DateOnly(2024, 01, 26), InvoiceAmount = 180, PatientID = 1 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 2, Date = new DateOnly(2024, 02, 15), InvoiceAmount = 80, PatientID = 5 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 3, Date = new DateOnly(2024, 06, 11), InvoiceAmount = 139, PatientID = 2 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 4, Date = new DateOnly(2024, 11, 16), InvoiceAmount = 115, PatientID = 4 });
        modelBuilder.Entity<Invoice>().HasData(new Invoice() { InvoiceID = 5, Date = new DateOnly(2023, 12, 04), InvoiceAmount = 941, PatientID = 5 });

        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 1, InvoiceId = 4, InvoiceLineItem = "First record" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 2, InvoiceId = 2, InvoiceLineItem = "Second record" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 3, InvoiceId = 2, InvoiceLineItem = "this is medi detail" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 4, InvoiceId = 5, InvoiceLineItem = "Medicine receipt" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 5, InvoiceId = 4, InvoiceLineItem = "Planning data" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 6, InvoiceId = 2, InvoiceLineItem = "available list" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 7, InvoiceId = 3, InvoiceLineItem = "doctor details" });
        modelBuilder.Entity<InvoiceDetail>().HasData(new InvoiceDetail() { InvoiceDetailId = 8, InvoiceId = 1, InvoiceLineItem = "patient record" });
    }
}
