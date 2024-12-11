using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Pages.Shopping
{
    public class DeleteModel : PageModel
    {
        private readonly IDbcontext _context;
        private readonly IDbcontext _mongoContext;

        public DeleteModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia, [FromKeyedServices("MDB")] IDbcontext mdbContext)
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
            _mongoContext = mdbContext;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var prodImage = _mongoContext.ProductImage.FirstOrDefault(m => m.ProductID == id);
                if (prodImage != null)
                {
                    using (var stream = new MemoryStream(prodImage.Image))
                    {
                        //var image = Image.FromStream(stream);
                        product.ProductImage = new FormFile(stream, 0, stream.Length, "Product.ProductImage", product.Name + ".png")
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = "image/png",
                            ContentDisposition = "form-data; name=\"Product.ProductImage\"; filename=\"" + product.Name + ".png\""
                        };
                        product.Image = stream.ToArray();
                    }
                }

                Product = product;
            }

            var categories = new List<string>()
            {
                "Stationary", "Accessories", "Apparel"
            };
            ViewData["ProductCategory"] = categories.Select(m => new SelectListItem() { Text = m, Value = m });

            var stock = _context.WarehouseStock.FirstOrDefault(m => m.ProductID == Product.ID);
            if (stock != null)
            {
                Product.StockQuantity = stock.AvailableQty;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                Product = product;
                _context.Product.Remove(Product);

                var stock = _context.WarehouseStock.FirstOrDefault(m => m.ProductID == Product.ID);
                if (stock != null)
                {
                    _context.WarehouseStock.Remove(stock);
                }

                await _context.SaveChangesAsync();

                var prodImage = _mongoContext.ProductImage.FirstOrDefault(m => m.ProductID == id);
                if (prodImage != null)
                {
                    _mongoContext.ProductImage.Remove(prodImage);
                    await _mongoContext.SaveChangesAsync();
                }

            }

            return RedirectToPage("./Index");
        }
    }
}
