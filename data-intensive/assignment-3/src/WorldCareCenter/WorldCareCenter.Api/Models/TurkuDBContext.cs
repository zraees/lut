using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.Entities;

namespace WorldCareCenter.Api.Models;

public class TurkuDBContext: DbContext
{
    public TurkuDBContext(DbContextOptions<TurkuDBContext> options) : base(options)
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
    }
}
