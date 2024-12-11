using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;

namespace GlobalShopping.Pages.OrderLine
{
    public class CreateModel : PageModel
    {
        private readonly IDbcontext _context;

        public CreateModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
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
        }

        public IActionResult OnGet(ObjectId? id)
        {
            if (!id.HasValue || id.Value == ObjectId.Empty)
            {
                return NotFound();
            }

            var order = _context.Order.FirstOrDefault(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            var line = new Models.OrderLine()
            {
                OrderID = id.Value,
                Order = order
            };

            OrderLine = line;

            //ViewData["OrderID"] = new SelectList(_context.Order, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ID", "Name");
            ViewData["StockBalance"] = new SelectList(_context.Set<WarehouseStock>(), "ProductID", "AvailableQty");

            return Page();
        }

        [BindProperty]
        public Models.OrderLine OrderLine { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderLine.Add(OrderLine);

            var stockBalance = _context.WarehouseStock.FirstOrDefault(m => m.ProductID == OrderLine.ProductID);

            if(stockBalance!= null)
            {
                stockBalance.AvailableQty -= OrderLine.Quantity;
                _context.WarehouseStock.Update(stockBalance);
            }


            await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            return RedirectToPage("/Order/Index");
        }
    }
}
