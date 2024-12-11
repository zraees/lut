using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GlobalShopping.Pages.Shopping
{
    public class EditModel : PageModel
    {
        private readonly IDbcontext _context;
        private readonly IDbcontext _mongoContext;

        public EditModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia, [FromKeyedServices("MDB")] IDbcontext mongoContext)
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
            _mongoContext = mongoContext;
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
            var prodImage = _mongoContext.ProductImage.FirstOrDefault(m => m.ProductID == id);
            if (prodImage != null)
            {
                using (var stream = new MemoryStream(prodImage.Image)) { 
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


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            var stock = _context.WarehouseStock.FirstOrDefault(m => m.ProductID == Product.ID);
            if(stock != null)
            {
                stock.AvailableQty = Product.StockQuantity;
                _context.WarehouseStock.Update(stock);
            }

            await _context.SaveChangesAsync();

            try
            {
                await _context.SaveChangesAsync();
                var prodImage = _mongoContext.ProductImage.FirstOrDefault(m => m.ProductID == Product.ID);
                if (Product.ProductImage != null && prodImage != null) {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Product.ProductImage.CopyToAsync(memoryStream);

                        // Upload the file if less than 2 MB
                        if (memoryStream.Length < 2097152)
                        {
                            prodImage.Image = memoryStream.ToArray();
                            _mongoContext.ProductImage.Update(prodImage);
                            await _mongoContext.SaveChangesAsync();
                        }
                    }
                }
                else if (Product.ProductImage != null && prodImage == null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Product.ProductImage.CopyToAsync(memoryStream);

                        // Upload the file if less than 2 MB
                        if (memoryStream.Length < 2097152)
                        {
                            _mongoContext.ProductImage.Add(new ProductImage() { ProductID = Product.ID, Image = memoryStream.ToArray() });
                            await _mongoContext.SaveChangesAsync();
                        }
                    }
                }


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(ObjectId id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
