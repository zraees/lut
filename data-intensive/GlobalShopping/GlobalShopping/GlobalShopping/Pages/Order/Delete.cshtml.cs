using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages.Order
{
    public class DeleteModel : PageModel
    {
        private readonly IDbcontext _context;

        public DeleteModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
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

        [BindProperty]
        public Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var lines = await _context.OrderLine.Where(m => m.OrderID == id).ToListAsync();
                var products = await _context.Product.ToListAsync();
                var productlines = lines.Join(products, m => m.ProductID, t => t.ID, (m, t) => { var _line = m; _line.Product = t; return _line; }).ToList();
                order.Lines = productlines;
                Order = order;
            }
            ViewData["UserID"] = new SelectList(_context.Set<Models.UserAccount>(), "ID", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                Order = order;
                var lines = _context.OrderLine.Where(m => m.OrderID == order.ID).ToList();
                _context.OrderLine.RemoveRange(lines);
                await _context.SaveChangesAsync();

                var stock = _context.WarehouseStock.ToList();
                foreach(var item in lines)
                {
                    var stockBalance = stock.Where(m => m.ProductID == item.ProductID).FirstOrDefault();
                    if(stockBalance != null)
                    {
                        stockBalance.AvailableQty += item.Quantity;
                        _context.WarehouseStock.Update(stockBalance);
                    }

                }
                await _context.SaveChangesAsync();

                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
