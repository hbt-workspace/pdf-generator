using System;

namespace GeneratePDF.Models;

public class InvoiceViewModel
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;

    public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();

    public decimal SubTotal => Items.Sum(x => x.Total);
    public decimal TaxPercent { get; set; }
    public decimal TaxAmount => SubTotal * TaxPercent / 100;
    public decimal GrandTotal => SubTotal + TaxAmount;
}
