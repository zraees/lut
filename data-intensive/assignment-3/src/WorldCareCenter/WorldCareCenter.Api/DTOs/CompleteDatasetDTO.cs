using WorldCareCenter.Api.Entities;

namespace WorldCareCenter.Api.DTOs;

public class CompleteDatasetDTO
{
    public List<Doctor> Doctors { get; set; } = [];

    public List<Patient> Patients { get; set; } = [];

    public List<Invoice> Invoices { get; set; } = [];

    public List<InvoiceDetail> InvoiceDetails { get; set; } = [];
}
