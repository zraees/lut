namespace WorldCareCenter.Api.Entities;

public class Invoice
{
    public int InvoiceID { get; set; }

    public DateOnly Date { get; set; }

    public int PatientID { get; set; }

    public decimal InvoiceAmount { get; set; }
}
