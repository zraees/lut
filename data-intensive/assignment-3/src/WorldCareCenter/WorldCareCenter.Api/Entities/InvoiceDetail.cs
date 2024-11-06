namespace WorldCareCenter.Api.Entities;

public class InvoiceDetail
{
    public int InvoiceDetailId { get; set; }

    public int InvoiceId { get; set; }

    public string InvoiceLineItem { get; set; }
}
