using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.IO;
using System.IO.Compression;

namespace GlobalShopping.Pages.Shopping
{
    public class CreateModel : PageModel
    {
        private readonly IDbcontext _context;
        private readonly IDbcontext _mdbContext;

        public CreateModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia, [FromKeyedServices("MDB")] IDbcontext mdbContext)
        {
            switch (RegionConfiguration.DefaultRegionID)
            {
                case SupportedRegion.Europe:
                    _context = eu;
                    break;
                case SupportedRegion.Asia:
                    _context = asia;
                    break;
                default:
                    _context = usa;
                    break;
            }
            _mdbContext = mdbContext;
        }

        public IActionResult OnGet()
        {
            var categories = new List<string>()
            {
                "Stationary", "Accessories", "Apparel"
            };
            ViewData["ProductCategory"] = categories.Select(m => new SelectListItem() { Text = m, Value = m });
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);

            var stock = new WarehouseStock()
            {
                ProductID = Product.ID,
                AvailableQty = Product.StockQuantity
            };

            _context.WarehouseStock.Add(stock);

            await _context.SaveChangesAsync();

            if (Product?.ProductImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Product?.ProductImage?.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        //_mdbContext.Product.Add(Product);
                        _mdbContext.ProductImage.Add(new ProductImage() { ProductID = Product.ID, Image = memoryStream.ToArray() });
                        await _mdbContext.SaveChangesAsync();
                    }
                }
            }

            

            return RedirectToPage("./Index");
        }
    }
}
