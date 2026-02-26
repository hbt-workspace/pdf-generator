using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeneratePDF.Models;

namespace GeneratePDF.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult PDFTemplate()
    {
        var model = new InvoiceViewModel
        {
            InvoiceNumber = "INV-1001",
            InvoiceDate = DateTime.Now,
            CustomerName = "John Doe",
            CustomerAddress = "123 Main Street, New York",
            TaxPercent = 18,
            Items = new List<InvoiceItemViewModel>
            {
                new InvoiceItemViewModel { Description = "Website Development", Quantity = 1, UnitPrice = 50000 },
                new InvoiceItemViewModel { Description = "Hosting (1 Year)", Quantity = 1, UnitPrice = 5000 }
            }
        };
        return View(model);
    }

    public IActionResult DownloadPdf()
    {
        // PDF generation logic here
        return Content("PDF Generated Successfully");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
